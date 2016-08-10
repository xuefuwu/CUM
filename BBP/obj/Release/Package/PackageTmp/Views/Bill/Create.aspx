<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加费用
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
        <link href="/css/plugins/datapicker/datepicker3.css" rel="stylesheet">
    <link href="/css/plugins/chosen/chosen.css" rel="stylesheet">
<div class="col-md-12">
    <div class="form-group">
        <label class="col-sm-3 control-label">订单号：</label>
        <div class="col-sm-9">
            <input type="text" name="Order.OrderNo" class="form-control" placeholder="请输入订单号">

        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">费用类型：</label>
        <div class="col-sm-9">
            <input type="text" name="Type" class="form-control" placeholder="请输入费用类型">

        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">金额：</label>
        <div class="col-sm-9">
            <input type="text" name="Amount" class="form-control" placeholder="请输入金额">

        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">经手人：</label>
        <div class="col-sm-9">
                <select name="person.ID" data-placeholder="选择人员..." class="chosen-select" style="width: 350px;" tabindex="2">
                    <%BBP.User currentUser = Session["CurrentUser"] as BBP.User; %>
                    <option value="<%:currentUser.ID %>"><%:currentUser.ChineseName %></option>
                    <%if (((List<BBP.User>)ViewData["Users"]).Count > 0)
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

    <div class="form-group" id="data_1">
        <label class="col-sm-3 control-label">付款时间：</label>
        <div class="col-sm-9 input-group date">
            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
            <input type="text" name="Created" id="Created" class="form-control" placeholder="请输入日期">

        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
添加费用
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
        <!-- Data picker -->
    <script src="/js/plugins/datapicker/bootstrap-datepicker.js"></script>
        <!-- Chosen -->
    <script src="/js/plugins/chosen/chosen.jquery.js"></script>

    <script>
        $(document).ready(function () {
            $(".btn-submit").click(function () {
                $("form").attr("action", "/Bill/Create");
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
