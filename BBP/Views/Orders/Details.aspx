<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<BBP.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Order</legend>

    <div class="display-label">OrderNo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.OrderNo) %>
    </div>

    <div class="display-label">SN</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.SN) %>
    </div>

    <div class="display-label">MachineSN</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.MachineSN) %>
    </div>

    <div class="display-label">Fault</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Fault) %>
    </div>

    <div class="display-label">Position</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Position) %>
    </div>

    <div class="display-label">Status</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Status) %>
    </div>

    <div class="display-label">Paid</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Paid) %>
    </div>

    <div class="display-label">Guarantee</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Guarantee) %>
    </div>

    <div class="display-label">Receive</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Receive) %>
    </div>

    <div class="display-label">Created</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Created) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
