<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CaseEdit.aspx.cs" Inherits="Projekt_1dv406.Pages.CaseEdit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <h1>
        Redigera felanmälan
    </h1>
    <div class="links">
        <asp:HyperLink runat="server" Text="Felanmälningar" NavigateUrl='<%$ RouteUrl:routename=CaseListing %>' />
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:FormView ID="EditErrorCaseFormView" runat="server"
        ItemType="Projekt_1dv406.Model.Case"
        DataKeyNames="FelanmID"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="EditErrorCaseFormView_GetItem"
        UpdateMethod="EditErrorCaseFormView_UpdateItem">
        <EditItemTemplate>
            <div>
                <asp:Label ID="DateLabel" runat="server"
                    Text="Mottaget"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="DateTextBox" runat="server"
                    TextMode="DateTimeLocal"
                     Text='<%# BindItem.Datum %>'></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="TopicLabel" runat="server"
                    Text="Ämne"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="TopicTextBox" runat="server"
                    TextMode="SingleLine"
                    Text='<%# BindItem.Ämne %>' Width="300"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="ErrorCaseLabel" runat="server"
                    Text="Beskrivning (max 500 tecken)"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="ErrorCaseTextBox" runat="server"
                    TextMode="MultiLine" Columns="70" Rows="10"
                    Text='<%# BindItem.Felanmälan %>'></asp:TextBox>
            </div>
            <div>
                <asp:LinkButton ID="LinkSaveEditButton" runat="server"
                    Text="Spara" CommandName="Update"
                    CssClass="linkbutton" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("CaseDetails", new { id = Item.FelanmID }) %>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>
