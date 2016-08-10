<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    修改分派用户
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <% BBP.User u = (BBP.User)Model; %>
    <input name="ID" type="hidden" value="<%:u.ID %>" />
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">用户帐号：</label>
            <div class="col-sm-9">
                <input type="text" name="Name" id="Name" class="form-control" placeholder="请输入文本" required="" aria-required="true" value="<%:u.Name %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">密码：</label>
            <div class="col-sm-9">
                <input type="password" class="form-control" name="Password" id="Password" placeholder="请输入密码" required>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">确认密码：</label>
            <div class="col-sm-9">
                <input type="password" class="form-control" name="confirm_password" placeholder="请输入密码" id="confirm_password">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">姓名：</label>
            <div class="col-sm-9">
                <input type="text" name="ChineseName" id="ChineseName" class="form-control" placeholder="请输入文本" value="<%:u.ChineseName %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">性别：</label>
            <div class="col-sm-9">
                <label class="radio-inline">
                    <input type="radio" value="True" id="GenderMale" name="Gender">男</label>
                <label class="radio-inline">
                    <input type="radio" value="False" id="GenderFeMale" name="Gender">女</label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">电子邮箱：</label>
            <div class="col-sm-9">
                <input type="email" name="Email" id="Email1" class="form-control" placeholder="请输入文本" required="" aria-required="true" value="<%:u.Email %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">所属部门：</label>
            <div class="col-sm-9">
                <select class="form-control" name="Dept.ID">
                    <% foreach (BBP.Dept t in (List<BBP.Dept>)ViewData["deptList"])
                       { %>
                    <option value="<%:t.ID %>" <%if (u.Dept != null && t.ID == u.Dept.ID)
                                                 {%> selected <%} %>><%:t.Name %></option>
                    <%} %>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">是否可用：</label>
            <div class="col-sm-9">
                <label class="radio-inline">
                    <input type="radio" checked value="True" id="EnabledYes" name="Enabled">可用</label>
                <label class="radio-inline">
                    <input type="radio" value="False" id="EnabledNo" name="Enabled">停用</label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">联系电话：</label>
            <div class="col-sm-9">
                <input type="text" name="OfficePhone" class="form-control" placeholder="请输入文本" value="<%:u.OfficePhone %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">备注：</label>
            <div class="col-sm-9">
                <textarea name="Remark" class="form-control" placeholder="请输入文本"><%:u.Remark %></textarea>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">用户角色：</label>
            <div class="col-sm-9">
                <select class="form-control" name="Role.id">
                    <% foreach (BBP.Role r in (List<BBP.Role>)ViewData["roleList"])
                       { %>
                    <option value="<%:r.ID %>" <%if (u.Roles.FirstOrDefault() != null && r.ID == u.Roles.FirstOrDefault().ID)
                                                 { %> selected <%} %>><%:r.Name %></option>
                    <%} %>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">职位：</label>
            <div class="col-sm-9">
                <select class="form-control" name="Title.id">
                    <% foreach (BBP.Title t in (List<BBP.Title>)ViewData["titleList"])
                       { %>
                    <option value="<%:t.ID %>" <%if (u.Titles.FirstOrDefault() != null && t.ID == u.Titles.FirstOrDefault().ID)
                                                 { %>
                        selected <%} %>><%:t.Name %></option>
                    <%} %>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">系统功能：</label>
            <div class="col-sm-9">
                <select class="form-control" name="Power.ID">
                    <% foreach (BBP.Power t in (List<BBP.Power>)ViewData["powerList"])
                       { %>
                    <option value="<%:t.ID %>"<%if (u.Powers.FirstOrDefault() != null && t.ID == u.Powers.FirstOrDefault().ID)
                                                 { %>
                        selected <%} %>><%:t.Title %></option>
                    <%} %>
                </select>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    修改分派用户
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ExtendContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <% BBP.User u = (BBP.User)Model; %>
    <!-- jQuery Validation plugin javascript-->
    <script src="/js/plugins/validate/jquery.validate.min.js"></script>
    <script src="/js/plugins/validate/messages_zh.min.js"></script>

    <script>
        $.validator.setDefaults({
            highlight: function (element) {
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
            },
            success: function (element) {
                element.closest('.form-group').removeClass('has-error').addClass('has-success');
            },
            errorElement: "span",
            errorClass: "help-block m-b-none",
            validClass: "help-block m-b-none"


        });

        //以下为官方示例
        $().ready(function () {
            if ("True" == "<%:u.Gender%>") {
                $("#GenderMale").prop("checked", true);
            } else {
                $("#GenderFemale").prop("checked", true);
            }
            $(".btn-submit").click(function () {
                $("#mainform").attr("action", "/Admin/User/Edit");
                $("#mainform").submit();
            });

            // validate signup form on keyup and submit
            $("#mainform").validate({
                rules: {
                    Name: {
                        required: false,
                        minlength: 2
                    },
                    Password: {
                        required: false,
                        minlength: 5
                    },
                    confirm_password: {
                        required: false,
                        minlength: 5,
                        equalTo: "#Password"
                    },
                    Email: {
                        required: true,
                        email: true
                    },
                    topic: {
                        required: "#newsletter:checked",
                        minlength: 2
                    },
                    agree: "required"
                },
                messages: {
                    firstname: "请输入你的姓",
                    lastname: "请输入您的名字",
                    username: {
                        required: "请输入您的用户名",
                        minlength: "用户名必须两个字符以上"
                    },
                    password: {
                        //required: "请输入您的密码",
                        minlength: "密码必须5个字符以上"
                    },
                    confirm_password: {
                        required: "请再次输入密码",
                        minlength: "密码必须5个字符以上",
                        equalTo: "两次输入的密码不一致"
                    },
                    Email: "请输入您的E-mail",
                    agree: "必须同意协议后才能注册"
                }
            });

        });
    </script>
</asp:Content>
