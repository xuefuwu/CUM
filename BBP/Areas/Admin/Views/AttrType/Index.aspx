﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    属性类型
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>属性类型清单</h2>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <a class="btn btn-primary" href="/Admin/AttrType/Create">新增</a>
                    </div>
                    <div class="ibox-content">
                        <table class="table table-striped table-bordered table-hover dataTables">
                            <thead>
                                <tr>
                                    <th>类型名称</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var m in (IEnumerable<BBP.AttrType>)Model)
                                   { %>
                                <tr>
                                    <td><%: m.TypeName %></td>
                                    <td><%: Html.ActionLink("编辑", "Edit", new { id=m.ID }) %>|<%: Html.ActionLink("删除", "Delete", new { id=m.ID }) %></td>
                                </tr>
                                <% } %>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>类型名称</th>
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