<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BBP.Order>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            OrderNo
        </th>
        <th>
            SN
        </th>
        <th>
            MachineSN
        </th>
        <th>
            Fault
        </th>
        <th>
            Position
        </th>
        <th>
            Status
        </th>
        <th>
            Paid
        </th>
        <th>
            Guarantee
        </th>
        <th>
            Receive
        </th>
        <th>
            Created
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: item.OrderNo %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.SN) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.MachineSN) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Fault) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Position) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Status) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Paid) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Guarantee) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Receive) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Created) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.ID }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.ID }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.ID }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
