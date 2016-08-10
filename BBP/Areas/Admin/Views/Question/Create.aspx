<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    新增问题
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <div class="col-md-12">
        <div class="form-group">
            <label class="col-sm-3 control-label">标题：</label>
            <div class="col-sm-9">
                <input type="text" name="Title" class="form-control" placeholder="请输入文本">
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">问题描述：</label>
            <div class="col-sm-9">
                <textarea name="Description" class="form-control" placeholder="请输入文本"> </textarea>
            </div>
        </div>
        
        <div class="form-group">
            <label class="col-sm-3 control-label">分值：</label>
            <div class="col-sm-9">
                <input type="text" name="Score" class="form-control" placeholder="请输入文本">
            </div>
        </div>
        
        <div class="form-group">
            <label class="col-sm-3 control-label">排序：</label>
            <div class="col-sm-9">
                <input type="text" name="SortBy" class="form-control" placeholder="请输入文本">
            </div>
        </div>

    </div>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
        <script>
            $(document).ready(function () {
                $(".btn-submit").click(function () {
                    $("form").attr("action", "/Admin/Question/Create");
                    $("form").submit();
                });
            });
    </script>
</asp:Content>
