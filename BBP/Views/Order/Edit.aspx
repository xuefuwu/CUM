<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑维修单
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <link href="/css/plugins/datapicker/datepicker3.css" rel="stylesheet">
    <link href="/css/plugins/chosen/chosen.css" rel="stylesheet">
    <% BBP.Order o = (BBP.Order)Model; %>
    <input type="hidden" name="ID" id="ID" value="<%: o.ID %>" />
    <div class="col-md-6">
        <div class="form-group" id="data_1">
            <label class="col-sm-3 control-label">订单日期</label>
            <div class="input-group date col-sm-9">
                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                <input type="text" class="form-control" value="<%: o.Created.ToString("d") %>" id="Created" name="Created">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">单号</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="OrderNo" name="OrderNo" value="<%: o.OrderNo %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">流水号</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="SN" name="SN" value="<%: o.SN %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">设备序列号</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="MachineSN" name="MachineSN" value="<%: o.MachineSN %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">设备型号</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="MachineModel" name="MachineModel" value="<%: o.MachineModel %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">故障现象</label>
            <div class="input-group col-sm-9">
                <textarea class="form-control" name="Fault" id="Fault"><%:o.Fault %></textarea>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">客户姓名</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="Customer.Name" name="Customer.Name" value="<%: o.Customer.Name %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">电话</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="Custmer.TeleNum" name="Customer.TeleNum" value="<%: o.Customer.TeleNum %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">邮箱</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="Customer.Email" name="Customer.Email" value="<%: o.Customer.Email %>">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">机位</label>
            <div class="input-group col-sm-9">
                <select id="Position" name="Position" data-placeholder="选择位置..." class="chosen-select" style="width: 350px;" tabindex="2">
                    <option value="<%:o.Position %>"><%:o.Position %></option>
                    <% foreach (String u in (List<String>)ViewData["Store"])
                       { %>
                    <option value="<%:u %>" hassubinfo="true"><%:u %></option>
                    <%} %>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">保修状态</label>
            <div class="input-group col-sm-9">
                <label class="radio-inline" for="GuaranteeYes">
                    <input type="radio" value="保内" id="GuaranteeYes" name="Guarantee">保内</label>
                <label class="radio-inline" for="GuaranteeNo">
                    <input type="radio" value="保外" id="GuaranteeNo" name="Guarantee">保外</label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">维修状态</label>
            <div class="input-group col-sm-9">
                <label class="radio-inline" for="StatusUnChecked">
                    <input type="radio" value="待检" id="StatusUnChecked" name="Status">待检</label>
                <label class="radio-inline" for="StatusChecked">
                    <input type="radio" value="已检验" id="StatusChecked" name="Status">已检验</label>
                <label class="radio-inline" for="CheckRepair">
                    <input type="radio" value="同意报价" id="CheckRepair" name="Status">同意报价</label>
                <label class="radio-inline" for="StatusDOA">
                    <input type="radio" value="DOA" id="StatusDOA" name="Status">DOA</label>
                <label class="radio-inline" for="StatusAdd">
                    <input type="radio" value="追加料件" id="StatusAdd" name="Status">追加料件</label>
                <label class="radio-inline" for="Change">
                    <input type="radio" value="换机" id="Change" name="Status">换机</label>
                <label class="radio-inline" for="StatusCompleted">
                    <input type="radio" value="完修" id="StatusCompleted" name="Status">完修</label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">是否结单</label>
            <div class="input-group col-sm-9">
                <label class="radio-inline" for="PaidNo">
                    <input type="radio" value="未结单" id="PaidNo" name="Paid">未结单</label>
                <label class="radio-inline" for="PaidYes">
                    <input type="radio" value="已结单" id="PaidYes" name="Paid">已结单</label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">是否取件</label>
            <div class="input-group col-sm-9">
                <label class="radio-inline" for="ReceiveNo">
                    <input type="radio" value="未取件" id="ReceiveNo" name="Receive">未取件</label>
                <label class="radio-inline" for="ReceiveYes">
                    <input type="radio" value="已取件" id="ReceiveYes" name="Receive">已取件</label>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ExtendContent" runat="server">
    <div class="col-md-6">
        <div class="ibox float-e-margins">
            <div class="ibox-title">
                <h5>维修记录</h5>
                <div class="ibox-tools">
                    <a class="collapse-link">
                        <i class="fa fa-chevron-up"></i>
                    </a>
                    <a class="detail-add" href="/RepairDetail/Add?id=<%: ((BBP.Order)Model).ID %>&returnAction=Edit">
                        <i class="fa fa-plus"></i>
                    </a>
                </div>
            </div>
            <div class="ibox-content no-padding">
                <ul class="list-group">
                    <% foreach (var detail in (IEnumerable<BBP.RepairDetail>)Model.Details)
                       { %>
                    <li class="list-group-item">
                        <p><%:detail.RepairContent %></p>
                        <small class="block text-muted"><i class="fa fa-clock-o"></i><%:detail.RepairDate.HasValue?detail.RepairDate.Value.ToString("d"):"" %> <i class="fa fa-user"></i><%:detail.Engineer.ChineseName %></small>
                    </li>
                    <%} %>
                </ul>
            </div>
        </div>
    </div>
    <div class="col-md-6">
        <div class="ibox float-e-margins">
            <div class="ibox-title">
                <h5>费用记录</h5>
                <div class="ibox-tools">
                    <a class="collapse-link">
                        <i class="fa fa-chevron-up"></i>
                    </a>
                    <a class="detail-add" href="/Bill/Add?id=<%: ((BBP.Order)Model).ID %>&returnAction=Edit">
                        <i class="fa fa-plus"></i>
                    </a>
                </div>
            </div>
            <div class="ibox-content no-padding">
                <ul class="list-group">
                    <% foreach (var bill in ((BBP.Order)Model).Bills)
                       { %>
                    <li class="list-group-item">
                        <p><%:bill.Type %>:<%:bill.Amount %></p>
                        <small class="block text-muted"><i class="fa fa-clock-o"></i><%:bill.Created.HasValue?bill.Created.Value.ToString("d"):"" %> <i class="fa fa-user"></i><%:bill.person.ChineseName %></small>
                    </li>
                    <%} %>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <% BBP.Order o = (BBP.Order)Model; %>
    <!-- Input Mask-->
    <script src="../../js/plugins/jasny/jasny-bootstrap.min.js"></script>

    <!-- Data picker -->
    <script src="../../js/plugins/datapicker/bootstrap-datepicker.js"></script>
    <!-- Chosen -->
    <script src="/js/plugins/chosen/chosen.jquery.js"></script>


    <script>
        $(document).ready(function () {
            $("input[type='radio'][name='Guarantee'][value='<%:o.Guarantee%>']").prop("checked", true);
            $("input[type='radio'][name='Status'][value='<%:o.Status==null?"待检":o.Status%>']").prop("checked", true);
            $("input[type='radio'][name='Paid'][value='<%:o.Paid==null?"未结单":o.Paid%>']").prop("checked", true);
            $("input[type='radio'][name='Receive'][value='<%:o.Receive==null?"未取件":o.Receive%>']").prop("checked", true);
            $(".btn-submit").click(function () {
                $("form").submit();
            });

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
