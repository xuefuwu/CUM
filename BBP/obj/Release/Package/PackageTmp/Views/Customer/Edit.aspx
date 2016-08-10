<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑客户信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<link href="../../css/plugins/datapicker/datepicker3.css" rel="stylesheet">
<link href="../../css/plugins/summernote/summernote.css" rel="stylesheet">
<link href="../../css/plugins/summernote/summernote-bs3.css" rel="stylesheet">
<link href="../../css/plugins/switchery/switchery.css" rel="stylesheet">
<div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>编辑客户信息</h2>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
<div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-6">
                <div class="ibox float-e-margins">
                        <form method="post" action="/Customer/Edit" class="form-horizontal">
                            <% BBP.Customer Customer = (BBP.Customer)Model; %>
                            <input type="hidden" name="ID" id="ID" value="<%: Customer.ID %>" />
                            <div class="form-group">
                                <label class="col-sm-2 control-label">客户姓名</label>
                                <div class="input-group col-sm-10">
                                    <input type="text" class="form-control" id="Name" name="Name" value="<%: Customer.Name %>">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">电话</label>
                                <div class="input-group col-sm-10">
                                    <input type="text" class="form-control" id="TeleNum" name="TeleNum" value="<%: Customer.TeleNum %>">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">邮箱</label>
                                <div class="input-group col-sm-10">
                                    <input type="text" class="form-control" id="Email" name="Email" value="<%: Customer.Email %>">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">是否企业客户</label>
                                <div class="input-group col-sm-10">
                                    <input type="checkbox" class="js-switch-Business" id="Business" name="Business" />
                                    <input class="hidden-Business" type="hidden" value="<%: Customer.Business %>">
                                </div>
                            </div>

                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <button class="btn btn-primary btn-submit" type="button">保存内容</button>
                                    <button class="btn btn-white" type="reset">取消</button>
                                </div>
                            </div>
                        </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
            <!-- Input Mask-->
    <script src="../../js/plugins/jasny/jasny-bootstrap.min.js"></script>

    <!-- Data picker -->
    <script src="../../js/plugins/datapicker/bootstrap-datepicker.js"></script>
    <!-- SUMMERNOTE -->
    <script src="../../js/plugins/summernote/summernote.min.js"></script>
    <script src="../../js/plugins/summernote/summernote-zh-CN.js"></script>
        <!-- Switchery -->
    <script src="../../js/plugins/switchery/switchery.js"></script>

    <!-- IonRangeSlider -->
    <script src="../../js/plugins/ionRangeSlider/ion.rangeSlider.min.js"></script>

    <!-- iCheck -->
    <script src="../../js/plugins/iCheck/icheck.min.js"></script>
<script>
    $(document).ready(function () {
        if ($(".hidden-Business").val() == "True") {
            $('.js-switch-Business').prop('checked', true);
        }
        var elem = document.querySelector('.js-switch-Business');
        var switchery = new Switchery(elem, {
            color: '#1AB394'
        });

        $(".btn-submit").click(function () {
            if ($("#Business").val() == "on") {
                $("#Business").val("True");
            } else {
                $("#Business").val("False");
            }
            $("form").submit();
        });

    });
</script>
</asp:Content>
