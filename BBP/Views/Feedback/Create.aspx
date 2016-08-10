<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Forms.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    提交整改报告
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/plugins/webuploader/webuploader.css">
    <link rel="stylesheet" type="text/css" href="/css/demo/webuploader-demo.css">
    <link href="/css/plugins/summernote/summernote.css" rel="stylesheet">
    <link href="/css/plugins/summernote/summernote-bs3.css" rel="stylesheet">
    <div class="col-md-12 gray-bg">
        <div class="form-group">
            <label class="col-sm-3 control-label">报告内容：</label>
            <div class="col-sm-12 input-group">
                <div class="summernote">
                </div>
            </div>
        </div>
        <div class="form-group">
            <div id="uploader" class="wu-example">
                <div class="queueList">
                    <div id="dndArea" class="placeholder">
                        <div id="filePicker"></div>
                        <p>或将照片拖到这里，单次最多可选300张</p>
                    </div>
                </div>
                <div class="statusBar" style="display: none;">
                    <div class="progress">
                        <span class="text">0%</span>
                        <span class="percentage"></span>
                    </div>
                    <div class="info"></div>
                    <div class="btns">
                        <div id="filePicker2"></div>
                        <div class="uploadBtn">开始上传</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ExtendContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <!-- Web Uploader -->
    <script type="text/javascript">
        // 添加全局站点信息
        var BASE_URL = '/js/plugins/webuploader';
    </script>
    <script src="/js/plugins/webuploader/webuploader.min.js"></script>

    <script src="/js/demo/webuploader-demo.js"></script>
    <!-- SUMMERNOTE -->
    <script src="/js/plugins/summernote/summernote.min.js"></script>
    <script src="/js/plugins/summernote/summernote-zh-CN.js"></script>
    <script>
        $(document).ready(function () {

            $('.summernote').summernote({
                lang: 'zh-CN'
            });

        });
    </script>
</asp:Content>
