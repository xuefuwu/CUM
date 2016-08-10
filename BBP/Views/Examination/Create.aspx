<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    提交报告
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <link href="/css/plugins/datapicker/datepicker3.css" rel="stylesheet">
    <link href="/css/plugins/chosen/chosen.css" rel="stylesheet">
    <link href="/css/plugins/iCheck/custom.css" rel="stylesheet">
    <% BBP.ExaminationTask et = (BBP.ExaminationTask)ViewData["ExaminationTask"]; %>
    <input name="TaskId" id="TaskId" value="<%:et.ID %>" type="hidden" />
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">考核对象：</label>
            <div class="col-sm-9 input-group">
                <select name="ExamineeIds" id="ExamineeIds" data-placeholder="选择考核对象" class="chosen-select form-control" multiple>
                    <% foreach (BBP.Examinee e in et.Examinees)
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
                    <h5>考核检查内容</h5>
                </div>
                <div class="ibox-content">

                    <div class="table-responsive">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th width="80%">检查点</th>
                                    <th>是否合格</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (BBP.ExamQuestion q in et.Questions)
                                   {
                                %>
                                <tr>
                                    <td><%:q.Question.Title %></td>
                                    <td>
                                        <input type="radio" name="QuestionResult_<%: q.ID %>" value="true" class="i-checks" />合格
                                        <input type="radio" name="QuestionResult_<%: q.ID %>" value="false" class="i-checks" />不合格
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
    提交报告
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ExtendContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
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
                var qlist = new Array();
                $("input[type='radio']:checked")
                    .each(function() {
                        var idname = $(this).attr("name").split('_')[1];
                        var rowdata = { "ID": idname, "QuestionAnswer": $(this).val() }
                        qlist.push(rowdata);
                    });
                var s = { "TaskId":$("#TaskId").val(),"Examinees": $("#ExamineeIds").val(), "Questions": qlist };
                $.ajax({
                    type: "POST",
                    url: "/Examination/Create",
                    data: String.toSerialize(s),
                    dataType: 'json',
                    async: false,
                    success: function (responseData) {
                        alert(responseData);
                    },
                    error: function (xmlHttpRequest, textStatus, errorThrown) {
                        console.log("请求失败，无法获取分组数据");
                    }
                });
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
        /*对象序列化为字符串*/
        String.toSerialize = function (obj) {
            var ransferCharForJavascript = function (s) {
                var newStr = s.replace(
                /[\x26\x27\x3C\x3E\x0D\x0A\x22\x2C\x5C\x00]/g,
                function (c) {
                    ascii = c.charCodeAt(0)
                    return '\\u00' + (ascii < 16 ? '0' + ascii.toString(16) : ascii.toString(16));
                }
                );
                return newStr;
            }
            if (obj == null) {
                return null;
            }
            else if (obj.constructor == Array) {
                var builder = [];
                builder.push("[");
                for (var index in obj) {
                    if (typeof obj[index] == "function") continue;
                    if (index > 0) builder.push(",");
                    builder.push(String.toSerialize(obj[index]));
                }
                builder.push("]");
                return builder.join("");
            }
            else if (obj.constructor == Object) {
                var builder = [];
                builder.push("{");
                var index = 0;
                for (var key in obj) {
                    if (typeof obj[key] == "function") continue;
                    if (index > 0) builder.push(",");
                    builder.push(String.format("\"{0}\":{1}", key, String.toSerialize(obj[key])));
                    index++;
                }
                builder.push("}");
                return builder.join("");
            }
            else if (obj.constructor == Boolean) {
                return obj.toString();
            }
            else if (obj.constructor == Number) {
                return obj.toString();
            }
            else if (obj.constructor == String) {
                return String.format('"{0}"', ransferCharForJavascript(obj));
            }
            else if (obj.constructor == Date) {
                return String.format('{"__DataType":"Date","__thisue":{0}}', obj.getTime() - (new Date(1970, 0, 1, 0, 0, 0)).getTime());
            }
            else if (this.toString != undefined) {
                return String.toSerialize(obj);
            }
        }
        String.format = function () {

            if (arguments.length == 0) {
                return null;
            }

            var str = arguments[0];

            for (var i = 1; i < arguments.length; i++) {

                var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
                str = str.replace(re, arguments[i]);
            }
            return str;
        }
    </script>
</asp:Content>
