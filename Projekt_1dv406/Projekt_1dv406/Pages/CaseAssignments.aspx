<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CaseAssignments.aspx.cs" Inherits="Projekt_1dv406.Pages.CaseAssignments" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Detaljer Felanmälan
    </h1>
    <div class="links">
        <asp:HyperLink runat="server" Text="Felanmälningslista" NavigateUrl='<%$ RouteUrl:routename=CaseListing %>' />
    </div>

    <%-- Statusinformation --%>
    <div class="status">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            HeaderText="Fel inträffade! Åtgärda felen och försök igen."
            CssClass="validate" ShowModelStateErrors="false" />
    </div>

    <%-- Visar den valda felanmälans uppgifter --%>
    <asp:FormView ID="DetailsFormView" runat="server"
        ItemType="Projekt_1dv406.Model.Case"
        DataKeyNames="FelanmID"
        SelectMethod="DetailsFormView_GetItem"
        RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <asp:Label ID="DateLabel" runat="server"
                    Text="Mottaget"></asp:Label>
            </div>
            <div>
                <%#: Item.Datum %>
            </div>
            <div>
                <asp:Label ID="TopicLabel" runat="server"
                    Text="Ämne"></asp:Label>
            </div>
            <div>
                <%#: Item.Ämne %>
            </div>
            <div>
                <asp:Label ID="ErrorCaseLabel" runat="server"
                    Text="Beskrivning (max 500 tecken)"></asp:Label>
            </div>
            <div>
                <%#: Item.Felanmälan %>
            </div>
            <div class="actionwrapper">
                <%-- Listview som presenterar felanmälans åtgärd --%>
                <asp:ListView ID="ActionListView" runat="server"
                    ItemType="Projekt_1dv406.Model.Action"
                    DataKeyNames="FelanmID, ÅtgID, AvdID"
                    SelectMethod="ActionListView_GetData"
                    OnItemDataBound="ActionListView_ItemDataBound">
                    <LayoutTemplate>
                        <h3>Åtgärdinformation</h3>
                        <table>
                            <th>Avdelning</th>
                            <th>Beräknad startdatum</th>
                            <th>Beräknad slutdatum</th>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal ID="DepartmentLiteral" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#: Item.StartDatum %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#: Item.SlutDatum %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyItemTemplate>
                        <p>
                            Åtgärdinformation saknas.
                        </p>
                    </EmptyItemTemplate>
                </asp:ListView>
            </div>
            <div>
                <%-- Möjlighet att välja om felanmälan ska redigeras eller raderas samt tillbaka till startsidan --%>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("CaseEdit", new { id = Item.FelanmID }) %>' />
                <asp:HyperLink ID="HyperLink2" runat="server" Text="Radera" NavigateUrl='<%# GetRouteUrl("CaseDelete", new { id = Item.FelanmID }) %>' />
                <asp:HyperLink ID="HyperLink3" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("CaseCreate", null) %>' />
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>
