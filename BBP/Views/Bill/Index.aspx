<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    费用清单
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>费用清单</h2>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <a class="btn btn-primary" href="/Bill/Create">新增</a>
                    </div>
                    <div class="ibox-content">
                        <table class="table table-striped table-bordered table-hover dataTables">
                            <thead>
                                <tr>
                                    <th>单号</th>
                                    <th>费用类型</th>
                                    <th>金额</th>
                                    <th>经手人</th>
                                    <th>付款时间</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var m in (IEnumerable<BBP.OrderBill>)Model)
                                   { %>
                                <tr>
                                    <td><%: m.Order.OrderNo %></td>
                                    <td><%: m.Type %></td>
                                    <td><%: m.Amount %></td>
                                    <td><%: m.person.ChineseName %></td>
                                    <td><%: m.Created.HasValue?m.Created.Value.ToString("d"):"" %></td>
                                    <td><%: Html.ActionLink("编辑", "Edit", new { id=m.ID }) %>|<%: Html.ActionLink("删除", "Delete", new { id=m.ID }) %></td>
                                </tr>
                                <% } %>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>单号</th>
                                    <th>费用类型</th>
                                    <th>金额</th>
                                    <th>经手人</th>
                                    <th>付款时间</th>
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
