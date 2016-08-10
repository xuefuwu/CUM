<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    维修清单
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
                        <%:Html.MethodActionLink( "新增", "Create", "Order",false,"btn btn-primary") %>
                    </div>
                    <div class="ibox-content">
                        <table class="table table-striped table-bordered table-hover dataTables">
                            <thead>
                                <tr>
                                    <th>日期</th>
                                    <th>单号</th>
                                    <th>流水号</th>
                                    <th>序列号</th>
                                    <th>机器型号</th>
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
                                <tr style="<%if (m.Paid == "已结单")
                                             { %>background-color: #f2dede; <%}
                                             else if (m.Status == "完修")
                                             {%>background-color: #dff0d8; <%} %>">
                                    <td data-container="body" data-toggle="popover" data-placement="bottom" data-content="<%: m.Fault %>"><%: m.Created.ToShortDateString() %></td>
                                    <td><%: m.OrderNo %></td>
                                    <td><%: m.SN %></td>
                                    <td><%: m.MachineSN %></td>
                                    <td><%: m.MachineModel %></td>
                                    <td><%: m.Customer.Name %></td>
                                    <td><%: m.Customer.TeleNum %></td>
                                    <td><%: m.Position %></td>
                                    <td><%: m.Guarantee %></td>
                                    <td><%: m.Status %></td>
                                    <td><%: m.Paid %></td>
                                    <td><%: m.Receive %></td>
                                    <td><%:Html.MethodActionLink("明细", "Details", "Order",true,"btn btn-primary", new { id=m.ID }) %>
                                        <%:Html.MethodActionLink("编辑", "Edit", "Order",true,"btn btn-primary", new { id=m.ID }) %>
                                        <%:Html.MethodActionLink("删除", "Delete", "Order",false,"btn btn-primary", new { id=m.ID }) %>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>日期</th>
                                    <th>单号</th>
                                    <th>流水号</th>
                                    <th>序列号</th>
                                    <th>机器型号</th>
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
    <div class="modal inmodal fade" id="DelModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">是否删除</h4>
                </div>
                <div class="modal-body">
                    <p>是否删除当前记录</p>
                </div>
                <div class="modal-footer">
                    <input type="hidden" id="url"/>
                    <button type="button" class="btn btn-white" data-dismiss="modal">取消</button>
                    <button type="button" class="btn btn-primary" onclick="urlSubmit()">确认</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="JSContent">
    <script>
            function delcfm(url) {
                $('#url').val(url);//给会话中的隐藏属性URL赋值  
                $('#DelModal').modal();
            }
            function urlSubmit() {
                var url = $.trim($("#url").val());//获取会话中的隐藏属性URL  
                window.location.href = url;
            }
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
