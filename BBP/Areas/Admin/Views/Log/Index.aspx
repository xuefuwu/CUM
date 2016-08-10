<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    日志列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>系统日志</h5>

                        <%--<a class="btn btn-primary pull-right col-sm-offset-2" style="margin-top:-8px;" href="/Log/Create">添加日志</a>--%>
                    </div>
                    <div class="ibox-content no-padding">
                        <div class="panel-body">
                            <div class="panel-group" id="version">
                                <% foreach (var m in (IEnumerable<BBP.Log>)Model)
                                   { %>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#version" href="index.html#v22">
                                                <%: m.Logger %></a><code class="pull-right"><%: m.LogTime.ToString("d") %></code>
                                        </h5>
                                    </div>
                                    <div id="v22" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <%:m.Message %>
                                        </div>
                                    </div>
                                </div>
                                <%} %>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        $(document).ready(function () {
            $('.dataTables').dataTable();
        });
    </script>
</asp:Content>
