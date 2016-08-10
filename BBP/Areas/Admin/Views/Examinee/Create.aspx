<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    创建考核对象
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">考核对象类型：</label>
            <div class="col-sm-9">
                <select id="ExamineeType.ID" name="ExamineeType.ID" class="chosen-select form-control">
                    <option></option>
                    <%
                        if (ViewData["ExamineeTypeList"] != null)
                        {
                            foreach (var t in (IEnumerable<BBP.ExamineeType>)ViewData["ExamineeTypeList"])
                            {
                    %>
                    <option value="<%: t.ID %>" <%if (((BBP.ExamineeType)ViewData["ExamineeType"]).ID == t.ID)
                                                  {%>selected="selected"
                        <%}%>><%: t.TypeName %></option>
                    <%
                            }
                        }
                    %>
                </select>
            </div>
        </div>

        <% if (ViewData["ExamineeType"] != null)
           {
               ICollection<BBP.ETAttr> etAttrs = ((BBP.ExamineeType)ViewData["ExamineeType"]).ExtAttrs.OrderBy(t=>t.SortBy).ToList();
               foreach (var m in etAttrs)
               {
                   switch (m.ValueType.ID)
                   {
                       case 1:
        %>
        <div class="form-group">
            <label class="col-sm-3 control-label"><%: m.AttrText %>：</label>
            <div class="col-sm-9">
                <input type="text" id="<%: m.AttrName %>" name="<%: m.AttrName %>" class="form-control" placeholder="请输入数字">
            </div>
        </div>
        <%
                           break;
                       case 2:
        %>
        <div class="form-group">
            <label class="col-sm-3 control-label"><%: m.AttrText %>：</label>
            <div class="col-sm-9">
                <input type="text" id="<%: m.AttrName %>" name="<%: m.AttrName %>" class="form-control" placeholder="请输入文本">
            </div>
        </div>
        <%
                           break;
                       case 3:
        %>
        <div class="form-group">
            <label class="col-sm-3 control-label"><%: m.AttrText %>：</label>
            <div class="col-sm-9">
                <input type="text" id="<%: m.AttrName %>" name="<%: m.AttrName %>" class="form-control" placeholder="请输入文本">
            </div>
        </div>
        <%
                           break;
                       case 4:
        %>
        <div class="form-group">
            <label class="col-sm-3 control-label"><%: m.AttrText %>：</label>
            <div class="col-sm-9">
                <select id="<%: m.AttrName %>" name="<%: m.AttrName %>" class="form-control">
                    <% foreach (var str in m.AttrValue.Split(new char[] {'\r', '\n'}))
                       {
                    %>
                    <option><%:str %></option>
                    <%
                       } 
                    %>
                </select>
            </div>
        </div>
        <%                           
                           break;
                       case 5:
        %>
        <div class="form-group">
            <label class="col-sm-3 control-label"><%: m.AttrText %>：</label>
            <div class="col-sm-9">
                <select id="<%: m.AttrName %>" name="<%: m.AttrName %>" class="form-control" multiple>
                    <% foreach (var str in m.AttrValue.Split(new char[] {'\r', '\n'}))
                       {
                    %>
                    <option><%:str %></option>
                    <%
                       } 
                    %>
                </select>
            </div>
        </div>
        <% 
                           break;
                       default:
        %>
        <div class="form-group">
            <label class="col-sm-3 control-label"><%: m.AttrText %>：</label>
            <div class="col-sm-9">
                <input type="text" id="<%: m.AttrName %>" name="<%: m.AttrName %>" class="form-control" placeholder="请输入文本">
            </div>
        </div>
        <%
        break;
                   }

               }
           }
        %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ExtendContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <script src="/js/plugins/editableSelect/jquery.editable.select.min.js"></script>
    <script>
        $(document)
            .ready(function () {
                $('#editable-select')
                    .editableSelect();
                $("#examineetype")
                .change(function () {
                    window.location.href = "/Admin/Examinee/Create?typeId=" + $(this).children('option:selected').val();
                });
                $(".btn-submit")
                    .click(function() {
                        $("form").attr("action", "/Admin/Examinee/Create");
                        $("form").submit();
                    });
            });
    </script>
</asp:Content>
