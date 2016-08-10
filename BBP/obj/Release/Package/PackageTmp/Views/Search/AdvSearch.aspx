<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   高级搜索
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/css/plugins/datapicker/datepicker3.css" rel="stylesheet">

    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>高级搜索</h2>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title form-group" id="data_5">
                        
                        <form class="form-horizontal" role="search" method="post" action="/Search/AdvSearch">
                            <div class="input-daterange input-group" id="datepicker">
                                <span class="input-group-addon">时间从</span>
                                <input type="text" class="input-sm form-control" name="StartDateStr" />
                                <span class="input-group-addon">到</span>
                                <input type="text" class="input-sm form-control" name="EndDateStr" />
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="btn-group input-group">
                                <button class="btn btn-primary btn-submit" type="Submit">搜索</button>
                                <a class="btn btn-white export" type="button">导出查询结果</a>
                            </div>
                        </form>

                    </div>
                    <a class="title-collapse-link"><i class="fa fa-chevron-up"></i></a>
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
                                <%if (Model != null)
                                  {
                                      foreach (var m in (IEnumerable<BBP.Order>)Model)
                                      { %>
                                <tr>
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
                                        <%:Html.MethodActionLink("删除", "Delete", "Order",true,"btn btn-primary", new { id=m.ID }) %>
                                    </td>
                                </tr>
                                <% }
                                  } %>
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
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="JSContent">
    <script src="/js/plugins/XDate/XDate.js"></script>
    <!-- Data picker -->
    <script src="../../js/plugins/datapicker/bootstrap-datepicker.js"></script>
    <script>
        $(document).ready(function () {
            var firstDate = new Date();
            firstDate.setDate(1); //第一天
            var endDate = new Date(firstDate);
            endDate.setMonth(firstDate.getMonth() + 1);
            endDate.setDate(0);
            if ("" == "<%:ViewData["StartDate"]%>") {
                $("input[name='StartDateStr']").val(new XDate(firstDate).toString('yyyy-MM-dd'));
            } else {
                $("input[name='StartDateStr']").val(new XDate("<%:ViewData["StartDate"]%>").toString('yyyy-MM-dd'));
            }
            if ("" == "<%:ViewData["EndDate"]%>") {
                $("input[name='EndDateStr']").val(new XDate(endDate).toString('yyyy-MM-dd'));
            } else {
                $("input[name='EndDateStr']").val(new XDate("<%:ViewData["EndDate"]%>").toString('yyyy-MM-dd'));
            }

            $(".export").click(function () {
                window.location.href = "/Search/Export?StartDateStr=" + $("input[name='StartDateStr']").val() + "&EndDateStr=" + $("input[name='EndDateStr']").val()
            });

            $('#data_5 .input-daterange').datepicker({
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true
            });

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
