<%@ Page Title="Default Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="page-header">
            <h1>FSIS Exercises</h1>
        </div>

    <div class="col-md-12">
        <div class="alert alert-warning">
            <blockquote style="font-size: italic">
                This exercise will demonstrate the use of a GridView in order to display the information our database has on the Guardians.
            </blockquote>
        </div>
    </div>

    <br />
        <asp:DropDownList ID="GuardiansList" runat="server">
        </asp:DropDownList>
    <br /><br />
        <asp:Button ID="Submit" runat="server" Text="Submit" />&nbsp;
        <asp:Button ID="Clear" runat="server" Text="Clear" />
        <br />

        <table class="nav-justified">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

</asp:Content>
