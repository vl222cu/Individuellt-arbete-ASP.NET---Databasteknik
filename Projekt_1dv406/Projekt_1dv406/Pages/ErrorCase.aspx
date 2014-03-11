<%@ Page Title="Felanmälningsformulär" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ErrorCase.aspx.cs" Inherits="Projekt_1dv406.Pages.ErrorCase" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Skapa felanmälan
    </h1>
    <asp:HyperLink runat="server" Text="Felanmälningar" NavigateUrl='<%$ RouteUrl:routename=CaseListing %>'/>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:FormView ID="ErrorCaseFormView" runat="server"
        ItemType="Projekt_1dv406.Model.Case"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="ErrorCaseFormView_InsertItem">
        <InsertItemTemplate>
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
                <asp:Label ID="ErrorCaseLabel" runat="server"
                    Text="Beskrivning (max 500 tecken)"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="ErrorCaseTextBox" runat="server"
                    TextMode="MultiLine" Columns="70" Rows="10"
                    Text='<%# BindItem.Felanmälan %>'></asp:TextBox>
            </div>
            <div>
                <asp:LinkButton ID="LinkSaveButton" runat="server"
                    Text="Spara" CommandName="Insert"
                    CssClass="linkbutton" />
                <asp:LinkButton ID="LinkCancelButton" runat="server"
                    Text="Avbryt" CommandName="Cancel"
                    CssClass="linkbutton" />
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>
