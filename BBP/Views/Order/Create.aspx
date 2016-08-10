<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加维修单
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/css/plugins/datapicker/datepicker3.css" rel="stylesheet">
    <link href="/css/plugins/chosen/chosen.css" rel="stylesheet">

    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>添加维修单</h2>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-6">
                <div class="ibox float-e-margins">
                    <form method="post" action="/Order/Create" class="form-horizontal">
                        <div class="form-group" id="data_1">
                            <label class="col-sm-2 control-label">订单日期</label>
                            <div class="input-group date col-sm-10">
                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                <input type="text" class="form-control" value="<%: DateTime.Now.ToString("d") %>" id="Created" name="Created">
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label">单号</label>
                            <div class="input-group col-sm-10">
                                <input type="text" class="form-control" id="OrderNo" name="OrderNo">
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label">流水号</label>
                            <div class="input-group col-sm-10">
                                <input type="text" class="form-control" id="SN" name="SN">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">设备序列号</label>
                            <div class="input-group col-sm-10">
                                <input type="text" class="form-control" id="MachineSN" name="MachineSN">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">设备型号</label>
                            <div class="input-group col-sm-10">
                                <input type="text" class="form-control" id="MachineModel" name="MachineModel">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">故障现象</label>
                            <div class="input-group col-sm-10">
                                <textarea class="form-control" id="Fault" name="Fault"></textarea>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">客户姓名</label>
                            <div class="input-group col-sm-10">
                                <input type="text" class="form-control" id="Customer.Name" name="Customer.Name">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">电话</label>
                            <div class="input-group col-sm-10">
                                <input type="text" class="form-control" id="Custmer.TeleNum" name="Customer.TeleNum">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">邮箱</label>
                            <div class="input-group col-sm-10">
                                <input type="text" class="form-control" id="Customer.Email" name="Customer.Email">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">机位</label>
                            <div class="input-group col-sm-10">
                                <select id="Position" name="Position" data-placeholder="选择位置..." class="chosen-select" style="width: 350px;" tabindex="2">
                                    <option value="">请选择位置</option>
                                    <% foreach (String u in (List<String>)ViewData["Store"])
                                       { %>
                                    <option value="<%:u %>" hassubinfo="true"><%:u %></option>
                                    <%} %>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">保修状态</label>
                            <div class="input-group col-sm-10">
                                <label class="radio-inline" for="GuaranteeYes">
                                    <input type="radio" value="保内" id="GuaranteeYes" name="Guarantee">保内</label>
                                <label class="radio-inline" for="GuaranteeNo">
                                    <input type="radio" value="保外" id="GuaranteeNo" name="Guarantee">保外</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">费用明细</label>
                            <div class="input-group col-sm-10">
                                <input type="text" class="form-control" id="BillName" name="OrderBill.Type">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">费用金额</label>
                            <div class="input-group col-sm-10">
                                <input type="number" class="form-control" id="BillAmount" name="OrderBill.Amount">
                            </div>
                        </div>
                        <input type="hidden" value="<%: (Session["CurrentUser"]as BBP.User).ID %>" name="Creator.ID" />
                        <div class="hr-line-dashed"></div>
                        <div class="form-group">
                            <div class="col-sm-4 col-sm-offset-2">
                                <button class="btn btn-primary btn-submit" type="button">保存内容</button>
                                <button class="btn btn-white" type="reset">取消</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <!-- Input Mask-->
    <script src="../../js/plugins/jasny/jasny-bootstrap.min.js"></script>

    <!-- Data picker -->
    <script src="../../js/plugins/datapicker/bootstrap-datepicker.js"></script>

    <!-- Chosen -->
    <script src="/js/plugins/chosen/chosen.jquery.js"></script>

    <script>
        $(document).ready(function () {
            $(".btn-submit").click(function () {
                $("form").submit();
            })
            $('#data_1 .input-group.date').datepicker({
                format: 'yyyy/mm/dd',
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true
            });
            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': {
                    allow_single_deselect: true
                },
                '.chosen-select-no-single': {
                    disable_search_threshold: 10
                },
                '.chosen-select-no-results': {
                    no_results_text: 'Oops, nothing found!'
                },
                '.chosen-select-width': {
                    width: "95%"
                }
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }
        });
    </script>
</asp:Content>
