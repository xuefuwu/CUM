<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="JYEntity.main" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>首页</title>
    <link href="res/css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="regionPanel" runat="server" />
        <f:Panel Layout="Region" ID="regionPanel" ShowBorder="false" ShowHeader="false" runat="server">
            <Items>
                <f:ContentPanel ID="topPanel" CssClass="topregion" RegionPosition="Top" ShowBorder="false" ShowHeader="false" EnableCollapse="true" runat="server">
                    <div id="header" class="ui-widget-header f-mainheader">
                        <table>
                            <tr>
                                <td>
                                    <img src="./res/images/login/login_2.png" class="logoimg" alt="Logo" />
                                    <asp:HyperLink ID="linkSystemTitle" CssClass="logo" runat="server" NavigateUrl="~/main.aspx"></asp:HyperLink>
                                </td>
                                <td style="text-align: right;">
                                    <f:Button runat="server" CssClass="icontopaction systemhelp" ID="Button1" Text="下载源代码" IconAlign="Top" EnablePostBack="false">
                                        <Listeners>
                                            <f:Listener Event="click" Handler="onDownloadClick" />
                                        </Listeners>
                                    </f:Button>
                                    <f:Button runat="server" CssClass="icontopaction systemhelp" ID="btnSystemHelp" Text="系统帮助" IconAlign="Top" EnablePostBack="false">
                                    </f:Button>
                                    <f:Button runat="server" CssClass="userpicaction" ID="btnUserName" Text="三生石上" IconUrl="~/res/images/my_face_80.jpg" IconAlign="Left" EnablePostBack="false">
                                        <Menu ID="Menu1" runat="server">
                                            <f:MenuButton ID="btnExit" Text="安全退出" OnClick="btnExit_Click" runat="server">
                                                <Listeners>
                                                    <f:Listener Event="click" Handler="onSignOutClick" />
                                                </Listeners>
                                            </f:MenuButton>
                                        </Menu>
                                    </f:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </f:ContentPanel>
                <f:Panel ID="leftPanel" CssClass="leftregion" RegionSplit="true" EnableCollapse="true" Width="250px"
                    ShowHeader="true" ShowBorder="true" Title="系统菜单" Layout="Fit" RegionPosition="Left" runat="server">
                </f:Panel>
                <f:TabStrip ID="mainTabStrip" RegionPosition="Center" EnableTabCloseMenu="true" CssClass="centerregion" ShowBorder="true" runat="server">
                    <Tabs>
                        <f:Tab ID="Tab1" Title="首页" EnableIFrame="true" IFrameUrl="~/admin/default.aspx"
                            Icon="House" runat="server">
                        </f:Tab>
                    </Tabs>

                </f:TabStrip>
                <f:ContentPanel ID="bottomPanel" CssClass="bottomregion" RegionPosition="Bottom" ShowBorder="false" ShowHeader="false" EnableCollapse="false" runat="server">
                    <table class="bottomtable ui-widget-header f-mainheader">
                        <tr>
                            <td style="width: 200px;">&nbsp;版本：<a target="_blank" href="http://fineui.com/version_pro">v<asp:Literal runat="server" ID="litVersion"></asp:Literal></a>
                            </td>
                            <td style="text-align: center;">Copyright &copy; 2014 合肥三生石上软件有限公司</td>
                            <td style="width: 200px; text-align: right;">在线人数：&nbsp;</td>
                        </tr>
                    </table>
                </f:ContentPanel>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" runat="server" IsModal="true" Hidden="true" EnableIFrame="true"
            EnableResize="true" EnableMaximize="true" IFrameUrl="about:blank" Width="800px"
            Height="500px">
        </f:Window>
    </form>
    <script>

        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var leftPanelClientID = '<%= leftPanel.ClientID %>';
        var topPanelClientID = '<%= topPanel.ClientID %>';
        

        // 下载源代码
        function onDownloadClick() {
            window.open('http://pan.baidu.com/s/1gdAEOPd', '_blank');
        }

        // 点击标题栏工具图标 - 刷新
        function onToolRefreshClick(event) {
            var mainTabStrip = F(mainTabStripClientID);

            var activeTab = mainTabStrip.getActiveTab();
            if (activeTab.iframe) {
                var iframeWnd = activeTab.getIFrameWindow();
                iframeWnd.location.reload();
            }
        }


        // 点击标题栏工具图标 - 最大化
        function onToolMaximizeClick(event) {
            var topPanel = F(topPanelClientID);
            var leftPanel = F(leftPanelClientID);

            var currentTool = this;
            if (currentTool.iconFont.indexOf('expand') >= 0)
            {
                topPanel.collapse();
                leftPanel.collapse();
                currentTool.setIconFont('compress');
            } else {
                topPanel.expand();
                leftPanel.expand();
                currentTool.setIconFont('expand');
            }
        }


        // 公开添加示例标签页的方法
        function addExampleTab(id, url, text, icon, refreshWhenExist) {
            var mainTabStrip = F(mainTabStripClientID);

            // 动态添加一个标签页
            // mainTabStrip： 选项卡实例
            // id： 选项卡ID
            // url: 选项卡IFrame地址 
            // text： 选项卡标题
            // icon： 选项卡图标
            // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            F.addMainTab(mainTabStrip, id, url, text, icon, null, refreshWhenExist);
        };


        // 移出当前激活选项卡
        function removeActiveTab() {
            var mainTabStrip = F(mainTabStripClientID);

            var activeTab = mainTabStrip.getActiveTab();
            mainTabStrip.removeTab(activeTab.id);
        };



        F.ready(function () {

            // 移出顶部按钮的样式（背景色和边框）
            $('#header .f-btn').removeClass('ui-corner-all ui-state-default');


            var mainTabStrip = F(mainTabStripClientID);
            var leftPanel = F(leftPanelClientID);
            var mainMenu = leftPanel.items[0];

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            F.initTreeTabStrip(mainMenu, mainTabStrip, null, true, false, false);


            
            //<div id="f_ajax_loading" class="f-ajax-loading" style="left: 786px; display: block;">正在加载...</div>

        });

    </script>
</body>
</html>
