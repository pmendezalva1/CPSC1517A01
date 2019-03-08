﻿<%@ Page Title="Hello World" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="WebApp.SamplePages.HelloWorld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Enter your name:"></asp:Label>&nbsp;&nbsp;
    <asp:TextBox ID="YourName" runat="server" ToolTip="Enter your name"></asp:TextBox>
    <br /><br />
    <asp:Button ID="PressMe" runat="server" Text="Press Me" OnClick="PressMe_Click" />
    <br /><br />
    <asp:Literal ID="OutputMessage" runat="server"></asp:Literal>
</asp:Content>