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
                <input type="text" class="form-control" value="<%: o.Created.ToString("d") %>" id="Created" name="Created" readonly="readonly">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">单号</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="OrderNo" name="OrderNo" value="<%: o.OrderNo %>" readonly="readonly">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">流水号</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="SN" name="SN" value="<%: o.SN %>" readonly="readonly">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">设备序列号</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="MachineSN" name="MachineSN" value="<%: o.MachineSN %>" readonly="readonly">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">设备型号</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="MachineModel" name="MachineModel" value="<%: o.MachineModel %>" readonly="readonly">
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
                <input type="text" class="form-control" id="Customer.Name" name="Customer.Name" value="<%: o.Customer.Name %>" readonly="readonly">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">电话</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="Custmer.TeleNum" name="Customer.TeleNum" value="<%: o.Customer.TeleNum %>" readonly="readonly">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">机位</label>
            <div class="input-group col-sm-9">
                <input type="text" class="form-control" id="Position" name="Position" value="<%: o.Position %>" readonly="readonly">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">保修状态</label>
            <div class="input-group col-sm-9">
                <%:o.Guarantee %>
                <input name="Guarantee" value="<%:o.Guarantee %>" type="hidden" />
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
        <!-- 维修明细 -->
        <div class="form-group" id="data_2">
            <label class="col-sm-3 control-label">维修时间：</label>
            <div class="col-sm-9 input-group date">
                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                <input type="text" name="RepairDetail.RepairDate" class="form-control" placeholder="请输入日期">
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-3 control-label">维修工程师：</label>
            <div class="col-sm-9">
                <select name="RepairDetail.Engineer.ID" data-placeholder="选择人员..." class="chosen-select" style="width: 350px;" tabindex="2">
                    <%BBP.User currentUser = Session["CurrentUser"] as BBP.User; %>
                    <option value="<%:currentUser.ID %>"><%:currentUser.ChineseName %></option>
                    <%if (ViewData["Users"]!=null)
                      { %>
                    <% foreach (BBP.User u in (List<BBP.User>)ViewData["Users"])
                       { %>
                    <option value="<%:u.ID %>" hassubinfo="true"><%:u.ChineseName %></option>
                    <%
                      }
                      }
                    %>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">维修内容：</label>
            <div class="col-sm-9">
                <textarea name="RepairDetail.RepairContent" class="form-control" placeholder="请输入文本"></textarea>
            </div>
        </div>
        <!-- 维修明细 -->
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

            $('#data_2 .input-group.date').datepicker({
                format: 'yyyy/mm/dd',
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true
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
