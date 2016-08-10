<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑属性类型
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
<% BBP.AttrType at = (BBP.AttrType)Model; %>
    <input type="hidden" name="ID" value="<%:at.ID %>" />
    <div class="col-md-6">
    <div class="form-group">
        <label class="col-sm-3 control-label">属性类型名称：</label>
        <div class="col-sm-9">
            <input type="text" name="TypeName" class="form-control" placeholder="请输入文本" value="<%:at.TypeName %>">
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    编辑属性类型
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        $(document).ready(function () {
            $(".btn-submit").click(function () {
                $("form").attr("action", "/Admin/AttrType/Edit");
                $("form").submit();
            });
        });
</script>
</asp:Content>
