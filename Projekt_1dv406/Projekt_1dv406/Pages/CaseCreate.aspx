<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CaseCreate.aspx.cs" Inherits="Projekt_1dv406.Pages.CaseCreate" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Skapa felanmälan
    </h1>
    <div class="links">
        <asp:HyperLink runat="server" Text="Felanmälningslista" NavigateUrl='<%$ RouteUrl:routename=CaseListing %>' />
    </div>
    <%-- Statusinformation --%>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
        HeaderText="Fel inträffade! Åtgärda felen och försök igen."
        CssClass="validate" />

    <%-- Formulär för att skapa en felanmälan --%>
    <asp:FormView ID="CaseCreateFormView" runat="server"
        ItemType="Projekt_1dv406.Model.Case"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="CaseCreateFormView_InsertItem">
        <InsertItemTemplate>
            <div>
                <asp:Label ID="DateLabel" runat="server"
                    Text="Inkommet"></asp:Label>
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
                    Text='<%# BindItem.Ämne %>' Width="300" MaxLength="50"></asp:TextBox>
                <%-- Validering --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="TopicTextBox" ErrorMessage="Fältet Ämne får inte vara tomt."
                    Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="ErrorCaseLabel" runat="server"
                    Text="Beskrivning (max 500 tecken)"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="ErrorCaseTextBox" runat="server"
                    TextMode="MultiLine" Columns="70" Rows="10" MaxLength="500"
                    Text='<%# BindItem.Felanmälan %>'></asp:TextBox>
                <%-- Validering --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="ErrorCaseTextBox" ErrorMessage="Fältet Beskrivning får inte vara tomt."
                    Display="None"></asp:RequiredFieldValidator>
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
