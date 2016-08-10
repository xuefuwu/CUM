<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加用户
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">用户帐号：</label>
            <div class="col-sm-9">
                <input type="text" name="Name" id="Name" class="form-control" placeholder="请输入文本" required="" aria-required="true">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">密码：</label>
            <div class="col-sm-9">
                <input type="password" class="form-control" name="Password" id="password" placeholder="请输入密码" required>
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
                <input type="text" name="ChineseName" id="ChineseName" class="form-control" placeholder="请输入文本">
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
                <input type="email" name="Email" id="Email1" class="form-control" placeholder="请输入文本" required="" aria-required="true">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">所属部门：</label>
            <div class="col-sm-9">
                <select class="form-control" name="Dept.ID">
                    <% foreach (BBP.Dept t in (List<BBP.Dept>)ViewData["deptList"])
                       { %>
                    <option value="<%:t.ID %>"><%:t.Name %></option>
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
                <input type="text" name="OfficePhone" class="form-control" placeholder="请输入文本">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">备注：</label>
            <div class="col-sm-9">
                <textarea name="Remark" class="form-control" placeholder="请输入文本"></textarea>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">用户角色：</label>
            <div class="col-sm-9">
                <select class="form-control" name="Role.ID">
                    <% foreach (BBP.Role r in (List<BBP.Role>)ViewData["roleList"])
                       { %>
                    <option value="<%:r.ID %>"><%:r.Name %></option>
                    <%} %>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">职位：</label>
            <div class="col-sm-9">
                <select class="form-control" name="Title.ID">
                    <% foreach (BBP.Title t in (List<BBP.Title>)ViewData["titleList"])
                       { %>
                    <option value="<%:t.ID %>"><%:t.Name %></option>
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
                    <option value="<%:t.ID %>"><%:t.Title %></option>
                    <%} %>
                </select>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    添加用户
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ExtendContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
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
            $(".btn-submit").click(function () {
                $("#mainform").attr("action", "/Admin/User/Create");
                $("#mainform").submit();
            });

            // validate signup form on keyup and submit
            $("#mainform").validate({
                rules: {
                    firstname: "required",
                    lastname: "required",
                    username: {
                        required: true,
                        minlength: 2
                    },
                    password: {
                        required: true,
                        minlength: 5
                    },
                    confirm_password: {
                        required: true,
                        minlength: 5,
                        equalTo: "#password"
                    },
                    email: {
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
                        required: "请输入您的密码",
                        minlength: "密码必须5个字符以上"
                    },
                    confirm_password: {
                        required: "请再次输入密码",
                        minlength: "密码必须5个字符以上",
                        equalTo: "两次输入的密码不一致"
                    },
                    email: "请输入您的E-mail",
                    agree: "必须同意协议后才能注册"
                }
            });

        });
    </script>
</asp:Content>
