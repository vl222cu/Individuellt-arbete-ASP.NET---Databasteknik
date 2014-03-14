<%@ Page Title="Felanmälningslista" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CaseListing.aspx.cs" Inherits="Projekt_1dv406.Pages.CaseListing" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Felanmälningslista
    </h1>
    <%-- Möjlighet att återgå till felanmälningsformuläret --%>
    <div class="links">
        <asp:HyperLink runat="server" Text="Startsida" NavigateUrl='<%$ RouteUrl:routename=CaseCreate %>' />
    </div>

    <%-- Lista på alla felanmälningar som är registrerade --%>
    <asp:ListView ID="CaseListView" runat="server"
        ItemType="Projekt_1dv406.Model.Case"
        SelectMethod="CaseListView_GetData"
        DataKeyNames="FelanmID">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Ämne
                    </th>
                    <th>Datum
                    </th>
                </tr>
                <%-- Platshållare för nya rader --%>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("CaseAssignments", new { id = Item.FelanmID })%>' Text='<%# Item.Ämne %>' />                                  
                </td>
                <td>
                    <%# Item.Datum %>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas om felanmälningar saknas i databasen --%>
            <table>
                <tr>
                    <td>Felanmälan saknas.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>
