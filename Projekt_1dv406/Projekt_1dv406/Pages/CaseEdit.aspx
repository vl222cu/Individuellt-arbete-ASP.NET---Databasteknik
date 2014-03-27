<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CaseEdit.aspx.cs" Inherits="Projekt_1dv406.Pages.CaseEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Redigera felanmälan
    </h1>

    <%-- Länk tillbaks till felanmälningslistan --%>
    <div class="links">
        <asp:HyperLink runat="server" Text="Felanmälningslista" NavigateUrl='<%$ RouteUrl:routename=CaseListing %>' />
    </div>

    <%-- Statusinformation --%>
    <div class="status">
        <p>
            <asp:Label ID="StatusLabel" runat="server" Text="" Visible="false" CssClass="statusmsg"></asp:Label>
        </p>
        <p>
            <%-- Valideringsfelmeddelanden --%>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                HeaderText="Fel inträffade! Åtgärda felen och försök igen."
                CssClass="validate" />
        </p>
    </div>

    <div class="formwrapper">
        <%-- Formulär för att uppdatera en felanmälan --%>
        <asp:FormView ID="EditErrorCaseFormView" runat="server"
            ItemType="Projekt_1dv406.Model.Case"
            DataKeyNames="FelanmID"
            DefaultMode="Edit"
            RenderOuterTable="false"
            SelectMethod="EditErrorCaseFormView_GetItem"
            UpdateMethod="EditErrorCaseFormView_UpdateItem">
            <EditItemTemplate>
                <div class="caselabel">
                    <asp:Label ID="DateLabel" runat="server"
                        Text="Mottaget ärendenummer "></asp:Label>
                    <asp:Literal ID="FelanmIdLiteral" runat="server" Text="<%# Item.FelanmID %>"></asp:Literal>
                </div>
                <div>
                    <%-- Inputfält för datum vid ändring --%>
                    <asp:TextBox ID="DateTextBox" runat="server"
                        TextMode="DateTime"
                        Text='<%# BindItem.Datum %>'
                        CssClass="textbox"></asp:TextBox>
                </div>
                <div class="caselabel">
                    <asp:Label ID="TopicLabel" runat="server"
                        Text="Ämne"></asp:Label>
                </div>
                <div>
                    <%-- Inputfält för uppdatering av ämne på felanmälan --%>
                    <asp:TextBox ID="TopicTextBox" runat="server"
                        TextMode="SingleLine"
                        Text='<%# BindItem.Ämne %>' Width="300"
                        CssClass="textbox"></asp:TextBox>
                    <%-- Validering --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="TopicTextBox" ErrorMessage="Fältet Ämne får inte vara tomt."
                        Display="None"></asp:RequiredFieldValidator>
                </div>
                <div class="caselabel">
                    <asp:Label ID="ErrorCaseLabel" runat="server"
                        Text="Beskrivning (max 500 tecken)"></asp:Label>
                </div>
                <div>
                    <%-- Inputfält för uppdatering av felanmälan --%>
                    <asp:TextBox ID="ErrorCaseTextBox" runat="server"
                        TextMode="MultiLine" Columns="70" Rows="10"
                        Text='<%# BindItem.Felanmälan %>'
                        CssClass="textbox"></asp:TextBox>
                    <%-- Validering --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="ErrorCaseTextBox" ErrorMessage="Fältet Beskrivning får inte vara tomt."
                        Display="None"></asp:RequiredFieldValidator>
                </div>
                <div class="actionwrapper">
                    <%-- Listview som presenterar felanmälans åtgärd --%>
                    <asp:ListView ID="ActionListView" runat="server"
                        ItemType="Projekt_1dv406.Model.Action"
                        FelanmID="<%$ RouteValue:id %>"
                        DataKeyNames="FelanmID, ÅtgID, AvdID"
                        SelectMethod="ActionListView_GetData"
                        InsertMethod="ActionListView_InsertItem"
                        UpdateMethod="ActionListView_UpdateItem"
                        DeleteMethod="ActionListView_DeleteItem"
                        InsertItemPosition="LastItem">
                        <LayoutTemplate>
                            <h3>Åtgärdinformation</h3>
                            <table>
                                <th>Avdelning</th>
                                <th>Beräknad startdatum</th>
                                <th>Beräknad slutdatum</th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%-- Visning av vald avdelning --%>
                                    <asp:DropDownList ID="DepartmentDropDownListing" runat="server"
                                        ItemType="Projekt_1dv406.Model.Department"
                                        SelectMethod="DepartmentDropDownList_GetData"
                                        DataTextField="Avdelning"
                                        DataValueField="AvdID"
                                        SelectedValue='<%# Item.AvdID %>'
                                        Enabled="False"
                                        CssClass="textbox">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%-- Visning av vald startdatum --%>
                                    <asp:TextBox ID="StartDateTextBox" runat="server"
                                        Text='<%# Item.StartDatum %>' Enabled="False"
                                        CssClass="textbox"></asp:TextBox>
                                </td>
                                <td>
                                    <%-- Visning av slutdatum --%>
                                    <asp:TextBox ID="TextBox1" runat="server"
                                        Text='<%# Item.SlutDatum %>' Enabled="False"
                                        CssClass="textbox"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" runat="server"
                                        CommandName="Edit" Text="Redigera" CssClass="linkbutton"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" runat="server"
                                        CommandName="Delete" Text="Radera"
                                        CausesValidation="false" CssClass="linkbutton"
                                        OnClientClick='<%# String.Format("return confirm(\"Vill du verkligen radera åtgärden för felanmälan med ärendenummer {0}?\")", Item.FelanmID) %>'></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td>
                                    <%-- Val av avdelningar --%>
                                    <asp:DropDownList ID="DepartmentDropDownListing" runat="server"
                                        ItemType="Projekt_1dv406.Model.Department"
                                        SelectMethod="DepartmentDropDownList_GetData"
                                        DataTextField="Avdelning"
                                        DataValueField="AvdID"
                                        SelectedValue='<%# BindItem.AvdID %>'
                                        CssClass="textbox">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%-- Startdatuminput --%>
                                    <asp:TextBox ID="StartDateTextBox" runat="server"
                                        TextMode="DateTimeLocal" Text='<%# BindItem.StartDatum %>'
                                        CssClass="textbox"></asp:TextBox>
                                </td>
                                <td>
                                    <%-- Slutdatuminput --%>
                                    <asp:TextBox ID="EndDateTextBox" runat="server"
                                        TextMode="DateTimeLocal" Text='<%# BindItem.SlutDatum %>'
                                        CssClass="textbox"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" runat="server"
                                        CommandName="Insert" Text="Spara" CssClass="linkbutton"></asp:LinkButton>
                                </td>
                                <td></td>
                            </tr>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <tr>
                                <td>
                                    <%-- Val av avdelningar vid uppdatering --%>
                                    <asp:DropDownList ID="DepartmentDropDownListing" runat="server"
                                        ItemType="Projekt_1dv406.Model.Department"
                                        SelectMethod="DepartmentDropDownList_GetData"
                                        DataTextField="Avdelning"
                                        DataValueField="AvdID"
                                        SelectedValue='<%# BindItem.AvdID %>'
                                        CssClass="textbox">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%-- Startdatuminput --%>
                                    <asp:TextBox ID="StartDateTextBox2" runat="server"
                                        TextMode="DateTime" Text='<%# BindItem.StartDatum %>'
                                        CssClass="textbox"></asp:TextBox>
                                </td>
                                <td>
                                    <%-- Slutdatuminput --%>
                                    <asp:TextBox ID="EndDateTextBox2" runat="server"
                                        TextMode="DateTime" Text='<%# BindItem.SlutDatum %>'
                                        CssClass="textbox"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" runat="server"
                                        CommandName="Update" Text="Spara" CssClass="linkbutton"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" runat="server"
                                        CommandName="Cancel" Text="Avbryt"
                                        CausesValidation="false" CssClass="linkbutton"></asp:LinkButton>
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <EmptyItemTemplate>
                            <p>
                                Åtgärdinformation saknas.
                            </p>
                        </EmptyItemTemplate>
                    </asp:ListView>
                </div>
                <div>
                    <%-- Möjlighet att spara ändringen eller avbryta ändringen --%>
                    <asp:LinkButton ID="LinkSaveEditButton" runat="server"
                        Text="Spara" CommandName="Update"
                        CssClass="linkbutton" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt"
                        NavigateUrl='<%# GetRouteUrl("CaseAssignments", new { id = Item.FelanmID }) %>'
                        CssClass="linkbutton" />
                </div>
            </EditItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

