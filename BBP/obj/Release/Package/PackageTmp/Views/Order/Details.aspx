<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    查看维修单
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <% BBP.Order o = (BBP.Order)Model; %>
    <input type="hidden" name="ID" id="ID" value="<%: o.ID %>" />
    <div class="col-md-6">
        <div class="form-group" id="Div1">
            <label class="col-sm-3 label">所属维修站</label>
            <label class="col-sm-9">
                <%: o.Dept.Name %>
            </label>
        </div>

        <div class="form-group" id="data_1">
            <label class="col-sm-3 label">订单日期</label>
            <label class="col-sm-9">
                <%: o.Created.ToString("d") %>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">单号</label>
            <label class="col-sm-9">
                <%: o.OrderNo %>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">流水号</label>
            <label class="col-sm-9">
                <%: o.SN %>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">设备序列号</label>
            <label class="col-sm-9">
                <%: o.MachineSN %>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">设备型号</label>
            <label class="col-sm-9">
                <%: o.MachineModel %>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">故障现象</label>
            <label class="col-sm-9">
                <%:o.Fault %>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">客户姓名</label>
            <label class="col-sm-9">
                <%: o.Customer.Name %>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">电话</label>
            <label class="col-sm-9">
                <%: o.Customer.TeleNum %>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">机位</label>
            <label class="col-sm-9">
                <%: o.Position %>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">保修状态</label>
            <label class="col-sm-9">
                <%: o.Guarantee%>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">维修状态</label>
            <label class="col-sm-9">
                <%: o.Status%>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">是否结单</label>
            <label class="col-sm-9">
                <%: o.Paid%>
            </label>
        </div>
        <div class="form-group">
            <label class="col-sm-3 label">是否取件</label>
            <label class="col-sm-9">
                <%: o.Receive%>
            </label>
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
                    <a class="detail-add" href="/RepairDetail/Add?id=<%: ((BBP.Order)Model).ID %>&returnAction=Details">
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
                    <a class="detail-add" href="/Bill/Add?id=<%: ((BBP.Order)Model).ID %>&returnAction=Details">
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

    <script>
        $(document).ready(function () {

        });
    </script>
</asp:Content>
