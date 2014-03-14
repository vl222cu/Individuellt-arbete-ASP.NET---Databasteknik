<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CaseDelete.aspx.cs" Inherits="Projekt_1dv406.Pages.CaseDelete" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Radera felanmälan
    </h1>

    <%-- Statusinformation --%>
    <div class="status">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            HeaderText="Fel inträffade! Åtgärda felen och försök igen."
            CssClass="validate" ShowModelStateErrors="false" />
    </div>
    <asp:PlaceHolder ID="PlaceHolderConfirm" runat="server">
        <p>
            Bekräfta om du verkligen vill radera denna felanmälan då den inte kommer 
            att kunna återskapas efter radering.
        </p>
    </asp:PlaceHolder>
    <div>
        <%-- Möjlighet att bekräfta radering eller avbryta radering --%>
        <asp:LinkButton ID="DeleteLinkButton" runat="server"
            Text="Bekräfta" OnCommand="DeleteLinkButton_Command"
            CommandArgument='<%$ RouteValue:id %>' />
        <asp:HyperLink ID="CancelHyperLink" runat="server" Text="Avbryt" NavigateUrl='<%$ RouteUrl:routename=CaseListing %>' />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>
