<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    创建属性类型
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">属性类型名称：</label>
            <div class="col-sm-9">
                <input type="text" name="TypeName" class="form-control" placeholder="请输入文本">
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
                    <label><input type="radio" name="ValueType" value="<%=vt.ID %>"><%=vt.ValueTypeName %></label>
                </div>
                <%
                    }
                %>
            </div>

        </div>
    </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    创建属性类型
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        $(document).ready(function () {
            $(".btn-submit").click(function () {
                $("form").attr("action", "/Admin/AttrType/Create");
                $("form").submit();
            });
        });
    </script>
</asp:Content>
