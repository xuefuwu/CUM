<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    搜索结果
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>维修清单</h2>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                    </div>
                    <div class="ibox-content">
                        <table class="table table-striped table-bordered table-hover dataTables">
                            <thead>
                                <tr>
                                    <th>日期</th>
                                    <th>单号</th>
                                    <th>流水号</th>
                                    <th>序列号</th>
                                    <th>客户姓名</th>
                                    <th>电话</th>
                                    <th>机位</th>
                                    <th>维保状态</th>
                                    <th>维修状态</th>
                                    <th>结单</th>
                                    <th>是否取件</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var m in (IEnumerable<BBP.Order>)Model)
                                   { %>
                                <tr>
                                    <td data-container="body" data-toggle="popover" data-placement="bottom" data-content="<%: m.Fault %>"><%: m.Created.ToShortDateString() %></td>
                                    <td><%: m.OrderNo %></td>
                                    <td><%: m.SN %></td>
                                    <td><%: m.MachineSN %></td>
                                    <td><%: m.Customer.Name %></td>
                                    <td><%: m.Customer.TeleNum %></td>
                                    <td><%: m.Position %></td>
                                    <td><%: m.Guarantee %></td>
                                    <td><%: m.Status %></td>
                                    <td><%: m.Paid %></td>
                                    <td><%: m.Receive %></td>
                                    <td><%:Html.MethodActionLink("明细", "Details", "Order",true,"btn btn-primary", new { id=m.ID }) %>
                                        <%:Html.MethodActionLink("编辑", "Edit", "Order",true,"btn btn-primary", new { id=m.ID }) %>
                                        <%:Html.MethodActionLink("删除", "Delete", "Order",true,"btn btn-primary", new { id=m.ID }) %>
                                       </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="11"><%: m.Fault %></td>
                                </tr>--%>
                                <% } %>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>日期</th>
                                    <th>单号</th>
                                    <th>流水号</th>
                                    <th>序列号</th>
                                    <th>客户姓名</th>
                                    <th>电话</th>
                                    <th>机位</th>
                                    <th>维保状态</th>
                                    <th>维修状态</th>
                                    <th>结单</th>
                                    <th>是否取件</th>
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
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="JSContent">
    <script>
        $(document).ready(function () {
            $('.dataTables').dataTable();

            /* Init DataTables */
            var oTable = $('#editable').dataTable();

            /* Apply the jEditable handlers to the table */
            oTable.$('td').editable('../example_ajax.php', {
                "callback": function (sValue, y) {
                    var aPos = oTable.fnGetPosition(this);
                    oTable.fnUpdate(sValue, aPos[0], aPos[1]);
                },
                "submitdata": function (value, settings) {
                    return {
                        "row_id": this.parentNode.getAttribute('id'),
                        "column": oTable.fnGetPosition(this)[2]
                    };
                },

                "width": "90%",
                "height": "100%"
            });


        });
    </script>
</asp:Content>
