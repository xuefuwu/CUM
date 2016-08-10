using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBP;

namespace System.Web.Mvc
{
    public static class BBPHtmlHelper
    {
        public static MvcHtmlString MenuActionLink(this HtmlHelper html, string className, string LinkText, string actionName, string controllerName, object routeValue = null)
        {
            BaseContext DB;
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            String controller = urlHelper.RequestContext.RouteData.Values["controller"].ToString();
            String action = urlHelper.RequestContext.RouteData.Values["action"].ToString();
            var user = urlHelper.RequestContext.HttpContext.Session["CurrentUser"] as User;
            if (urlHelper.RequestContext.HttpContext.Items.Contains("__BaseContext"))
            {
                DB = urlHelper.RequestContext.HttpContext.Items["__BaseContext"] as BaseContext;
            }
            else
            {
                DB = new BaseContext();
            }
            TagBuilder imgTagBuilder = new TagBuilder("i");
            imgTagBuilder.MergeAttribute("class", className);
            string img = imgTagBuilder.ToString(TagRenderMode.Normal);

            string url = urlHelper.Action(actionName, controllerName, routeValue);

            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img + " <span class=\"nav-label\">" + LinkText + "</span>"
            };
            tagBuilder.MergeAttribute("href", url);
            TagBuilder liTagBuilder = new TagBuilder("li")
                {
                    InnerHtml = tagBuilder.ToString(TagRenderMode.Normal)
                };
            if (controller.Equals(controllerName))
            {
                liTagBuilder.MergeAttribute("class", "active");
            }
            var isAllowed = AuthorizeHelper.IsAllowed(user, controllerName, actionName, DB);
            if (!isAllowed)
            {
                return null;
            }
            return MvcHtmlString.Create(liTagBuilder.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString AdminMenuActionLink(this HtmlHelper html, string className, string LinkText, string actionName, string controllerName, object routeValue = null)
        {
            BaseContext DB;
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            String controller = urlHelper.RequestContext.RouteData.Values["controller"].ToString();
            String action = urlHelper.RequestContext.RouteData.Values["action"].ToString();
            if (urlHelper.RequestContext.HttpContext.Session == null || urlHelper.RequestContext.HttpContext.Session["CurrentUser"] == null)
            {
                urlHelper.RequestContext.HttpContext.Response.Redirect("/");
            }
            var user = urlHelper.RequestContext.HttpContext.Session["CurrentUser"] as User;
            if (urlHelper.RequestContext.HttpContext.Items.Contains("__BaseContext"))
            {
                DB = urlHelper.RequestContext.HttpContext.Items["__BaseContext"] as BaseContext;
            }
            else
            {
                DB = new BaseContext();
            }
            TagBuilder imgTagBuilder = new TagBuilder("i");
            imgTagBuilder.MergeAttribute("class", className);
            string img = imgTagBuilder.ToString(TagRenderMode.Normal);

            string url = urlHelper.Action(actionName, controllerName, routeValue);

            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img + " <span class=\"nav-label\">" + LinkText + "</span>"
            };
            tagBuilder.MergeAttribute("href", url);
            TagBuilder liTagBuilder = new TagBuilder("li")
            {
                InnerHtml = tagBuilder.ToString(TagRenderMode.Normal)
            };
            if (controller.Equals(controllerName))
            {
                liTagBuilder.MergeAttribute("class", "active");
            }
            var isAllowed = AuthorizeHelper.IsAllowed(user, "Admin/"+controllerName, actionName, DB);
            if (!isAllowed)
            {
                return null;
            }
            return MvcHtmlString.Create(liTagBuilder.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString MethodActionLink(this HtmlHelper html, string LinkText, string actionName, string controllerName,Boolean newWin, string className = null, object routeValue = null)
        {
            BaseContext DB;
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            String controller = urlHelper.RequestContext.RouteData.Values["controller"].ToString();
            String action = urlHelper.RequestContext.RouteData.Values["action"].ToString();
            var user = urlHelper.RequestContext.HttpContext.Session["CurrentUser"] as User;
            if (urlHelper.RequestContext.HttpContext.Items.Contains("__BaseContext"))
            {
                DB = urlHelper.RequestContext.HttpContext.Items["__BaseContext"] as BaseContext;
            }
            else
            {
                DB = new BaseContext();
            }
            var isAllowed = AuthorizeHelper.IsAllowed(user, controllerName, actionName, DB);
            if (isAllowed)
            {
                string url = urlHelper.Action(actionName, controllerName, routeValue);
                TagBuilder tagBuilder = new TagBuilder("a")
                {
                    InnerHtml = LinkText
                };
                if (!actionName.Equals("Delete"))
                tagBuilder.MergeAttribute("href", url);
                tagBuilder.MergeAttribute("class", className);
                if (actionName.Equals("Delete"))
                {
                    //tagBuilder.MergeAttribute("data-toggle", "modal");
                    //tagBuilder.MergeAttribute("data-target", "#DelModal");
                    tagBuilder.MergeAttribute("onclick", "javascript:delcfm('" + url + "');");
                }
                if (newWin)
                {
                    tagBuilder.MergeAttribute("target", "_block");
                }
                return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
            }
            else
            {
                return null;
            }
        }
    }
}