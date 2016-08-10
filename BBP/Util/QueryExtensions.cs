using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using BBP.Util;
using System.Reflection;

namespace BBP
{
    public static class QueryExtensions
    {
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, string sortExpression)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            string sortDirection = String.Empty;
            string propertyName = String.Empty;

            sortExpression = sortExpression.Trim();
            int spaceIndex = sortExpression.Trim().IndexOf(" ");
            if (spaceIndex < 0)
            {
                propertyName = sortExpression;
                sortDirection = "ASC";
            }
            else
            {
                propertyName = sortExpression.Substring(0, spaceIndex);
                sortDirection = sortExpression.Substring(spaceIndex + 1).Trim();
            }

            //////////////////////////////
            //有关联属性
            if (propertyName.IndexOf('.') > 0)
            {
                if (sortDirection == "ASC")
                    return source.OrderBy(propertyName);
                else
                    return source.OrderByDescending(propertyName);
            }
            //////////////////////////////

            if (String.IsNullOrEmpty(propertyName))
            {
                return source;
            }

            ParameterExpression parameter = Expression.Parameter(source.ElementType, String.Empty);
            MemberExpression property = Expression.Property(parameter, propertyName);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = (sortDirection == "ASC") ? "OrderBy" : "OrderByDescending";

            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                                new Type[] { source.ElementType, property.Type },
                                                source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }


        // http://fineui.com/bbs/forum.php?mod=viewthread&tid=3844

        public enum EOrderType
        {
            OrderBy = 0,
            OrderByDescending = 1,
            ThenBy = 2,
            ThenByDescending = 3
        }
        /// <summary>
        /// 升序排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, EOrderType.OrderBy);
        }

        /// <summary>
        /// 降序排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, EOrderType.OrderByDescending);
        }
        /// <summary>
        /// 应用排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ApplyOrder<T>(this IQueryable<T> source, string property, EOrderType orderType)
        {
            var methodName = orderType.ToString();

            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ 
                System.Reflection.PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
            object result = typeof(Queryable).GetMethods().Single(method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                            .MakeGenericMethod(typeof(T), type)
                            .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }
        /// <summary>
        /// ThenBy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, EOrderType.ThenBy);
        }

        /// <summary>
        /// ThenByDescending
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, EOrderType.ThenByDescending);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, User currentUser)
        {
            BaseContext DB;
            HttpContextBase context = new HttpContextWrapper(System.Web.HttpContext.Current);
            // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
            if (!context.Items.Contains("__BaseContext"))
            {
                DB = new BaseContext();
            }
            else
            {
                DB = context.Items["__BaseContext"] as BaseContext;
            }
            Type type = typeof(T);
            ParameterExpression parameter1 = Expression.Parameter(type, "o");
            Expression right = null;

            if (currentUser.Roles.Count > 0)
            {
                Role role = currentUser.Roles.FirstOrDefault();
                List<Operator> wo = DB.Operators.Where(o => o.ClassName.Equals(type.FullName) && o.Role.ID.Equals(role.ID)).OrderByDescending(o => o.ID).ToList();

                if (wo.Count > 0)
                {
                    for (int i = 0; i < wo.Count; i++)
                    {
                        var v1 = Convert.ChangeType(wo[i].Value, type.GetProperty(wo[i].PropertyName).PropertyType);
                        if (i == 0)
                        {
                            if (wo[i].Method.Equals("Equals"))
                            {
                                right = Expression.Equal(Expression.PropertyOrField(parameter1, type.GetProperty(wo[i].PropertyName).Name), Expression.Constant(v1));
                            }
                            else if (wo[i].Method.Equals("NotEquals"))
                            {
                                right = Expression.NotEqual(Expression.PropertyOrField(parameter1, type.GetProperty(wo[i].PropertyName).Name), Expression.Constant(v1));
                            }
                        }
                        else
                        {
                            if (wo[i].Relation.Equals("Or"))
                            {
                                if (wo[i].Method.Equals("Equals"))
                                {
                                    right = Expression.Or(Expression.Equal(Expression.PropertyOrField(parameter1, type.GetProperty(wo[i].PropertyName).Name), Expression.Constant(v1)), right);
                                }
                                else if (wo[i].Method.Equals("NotEquals"))
                                {
                                    right = Expression.Or(Expression.NotEqual(Expression.PropertyOrField(parameter1, type.GetProperty(wo[i].PropertyName).Name), Expression.Constant(v1)), right);
                                }
                            }
                            else if (wo[i].Relation.Equals("And"))
                            {
                                if (wo[i].Method.Equals("Equals"))
                                {
                                    right = Expression.And(Expression.Equal(Expression.PropertyOrField(parameter1, type.GetProperty(wo[i].PropertyName).Name), Expression.Constant(v1)), right);
                                }
                                else if (wo[i].Method.Equals("NotEquals"))
                                {
                                    right = Expression.And(Expression.NotEqual(Expression.PropertyOrField(parameter1, type.GetProperty(wo[i].PropertyName).Name), Expression.Constant(v1)), right);
                                }
                            }

                        }
                    }
                }
            }
            if (right != null)
            {
                var lambda1 = Expression.Lambda<Func<T, Boolean>>(right, parameter1);
                return source.Provider.CreateQuery<T>(Expression.Call(typeof(Queryable), "Where", new Type[] { typeof(T) }, new Expression[] { source.Expression, lambda1 }));
            }
            else
            {
                return source;
            }
        }
    }
}