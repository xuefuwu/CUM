<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    创建考核对象
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">考核对象类型：</label>
            <div class="col-sm-9 input-group">
                <select id="examineetype" class="chosen-select form-control">
                    <option></option>
                    <%
                        if (ViewData["ExamineeTypeList"] != null)
                        {
                            foreach (var t in (IEnumerable<BBP.ExamineeType>)ViewData["ExamineeTypeList"])
                            {
                    %>
                    <option value="<%: t.ID %>"><%: t.TypeName %></option>
                    <%
                            }
                        }
                    %>
                </select>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ExtendContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        $(document).ready(function () {
            $("#examineetype")
                .change(function () {
                    window.location.href = "/Admin/Examinee/Create?typeId=" + $(this).children('option:selected').val();
                });
        });
    </script>
</asp:Content>
