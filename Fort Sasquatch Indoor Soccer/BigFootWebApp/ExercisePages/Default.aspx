<%@ Page Title="Default Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="page-header">
            <h1>FSIS Exercises</h1>
        </div>

    <div class="col-md-12">
        <div class="alert alert-warning">
            <blockquote style="font-style: italic">
                This exercise will demonstrate the use of a GridView in order to display the information our database has on the Guardians.
            </blockquote>
        </div>
    </div>
    <br />
    <asp:DataList ID="Message" runat="server" Enabled="False">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    <br />

    <div class="col-md-6">
        <fieldset class="form-horizontal">
            <legend>Guardian Records Search</legend>
        <asp:DropDownList ID="GuardianList" runat="server" OnSelectedIndexChanged="GuardianList_SelectedIndexChanged">
        </asp:DropDownList>
    <br /><br />
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />&nbsp;
        <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click" />

        <br />
        </fieldset>
        </div>
    <div class="col-md-6">
        <fieldset class="form-horizontal">
            <legend>Guardian Information</legend>
            <asp:Label ID="Label1" runat="server" Text="Guardian ID:" Font-Bold="True"
                 AssociatedControlID="GuardianID"></asp:Label>
        &nbsp;<asp:Label ID="GuardianID" runat="server"></asp:Label>

            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="First Name:"
                 AssociatedControlID="FirstName"></asp:Label>
&nbsp;<asp:TextBox ID="FirstName" runat="server"></asp:TextBox>

            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Last Name:"
                 AssociatedControlID="LastName"></asp:Label>
&nbsp;<asp:TextBox ID="LastName" runat="server"></asp:TextBox>

            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Emergency Phone Number:"
                 AssociatedControlID="EmergencyPhoneNumber"></asp:Label>
&nbsp;<asp:TextBox ID="EmergencyPhoneNumber" runat="server"></asp:TextBox>

            <br />
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Email Address:"
                 AssociatedControlID="EmailAddress"></asp:Label>
&nbsp;<asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox>

        </fieldset>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
