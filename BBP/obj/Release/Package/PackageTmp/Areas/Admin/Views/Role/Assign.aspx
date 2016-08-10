<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="System.Linq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    分派资源
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <% BBP.Role r = (BBP.Role)Model; %>
    <input type="hidden" value="<%:r.ID %>" name="RoleID" />
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 label">权限名称：</label>
            <div class="col-sm-9">
                <%:r.Name %>
            </div>
        </div>
        <div class="ibox">
            <label class="col-sm-6 label">资源清单：</label>
            <div class="ibox-content">
                <div class="form-group">
                    <label class="col-sm-3 control-label">授权</label>
                    <div class="col-sm-9">
                        <label class="col-sm-3 control-label"></label>
                        <input type="checkbox" class="AllowAll" /><label>全部授予</label>
                        <input type="checkbox" class="AllowNot" /><label>全部拒绝</label>
                    </div>
                </div>
                <%foreach (BBP.ControllerAction c in (IEnumerable<BBP.ControllerAction>)ViewData["ActionList"])
                  { %>
                <div class="form-group">
                    <label class="col-sm-3 control-label"><%:c.Name %></label>
                    <div class="col-sm-9">
                        <label class="col-sm-3 control-label">是否可访问</label>
                        <input type="hidden" value="<%: c.ID %>" name="ControllerAction.ID" />
                        <%
                      Boolean? isAllowed = null;
                      var controllActionRole = ((IEnumerable<BBP.ControllerActionRole>)ViewData["ControllRole"]).Where(ar => ar.ControllerAction == c);
                      if (ViewData["ControllRole"] != null && controllActionRole.Count() > 0)
                      {
                          isAllowed = controllActionRole.FirstOrDefault<BBP.ControllerActionRole>().IsAllowed;
                      }
                        %>

                        <input type="checkbox" value="<%:c.ID %>_True" <%if (isAllowed.HasValue && isAllowed.Value)
                                                                         {  %>
                            checked <%} %> id="<%:c.ID %>_IsAllowedYes" name="IsAllowed">
                        <label>授予</label>

                        <input type="checkbox" value="<%:c.ID %>_False" <%if (isAllowed.HasValue && !isAllowed.Value)
                                                                          {  %>
                            checked <%} %> id="<%:c.ID %>_IsAllowedNo" name="IsAllowed">
                        <label>拒绝</label>
                        <input name="ViewName" type="text" id="<%:c.ID %>_ViewName" value="<%:controllActionRole.FirstOrDefault<BBP.ControllerActionRole>().ViewName %>" />
                    </div>
                </div>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    新增权限
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <% BBP.Role r = (BBP.Role)Model; %>
    <script>
        $(document).ready(function () {
            $("input[type='checkbox']").click(function () {
                $(this).siblings().prop("checked", false);
                $(this).prop("checked", true);
            });
            $(".AllowAll").click(function () {
                $("input[type='checkbox'][value$='True']").prop("checked", $(this).prop("checked"));
                $("input[type='checkbox'][value$='False']").prop("checked", !$(this).prop("checked"));

            });
            $(".AllowNot").click(function () {
                $("input[type='checkbox'][value$='False']").prop("checked", $(this).prop("checked"));
                $("input[type='checkbox'][value$='True']").prop("checked",! $(this).prop("checked"));

            });
            $(".btn-submit").click(function () {
                $("form").attr("action", "/Admin/Role/Assign");
                $("form").submit();
            });
        });
    </script>
</asp:Content>
