﻿<%@ Page Title="Simple Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimpleQueries.aspx.cs" Inherits="WebApp.SamplePages.SimpleQueries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Simple Query: PKey</h1>
    <table align="center" style="width: 80%">
        <tr>
            <td align="right">
                 <asp:Label ID="Label1" runat="server" Text="Enter a Product ID:"></asp:Label>&nbsp;</td>
            <td>
                <asp:TextBox ID="SearchArg" runat="server"></asp:TextBox>&nbsp;</td>
        </tr>
        <tr>
            <td align="right">            
                <asp:Label ID="Label2" runat="server" Text="ProductID:"></asp:Label>&nbsp;</td>
            <td>            
                <asp:Label ID="ProductID" runat="server"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            
            <td align="right">
            <asp:Label ID="Label4" runat="server" Text="Name:"></asp:Label>&nbsp;
            <asp:Label ID="ProductName" runat="server"></asp:Label>&nbsp;
                </td>
          <td colspan="2" align="center">
            <asp:Label ID="MessageLabel" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="center">
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />&nbsp;
            <asp:Button ID="Clear" runat="server" Text="Clear" CausesValidation="false" OnClick="Clear_Click"/>&nbsp;
                </td>
        </tr>
    </table>
</asp:Content>
