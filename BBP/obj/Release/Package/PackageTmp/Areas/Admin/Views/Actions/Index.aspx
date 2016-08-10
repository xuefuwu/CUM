<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    资源列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>资源列表</h2>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <a class="btn btn-primary" href="Actions/Create">新增</a>
                    </div>
                    <div class="ibox-content">
                        <table class="table table-striped table-bordered table-hover dataTables">
                            <thead>
                                <tr>
                                    <th>资源名称</th>
                                    <th>是否是控制器</th>
                                    <th>控制器名称</th>
                                    <th>允许无规则访问</th>
                                    <th>允许有规则访问</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var m in (IEnumerable<BBP.ControllerAction>)Model)
                                   { %>
                                <tr>
                                    <td><%: m.Name %></td>
                                    <td><%: m.IsController %></td>
                                    <td><%: m.ControllName %></td>
                                    <td><%: m.IsAllowedNoneRoles %></td>
                                    <td><%: m.IsAllowedAllRoles %></td>
                                    <td><%: Html.ActionLink("编辑", "Edit", new { id=m.ID }) %>|<%: Html.ActionLink("删除", "Delete", new { id=m.ID }) %></td>
                                </tr>
                                <% } %>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>资源名称</th>
                                    <th>是否是控制器</th>
                                    <th>控制器名称</th>
                                    <th>允许无规则访问</th>
                                    <th>允许有规则访问</th>
                                    <th>操作</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        $(document).ready(function () {
            $('.dataTables').dataTable();
        });
    </script>
</asp:Content>
