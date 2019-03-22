<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CDLibrary.aspx.cs" Inherits="PracticeExercises.Exercises.CDLibrary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="page-header">
        <h1>CD Library</h1>
    </div>
    <div class="row col-md-12">
        <div class="alert alert-info">
            <p>
                Fill the form below to add a music CD to your personal library.
            </p>
        </div>
    </div>

    <%--Required Validation--%>
    <asp:RequiredFieldValidator ID="RequiredFieldTitle" runat="server" ErrorMessage="Title is required." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="CDTitle"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldYear" runat="server" ErrorMessage="Year is required and must be between 1900 and today." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Year"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldTracks" runat="server" ErrorMessage="Track number is required." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Tracks"></asp:RequiredFieldValidator>
    <%--Compare Validation--%>
    <asp:CompareValidator ID="CompareYear" runat="server" ErrorMessage="Year must be between 1900 and today!" Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Year" ValueToCompare="1900" Operator="GreaterThanEqual"></asp:CompareValidator>

    <asp:CompareValidator ID="CompareTrack" runat="server" ErrorMessage="Tracks must be greater than 0." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Tracks" ValueToCompare="0" Operator="GreaterThan"></asp:CompareValidator>
    <%--Regex Validation--%>
    
    <%--Range Validation--%>
    

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Correct the following concerns and resubmit."
        CssClass="alert alert-danger"/>
    <%--Form--%>

    <div class="row">
        <div class="col-md-6">
            <fieldset class="horizontal">
                <legend>CD Library</legend>
                <asp:Label ID="Label1" runat="server" Text="ISBN (Barcode)" AssociatedControlID="ISBN"></asp:Label>
                <asp:TextBox ID="ISBN" runat="server" ToolTip="Enter the barcode of your CD."></asp:TextBox>

                <asp:Button ID="Search" runat="server" Text="Search Online For CD" OnClick="Submit_Click" />

                <asp:Label ID="Label2" runat="server" Text="Title" AssociatedControlID="CDTitle"></asp:Label>
                <asp:TextBox ID="CDTitle" runat="server" ToolTip="Enter the title of your CD."></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Text="Artist(s)" AssociatedControlID="Artists"></asp:Label>
                <asp:TextBox ID="Artists" runat="server" ToolTip="Enter the artist(s)." Height="33px" Width="163px"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Year" AssociatedControlID="Year"></asp:Label>
                <asp:TextBox ID="Year" runat="server" ToolTip="Enter the year of publication."></asp:TextBox>

                <asp:Label ID="Label5" runat="server" Text="Number of Tracks" AssociatedControlID="Tracks"></asp:Label>
                <asp:TextBox ID="Tracks" runat="server" ToolTip="Enter the number of tracks of the CD."></asp:TextBox>
                <br /><br />
                <asp:Button ID="Add" runat="server" Text="Add to Library" OnClick="Add_Click" />
                <asp:Label ID="Message" runat="server" ></asp:Label><br />
                <hr style="width:5px" />
                <asp:GridView ID="songList" runat="server"></asp:GridView>
            </fieldset>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
