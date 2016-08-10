<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    创建属性
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <link href="/css/plugins/chosen/chosen.css" rel="stylesheet">
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">属性名称：</label>
            <div class="col-sm-9">
                <input type="text" name="AttrName" class="form-control" placeholder="请输入文本">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">属性值：</label>
            <div class="col-sm-9">
                <input type="text" name="AttrValue" class="form-control" placeholder="请输入文本">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">属性类型：</label>
            <div class="input-group col-sm-9">
                <select id="AttrType" name="AttrType" data-placeholder="选择位置..." class="chosen-select" style="width: 350px;" tabindex="2">
                    <option value="">请选择属性类型</option>
                    <% foreach (BBP.AttrType at in (List<BBP.AttrType>)ViewData["AttrTypes"])
                       { %>
                    <option value="<%:at.ID %>" hassubinfo="true"><%:at.TypeName %></option>
                    <%} %>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">数据类型：</label>
            <div class="col-sm-9">
                <% 
                    List<BBP.ValueType> vtList = (List<BBP.ValueType>)ViewData["ValueType"];
                    foreach (BBP.ValueType vt in vtList)
                    {
                %>
                <div class="radio">
                    <label>
                        <input type="radio" name="ValueType" value="<%=vt.ID %>"><%=vt.ValueTypeName %></label>
                </div>
                <%
                    }
                %>
            </div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    创建属性
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <!-- Chosen -->
    <script src="/js/plugins/chosen/chosen.jquery.js"></script>
    <script>
        $(document).ready(function () {
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
            };
            $(".btn-submit").click(function () {
                $("form").submit();
            });
        });
    </script>
</asp:Content>
