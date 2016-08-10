<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑权限
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainTitle" runat="server">

编辑权限

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FormContent" runat="server">
    <% BBP.Role t = (BBP.Role)Model; %>
    <div class="col-md-12">
        <input type="hidden" value="<%:t.ID %>" name="ID" />
    <div class="form-group">
        <label class="col-sm-3 control-label">权限名称：</label>
        <div class="col-sm-9">
            <input type="text" name="Name" class="form-control" placeholder="请输入文本" value="<%:t.Name %>">
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">备注信息：</label>
        <div class="col-sm-9">
            <textarea name="Remark" class="form-control" placeholder="请输入文本"><%:t.Remark %> </textarea>

        </div>
    </div>
</div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script>
    $(document).ready(function () {
        $(".btn-submit").click(function () {
            $("form").attr("action", "/Admin/Role/Edit");
            $("form").submit();
        });
    });
</script>
</asp:Content>
