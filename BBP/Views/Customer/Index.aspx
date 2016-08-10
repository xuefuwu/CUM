<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    客户清单
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>客户清单</h2>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <a class="btn btn-primary" href="/Customer/Create">新增</a>
                    </div>
                    <div class="ibox-content">
                        <table class="table table-striped table-bordered table-hover dataTables">
                            <thead>
                                <tr>
                                    <th>客户姓名</th>
                                    <th>联系电话</th>
                                    <th>企业客户</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var m in (IEnumerable<BBP.Customer>)ViewData["ObjList"])
                                   { %>
                                <tr>
                                    <td><%: m.Name %></td>
                                    <td><%: m.TeleNum %></td>
                                    <td><% if (m.Business)
                                           {%>是<%}
                                           else
                                           { %>否<%} %></td>
                                    <td><%: Html.ActionLink("编辑", "Edit", new { id=m.ID }) %>|<%: Html.ActionLink("删除", "Delete", new { id=m.ID }) %></td>
                                </tr>
                                <% } %>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>客户姓名</th>
                                    <th>联系电话</th>
                                    <th>企业客户</th>
                                    <th>操作</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        function getUrlParam(name) {
            //构造一个含有目标参数的正则表达式对象  
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            //匹配目标参数  
            var r = window.location.search.substr(1).match(reg);
            //返回参数值  
            if (r != null) return r[2];
            return null;
        }
        $(function () {
            $('.dataTables').dataTable();
            if (getUrlParam("ErrorMessage") != null) {
                toastr.error(decodeURI(getUrlParam("ErrorMessage")));
            }
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "onclick": null,
                "showDuration": "400",
                "hideDuration": "1000",
                "timeOut": "7000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };

        });
    </script>
</asp:Content>
