using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BBP
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<BaseContext>  // CreateDatabaseIfNotExists DropCreateDatabaseAlways  DropCreateDatabaseIfModelChanges
    {
        protected override void Seed(BaseContext context)
        {
            GetConfigs().ForEach(c => context.Configs.Add(c));
            GetDepts().ForEach(d => context.Depts.Add(d));

            GetRoles().ForEach(r => context.Roles.Add(r));
            GetPowers().ForEach(p => context.Powers.Add(p));
            GetTitles().ForEach(t => context.Titles.Add(t));
            GetCustomer().ForEach(c => context.Customers.Add(c));

            GetControllerAction().ForEach(c => context.ControllerActions.Add(c));
            context.SaveChanges();

            GetUsers(context).ForEach(u => context.Users.Add(u));
            // 添加菜单时需要指定ViewPower，所以上面需要先保存到数据库
            //GetMenus(context).ForEach(m => context.Menus.Add(m));

            GetControllerActionRole(context).ForEach(c => context.ControllerActionRoles.Add(c));

            getOperators(context).ForEach(c => context.Operators.Add(c));

            GetAttrTypes(context).ForEach(c => context.AttrTypes.Add(c));

            GetAttrs(context).ForEach(c => context.Attrs.Add(c));
            context.SaveChanges();
        }

        private static List<Customer> GetCustomer()
        {
            var customer = new List<Customer>
            {
                new Customer{
                    Name="吴学孚",
                    TeleNum="13868322821",
                    Business=false
                }
            };
            return customer;
        }

        private static List<ControllerAction> GetControllerAction()
        {
            var controllerAction = new List<ControllerAction>
            {
                //订单
                new ControllerAction(){Name="Order",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=true},
                new ControllerAction(){ControllName="Order",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = true}, 
                new ControllerAction(){ControllName="Order",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Order",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Order",Name="Detail",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                //客户
                new ControllerAction(){Name="Customer",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=true},
                new ControllerAction(){ControllName="Customer",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = true}, 
                new ControllerAction(){ControllName="Customer",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Customer",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                //维修信息
                new ControllerAction(){Name="RepairDetail",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=true},
                new ControllerAction(){ControllName="RepairDetail",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = true}, 
                new ControllerAction(){ControllName="RepairDetail",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="RepairDetail",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                //费用
                new ControllerAction(){Name="Bill",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=true},
                new ControllerAction(){ControllName="Bill",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = true}, 
                new ControllerAction(){ControllName="Bill",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Bill",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                //任务派发
                new ControllerAction(){Name="Task",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=true},
                new ControllerAction(){ControllName="Task",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = true}, 
                new ControllerAction(){ControllName="Task",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Task",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                //Dept
                new ControllerAction(){Name="Admin/Dept",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=true},
                new ControllerAction(){ControllName="Admin/Dept",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = true}, 
                new ControllerAction(){ControllName="Admin/Dept",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Dept",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false},

                //Role
                new ControllerAction(){Name="Admin/Role",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=false},
                new ControllerAction(){ControllName="Admin/Role",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Role",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Role",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false},
                new ControllerAction(){ControllName="Admin/Role",Name="Assign",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false},
                //log
                new ControllerAction(){Name="Admin/Log",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=true},
                new ControllerAction(){ControllName="Admin/Log",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = true}, 
                new ControllerAction(){ControllName="Admin/Log",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Log",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false},//online
                //ControllerAction
                new ControllerAction(){Name="Admin/Actions",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=false},
                new ControllerAction(){ControllName="Admin/Actions",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Actions",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Actions",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false},
                //ControllerActionRole
                new ControllerAction(){Name="Admin/ControllerActionRole",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=false},
                new ControllerAction(){ControllName="Admin/ControllerActionRole",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/ControllerActionRole",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/ControllerActionRole",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false},
                //Title
                new ControllerAction(){Name="Admin/Title",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=false},
                new ControllerAction(){ControllName="Admin/Title",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Title",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Title",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false} ,

                //Operator
                new ControllerAction(){Name="Admin/Operator",IsController=true,IsAllowedNoneRoles=false,IsAllowedAllRoles=false},
                new ControllerAction(){ControllName="Admin/Operator",Name="Create",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Operator",Name="Edit",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}, 
                new ControllerAction(){ControllName="Admin/Operator",Name="Delete",IsController=false,IsAllowedNoneRoles=false,IsAllowedAllRoles = false}

            };

            return controllerAction;
        }

        private static List<ControllerActionRole> GetControllerActionRole(BaseContext context)
        {
            var car = new List<ControllerActionRole>();
            var role = context.Roles.Where(p => p.Name == ("系统管理员")).FirstOrDefault<Role>();

            var actionList = context.ControllerActions.AsEnumerable();
            foreach (var action in actionList)
            {
                car.Add(new ControllerActionRole()
                {
                    ControllerAction = action,
                    Role = role,
                    IsAllowed = true
                });
            }
            actionList = context.ControllerActions.Where(p => p.IsController == true);
            foreach (var action in actionList)
            {
                car.Add(new ControllerActionRole()
                {
                    ControllerAction = action,
                    Role = role,
                    IsAllowed = true
                });
            }
            return car;
        }
        /*
        private static List<Menu> GetMenus(BaseContext context)
        {
            var menus = new List<Menu> { 
                new Menu
                {
                    Name = "系统管理",
                    SortIndex = 1,
                    Remark = "顶级菜单",
                    Children = new List<Menu> { 
                        new Menu
                        {
                            Name = "用户管理",
                            SortIndex = 10,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/user.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreUserView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "职称管理",
                            SortIndex = 20,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/title.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreTitleView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "职称用户管理",
                            SortIndex = 30,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/title_user.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreTitleUserView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "部门管理",
                            SortIndex = 40,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/dept.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreDeptView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "部门用户管理",
                            SortIndex = 50,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/dept_user.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreDeptUserView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "角色管理",
                            SortIndex = 60,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/role.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreRoleView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "角色用户管理",
                            SortIndex = 70,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/role_user.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreRoleUserView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "权限管理",
                            SortIndex = 80,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/power.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CorePowerView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "角色权限管理",
                            SortIndex = 90,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/role_power.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreRolePowerView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "菜单管理",
                            SortIndex = 100,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/menu.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreMenuView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "在线统计",
                            SortIndex = 110,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/online.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreOnlineView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "系统配置",
                            SortIndex = 120,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/config.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreConfigView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "修改密码",
                            SortIndex = 130,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/profile.aspx",
                            ImageUrl = "~/res/icon/tag_blue.png"
                        }
                    }
                }
            };

            return menus;
        }
        */
        private static List<Title> GetTitles()
        {
            var titles = new List<Title>()
            {
                new Title() 
                {
                    Name = "总经理"
                },
                new Title() 
                {
                    Name = "部门经理"
                },
                new Title() 
                {
                    Name = "高级工程师"
                },
                new Title() 
                {
                    Name = "工程师"
                },
                new Title()
                {
                    Name="前台"
                }
            };

            return titles;
        }

        private static List<Power> GetPowers()
        {
            var powers = new List<Power>
            {
                new Power
                {
                    Name = "Administrator",
                    Title = "系统管理员",
                    GroupName = "Admin"
                },
                new Power
                {
                    Name = "Manager",
                    Title = "主管",
                    GroupName = "CIO"
                },
                new Power
                {
                    Name = "User",
                    Title = "普通用户",
                    GroupName = "CoreUser"
                }
            };

            return powers;
        }

        private static List<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "系统管理员",
                    Remark = ""
                },
                new Role()
                {
                    Name = "总经理",
                    Remark = ""
                },
                new Role()
                {
                    Name = "部门主管",
                    Remark = ""
                },
                new Role()
                {
                    Name = "维修工程师",
                    Remark = ""
                },
                new Role()
                {
                    Name = "前台",
                    Remark = ""
                },
                new Role()
                {
                    Name="库管"
                }
            };

            return roles;
        }

        private static List<User> GetUsers(BaseContext context)
        {
            string[] USER_NAMES = { "True", "周胜春", "zsc", "False", "雷鸣", "lm", "True", "王伟伟", "www", "True", "张超", "zc", "True", "刘凡", "lf", "True", "曾伟豪", "zwh", "True", "夏志贤", "xzx", "True", "赵志豪", "zzh", "True", "徐力", "xl", "False", "王林芳", "wlf", "True", "孙海波", "shb", "True", "郑尔疆", "zej", "True", "徐李毅", "xly", "True", "方生科", "fsk", "True", "方生科", "fsk1" };
            string[] EMAIL_NAMES = { "qq.com", "gmail.com", "163.com", "126.com", "outlook.com", "foxmail.com" };

            var users = new List<User>();
            var rdm = new Random();

            for (int i = 0, count = USER_NAMES.Length; i < count; i += 3)
            {
                string gender = USER_NAMES[i];
                string chineseName = USER_NAMES[i + 1];
                string userName = USER_NAMES[i + 2];

                users.Add(new User
                {
                    Name = userName,
                    Gender = gender,
                    Password = PasswordUtil.CreateDbPassword(userName),
                    ChineseName = chineseName,
                    Email = userName + "@" + EMAIL_NAMES[rdm.Next(0, EMAIL_NAMES.Length)],
                    Enabled = true,
                    CreateTime = DateTime.Now
                });
            }

            // 添加超级管理员
            users.Add(new User
            {
                Name = "admin",
                Gender = "男",
                Password = PasswordUtil.CreateDbPassword("admin"),
                ChineseName = "超级管理员",
                Email = "admin@examples.com",
                Enabled = true,
                CreateTime = DateTime.Now,
                Roles = context.Roles.Where(p => p.Name == ("系统管理员")).ToList(),
                Dept = context.Depts.Find(1),
                Titles=context.Titles.Where(p=> p.Name==("总经理")).ToList()
            });

            return users;
        }

        private static List<Dept> GetDepts()
        {
            var depts = new List<Dept> { 
                new Dept
                {
                    Name = "惠普维修站",
                    SortIndex = 1,
                    Remark = "",
                    Children = new List<Dept>{
                        new Dept{
                            Name="行政部",
                            SortIndex=1,
                            Remark=""
                        },
                        new Dept{
                            Name="维修部",
                            SortIndex = 2,
                            Remark=""
                        }
                    }
                },
                new Dept
                {
                    Name = "华硕维修站",
                    SortIndex = 2,
                    Remark = "",
                    Children = new List<Dept>{
                        new Dept{
                            Name="行政部",
                            SortIndex=1,
                            Remark=""
                        },
                        new Dept{
                            Name="维修部",
                            SortIndex = 2,
                            Remark=""
                        }
                    }
                }
            };

            return depts;
        }

        private static List<Config> GetConfigs()
        {
            var configs = new List<Config> {
                new Config
                {
                    ConfigKey = "Title",
                    ConfigValue = "BBP - 通用权限管理框架",
                    Remark = "网站的标题"
                },
                new Config
                {
                    ConfigKey = "PageSize",
                    ConfigValue = "20",
                    Remark = "表格每页显示的个数"
                },
                new Config
                {
                    ConfigKey = "MenuType",
                    ConfigValue = "tree",
                    Remark = "左侧菜单样式"
                },
                new Config
                {
                    ConfigKey = "Theme",
                    ConfigValue = "Cupertino",
                    Remark = "网站主题"
                },
                new Config
                {
                    ConfigKey = "HelpList",
                    ConfigValue = "[{\"Text\":\"万年历\",\"Icon\":\"Calendar\",\"ID\":\"wannianli\",\"URL\":\"~/admin/help/wannianli.htm\"},{\"Text\":\"科学计算器\",\"Icon\":\"Calculator\",\"ID\":\"jisuanqi\",\"URL\":\"~/admin/help/jisuanqi.htm\"},{\"Text\":\"系统帮助\",\"Icon\":\"Help\",\"ID\":\"help\",\"URL\":\"~/admin/help/help.htm\"}]",
                    Remark = "帮助下拉列表的JSON字符串"
                }
            };

            return configs;
        }

        private static List<Attrs> GetAttrs(BaseContext context)
        {
            var AttrList = new List<Attrs>()
            {
                new Attrs(){
                    AttrName="所属区县",AttrValue="鹿城区"
                },
                new Attrs(){
                    AttrName="所属区县",AttrValue="龙湾区"
                },
                new Attrs(){
                    AttrName="所属区县",AttrValue="瓯海区"
                }
            };
            return AttrList;
        }

        private static List<AttrType> GetAttrTypes(BaseContext context)
        {
            var AttrTypeList = new List<AttrType>()
            {
                new AttrType(){
                    TypeName="考核场所属性"
                }
            };
            return AttrTypeList;
        }

        private static List<Operator> getOperators(BaseContext context)
        {
            var operatorList = new List<Operator>()
            {
                 new Operator(){
                    ClassName="BBP.Order",PropertyName="Status",Method="Equals",Value="",Relation="Or",Role = context.Roles.Where(r=>r.Name=="维修工程师").FirstOrDefault<Role>()
                },new Operator(){
                    ClassName="BBP.Order",PropertyName="Status",Method="Equals",Value="待检",Relation="Or",Role = context.Roles.Where(r=>r.Name=="维修工程师").FirstOrDefault<Role>()
                },new Operator(){
                    ClassName="BBP.Order",PropertyName="Status",Method="Equals",Value="已检验",Relation="Or",Role = context.Roles.Where(r=>r.Name=="维修工程师").FirstOrDefault<Role>()
                },new Operator(){
                    ClassName="BBP.Order",PropertyName="Status",Method="Equals",Value="DOA",Relation="Or",Role = context.Roles.Where(r=>r.Name=="维修工程师").FirstOrDefault<Role>()
                },new Operator(){
                    ClassName="BBP.Order",PropertyName="Status",Method="Equals",Value="追加料件",Relation="Or",Role = context.Roles.Where(r=>r.Name=="维修工程师").FirstOrDefault<Role>()
                },
                
                new Operator(){
                     ClassName="BBP.Order",PropertyName="Paid",Method="Equals",Value="未结单",Relation="And",Role=context.Roles.Where(r=>r.Name=="库管").FirstOrDefault<Role>()
                },
                new Operator(){
                     ClassName="BBP.Order",PropertyName="Status",Method="Equals",Value="完修",Relation="And",Role=context.Roles.Where(r=>r.Name=="库管").FirstOrDefault<Role>()
                },
                new Operator(){
                     ClassName="BBP.Order",PropertyName="Status",Method="Equals",Value="",Relation="Or",Role=context.Roles.Where(r=>r.Name=="前台").FirstOrDefault<Role>()
                },
                new Operator(){
                     ClassName="BBP.Order",PropertyName="Paid",Method="Equals",Value="已结单",Relation="Or",Role=context.Roles.Where(r=>r.Name=="前台").FirstOrDefault<Role>()
                }
            };
            return operatorList;
        }

    }
}