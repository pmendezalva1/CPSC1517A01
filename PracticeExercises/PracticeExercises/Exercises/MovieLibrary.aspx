<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieLibrary.aspx.cs" Inherits="PracticeExercises.Exercises.MovieLibrary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="page-header">
        <h1>Movie Library</h1>
    </div>
    <div class="row col-md-12">
        <div class="alert alert-info">
            <p>
                Fill out the form below to add information on the movie for your movie library.
            </p>
        </div>
    </div>
    <%--Required Validation
        Title is required, year is required (valid since 1900), indicate type of media the movie's stored on--%>
    <asp:RequiredFieldValidator ID="RequiredFieldTitle" runat="server" ErrorMessage="Title is required." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Title"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldYear" runat="server" ErrorMessage="Year is required and must range from 1900 to now." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Year"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldMedia" runat="server" ErrorMessage="Media type is required." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Media"></asp:RequiredFieldValidator>
    <%--Compare Validation--%>
    <asp:CompareValidator ID="CompareYear" runat="server" ErrorMessage="Year must be greater than or equal to 1900!" Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Year" ControlToCompare="1900" Operator="GreaterThanEqual"></asp:CompareValidator>
    <%--Range Validation--%>

    <%--RegEx--%>

    <%--Form--%>

    <table class="nav-justified">
        <tr>
            <td align="right"><asp:Label ID="Label1" runat="server" Text="Title" AssociatedControlID="Title"></asp:Label>
&nbsp;</td>
            <td><asp:TextBox ID="Title" runat="server" ToolTip="Enter your movie title."></asp:TextBox>
&nbsp;</td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="Label4" runat="server" Text="Year" AssociatedControlID="Year"></asp:Label>
&nbsp;</td>
            <td><asp:TextBox ID="Year" runat="server" ToolTip="Enter your movie year."></asp:TextBox>
&nbsp;</td>
        </tr>
        <tr>
            <td align="right"><asp:Literal ID="Literal1" runat="server" Text="Media"></asp:Literal>
&nbsp;</td>
            <td><asp:CheckBox ID="CBDVD" runat="server" Text="DVD"/></td>
            <td><asp:CheckBox ID="CBVHS" runat="server" Text="VHS"/></td>
            <td><asp:CheckBox ID="CBFile" runat="server" Text="File"/></td>
        </tr>
        <tr>
            <td align="right"><asp:Literal ID="Rating" runat="server" Text="Rating"></asp:Literal>
&nbsp;</td>
            <td><asp:CheckBox ID="CheckBox1" runat="server" Text="General (G)"/></td>
            <td><asp:CheckBox ID="CheckBox2" runat="server" Text="Parental Guidance (PG)"/></td>
            <td><asp:CheckBox ID="CheckBox3" runat="server" Text="14A"/></td>
            <td><asp:CheckBox ID="CheckBox4" runat="server" Text="18A"/></td>
            <td><asp:CheckBox ID="CheckBox5" runat="server" Text="Restricted (R)"/></td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="Label2" runat="server" Text="Review (1-5 Stars)" ToolTip="Please choose your review rating from 1 to 5."></asp:Label>
&nbsp;</td>
            <td><asp:DropDownList ID="RatingList" runat="server" RepeatDirection="horizontal" RepeatLayout="flow">
                <asp:ListItem Value="1">1 Star</asp:ListItem>
                <asp:ListItem Value="2">2 Star</asp:ListItem>
                <asp:ListItem Value="3">3 Star</asp:ListItem>
                <asp:ListItem Value="4">4 Star</asp:ListItem>
                <asp:ListItem Value="5">5 Star</asp:ListItem>
                </asp:DropDownList></td>
            <br /><br />
        </tr>
            <asp:TextBox ID="RatingChoice" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="RatingValue" runat="server"></asp:TextBox>
        <br />
        <tr>
            <td align="right"><asp:Label ID="Label3" runat="server" Text="ISBN" AssociatedControlID="ISBN"></asp:Label>
&nbsp;</td>
            <td><asp:TextBox ID="TextBox2" runat="server" ToolTip="Enter your bar code number."></asp:TextBox>
&nbsp;</td>
            <td><asp:Button ID="Search" runat="server" Text="Search Online" OnClick="Search_Click" />&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Add" runat="server" Text="Add to Library" OnClick="Add_Click" />
            </td>
            <asp:Label ID="Message" runat="server" ></asp:Label><br />
                <hr style="width:5px" />
                <asp:GridView ID="movieList" runat="server"></asp:GridView>
        </tr>
    </table>
</asp:Content>
