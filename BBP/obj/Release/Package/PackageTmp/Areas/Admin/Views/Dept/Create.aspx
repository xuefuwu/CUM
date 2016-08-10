<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    新增部门
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">部门名称：</label>
            <div class="col-sm-9">
                <input type="text" name="Name" class="form-control" placeholder="请输入文本">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">所属部门：</label>
            <div class="col-sm-9">
                <select class="form-control" name="Parent.ID">
                    <% foreach (BBP.Dept t in (List<BBP.Dept>)ViewData["deptList"])
                       { %>
                    <option value="<%:t.ID %>"><%:t.Name %></option>
                    <%} %>
                </select>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-3 control-label">备注信息：</label>
            <div class="col-sm-9">
                <textarea name="Remark" class="form-control" placeholder="请输入文本"> </textarea>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
    添加部门
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        $(document).ready(function () {
            $(".btn-submit").click(function () {
                $("form").attr("action", "/Admin/Dept/Create");
                $("form").submit();
            });
        });
    </script>
</asp:Content>
