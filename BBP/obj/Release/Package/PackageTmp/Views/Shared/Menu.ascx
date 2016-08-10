<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%: Html.MenuActionLink("fa fa-th-large","维修单","Index","Order") %>
<%: Html.MenuActionLink("fa fa-group","维修费用","Index","Bill") %>
<%: Html.MenuActionLink("fa fa-group","维修明细","Index","RepairDetail") %>
<%: Html.MenuActionLink("fa fa-group","客户信息","Index","Customer") %>
<%: Html.AdminMenuActionLink("fa fa-group","系统管理","Index","Admin") %>