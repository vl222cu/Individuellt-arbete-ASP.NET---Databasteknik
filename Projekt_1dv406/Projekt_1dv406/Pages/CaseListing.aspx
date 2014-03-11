﻿<%@ Page Title="Felanmälningslista" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CaseListing.aspx.cs" Inherits="Projekt_1dv406.Pages.CaseListing" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Felanmälningar
    </h1>
    <div class="links">
        <asp:HyperLink runat="server" Text="Ny felanmälan" NavigateUrl='<%$ RouteUrl:routename=ErrorCase %>' />
    </div>
    <div class="status">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <asp:ListView ID="CaseListView" runat="server"
        ItemType="Projekt_1dv406.Model.Case"
        SelectMethod="CaseListView_GetData"
        DataKeyNames="FelanmID">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Felanmälan</th>
                    <th>Datum</th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Item.Felanmälan %>
                </td>
                <td>
                    <%# Item.Datum %>
                </td>
            </tr>
            <%-- Platshållare för nya rader --%>
        </ItemTemplate>
        <EmptyDataTemplate>
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
