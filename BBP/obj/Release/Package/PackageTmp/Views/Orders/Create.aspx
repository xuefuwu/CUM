<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<BBP.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Order</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.OrderNo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.OrderNo) %>
            <%: Html.ValidationMessageFor(model => model.OrderNo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.SN) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.SN) %>
            <%: Html.ValidationMessageFor(model => model.SN) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.MachineSN) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.MachineSN) %>
            <%: Html.ValidationMessageFor(model => model.MachineSN) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Fault) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Fault) %>
            <%: Html.ValidationMessageFor(model => model.Fault) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Position) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Position) %>
            <%: Html.ValidationMessageFor(model => model.Position) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Status) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Status) %>
            <%: Html.ValidationMessageFor(model => model.Status) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Paid) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Paid) %>
            <%: Html.ValidationMessageFor(model => model.Paid) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Guarantee) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Guarantee) %>
            <%: Html.ValidationMessageFor(model => model.Guarantee) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Receive) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Receive) %>
            <%: Html.ValidationMessageFor(model => model.Receive) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Created) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Created) %>
            <%: Html.ValidationMessageFor(model => model.Created) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
