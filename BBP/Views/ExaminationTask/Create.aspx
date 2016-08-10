<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    发布新的任务
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <link href="/css/plugins/datapicker/datepicker3.css" rel="stylesheet">
    <link href="/css/plugins/chosen/chosen.css" rel="stylesheet">
    <link href="/css/plugins/iCheck/custom.css" rel="stylesheet">
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">标题：</label>
            <div class="col-sm-9 input-group">
                <input type="text" name="Title" id="Title" class="form-control" placeholder="请输入任务标题">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">截至时间：</label>
            <div class="col-sm-9 input-group date">
                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                <input type="text" name="DueDate" id="DueDate" class="form-control" placeholder="请输入截至时间">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">考核对象：</label>
            <div class="col-sm-9 input-group">

                <select name="ExamineeIds" id="ExamineeIds" data-placeholder="选择考核对象" class="chosen-select form-control" multiple>
                    <% foreach (BBP.Examinee e in (ICollection<BBP.Examinee>)ViewData["Examinees"])
                       {
                    %>
                    <option value="<%:e.ID %>"><%:e.Name %></option>
                    <%  } %>
                </select>
            </div>
        </div>
        <div class="form-group">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>选择考核范围</h5>
                </div>
                <div class="ibox-content">

                    <div class="table-responsive">
                        <table class="table table-striped">
                            <thead>
                                <tr>

                                    <th></th>
                                    <th width="80%">标题</th>
                                    <th>分值</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (BBP.Question q in (ICollection<BBP.Question>)ViewData["Questions"])
                                   {
                                %>
                                <tr>
                                    <td>
                                        <input type="checkbox" class="i-checks" name="Question" value="<%:q.ID %>">
                                    </td>
                                    <td><%:q.Title %></td>
                                    <td>
                                        <input type="text" name="QuestionScore" value="<%: q.Score %>" />
                                    </td>
                                </tr>
                                <%   } %>
                            </tbody>
                        </table>
                    </div>

                </div>
            </div>
        </div>


    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    发布考核任务
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <!-- Data picker -->
    <script src="/js/plugins/datapicker/bootstrap-datepicker.js"></script>
    <!-- Chosen -->
    <script src="/js/plugins/chosen/chosen.jquery.js"></script>
    <!-- iCheck -->
    <script src="/js/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('.i-checks').iCheck({
                checkboxClass: 'icheckbox_square-green',
                radioClass: 'iradio_square-green'
            });
            $(".btn-submit").click(function () {
                $("form").attr("action", "/ExaminationTask/Create");
                $("form").submit();
            });
            $('#DueDate').datepicker({
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
