<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    修改资源
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <% BBP.ControllerAction c = (BBP.ControllerAction)Model; %>
    <input type="hidden" name="ID" value="<%:c.ID %>" />
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">资源名称：</label>
            <div class="col-sm-9">
                <input type="text" name="Name" class="form-control" placeholder="请输入文本" value="<%:c.Name %>">

            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">是否为控制器：</label>
            <div class="col-sm-9">
                <label class="radio-inline" for="IsControllerYes">
                    <input type="radio" value="True" id="IsControllerYes" name="IsController">是</label>
                <label class="radio-inline" for="IsControllerNo">
                    <input type="radio" value="False" id="IsControllerNo" name="IsController">否</label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">控制器名称：</label>
            <div class="col-sm-9">
                <input type="text" name="ControllName" class="form-control" placeholder="请输入文本" value="<%:c.ControllName %>">
                <span class="help-block m-b-none text-error">如果是导航此项必须填写控制器名称</span>

            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">是否允许无规则访问：</label>
            <div class="col-sm-9">
                <label class="radio-inline" for="IsAllowedNoneRolesYes">
                    <input type="radio" value="True" id="IsAllowedNoneRolesYes" name="IsAllowedNoneRoles">是</label>
                <label class="radio-inline" for="IsAllowedNoneRolesNo">
                    <input type="radio" value="False" id="IsAllowedNoneRolesNo" name="IsAllowedNoneRoles">否</label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">是否允许有规则访问：</label>
            <div class="col-sm-9">
                <label class="radio-inline" for="IsAllowedAllRolesYes">
                    <input type="radio" value="True" id="IsAllowedAllRolesYes" name="IsAllowedAllRoles">是</label>
                <label class="radio-inline" for="IsAllowedAllRoles">
                    <input type="radio" value="False" id="IsAllowedAllRolesNo" name="IsAllowedAllRoles">否</label>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    修改资源
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
        <% BBP.ControllerAction c = (BBP.ControllerAction)Model; %>
    <script>
        $(document).ready(function () {
            if ("True" == "<%:c.IsController%>") {
                $("#IsControllerYes").prop("checked", true);
            }
            else {
                $("#IsControllerNo").prop("checked", true);
            }
            if ("True" == "<%:c.IsAllowedAllRoles%>") {
                $("#IsAllowedAllRolesYes").prop("checked", true);
            }
            else {
                $("#IsAllowedAllRolesNo").prop("checked", true);
            }
            if ("True" == "<%:c.IsAllowedNoneRoles%>") {
                $("#IsAllowedNoneRolesYes").prop("checked", true);
            }
            else {
                $("#IsAllowedNoneRolesNo").prop("checked", true);
            }
            $(".btn-submit").click(function () {
                $("form").attr("action", "/Admin/Actions/Edit");
                $("form").submit();
            });
        });
</script>
</asp:Content>
