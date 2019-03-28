<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookForm.aspx.cs" Inherits="WebApp_PMendezAlva.BookForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="page-header">
        <h1>Book - Activity 2 Assessment</h1>
    </div>
    <div class="row col-md-12">
        <div class="alert alert-info">
            <p>
                This assessment will test basic web form construction, validation, data collection and display.
            </p>
        </div>
    </div>

    <%--Required Validation--%>
    <asp:RequiredFieldValidator ID="RequiredFieldISBN" runat="server" ErrorMessage="ISBN is a required field." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="ISBN"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldName" runat="server" ErrorMessage="Name is a required field." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Name"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldCost" runat="server" ErrorMessage="Purchase Cost is a required field." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="PurchaseCost"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldPrice" runat="server" ErrorMessage="Selling Price is a required field." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="SellingPrice"></asp:RequiredFieldValidator>

    <%--ReEx--%>
    <asp:RegularExpressionValidator ID="RegularExpressionISBN" runat="server" ErrorMessage="ISBN is invalid (ex. 1-19-12345-02)" Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="ISBN" ValidationExpression="[1-9]\-[0-9][0-9]\-[1-9][0-9][0-9][0-9][0-9]\-[0-9][0-9]"></asp:RegularExpressionValidator>
    
    <%--Compare Validation--%>
    <asp:CompareValidator ID="CostGreater" runat="server" ErrorMessage="Purchase Cost is a number greater than 0.0." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="PurchaseCost" ValueToCompare="0.0" Operator="GreaterThanEqual" Type="Double"></asp:CompareValidator>

    <asp:CompareValidator ID="PriceGreater" runat="server" ErrorMessage="Selling Price is a number 0.0 or greater." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="SellingPrice" ValueToCompare="0.0" Operator="GreaterThanEqual" Type="Double"></asp:CompareValidator>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Correct the following concerns and resubmit."
        CssClass="alert alert-danger"/>

    <%--Form--%>
    <div class="row">
        <div class="col-md-6">
            <fieldset class="form-horizontal">
                <legend>Book - Activity 2 Assessment</legend>
            <table class="nav-justified">
        <tr>
            <td align="right"><asp:Label ID="Label1" runat="server" Text="ISBN" AssociatedControlID="ISBN"></asp:Label></td>
            <td><asp:TextBox ID="ISBN" runat="server" ToolTip="Enter your bar code."></asp:TextBox></td>
        </tr>
            <tr>
            <td align="right"><asp:Label ID="Label2" runat="server" Text="Name" AssociatedControlID="Name"></asp:Label></td>
            <td><asp:TextBox ID="Name" runat="server" ToolTip="Enter the name of your book."></asp:TextBox></td>
        </tr>
            <tr>
                    <td align="right"><asp:Label ID="Label3" runat="server" Text="Purchase Cost" AssociatedControlID="PurchaseCost"></asp:Label></td>
            <td><asp:TextBox ID="PurchaseCost" runat="server" ToolTip="Enter your purchase cost."></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right"><asp:Label ID="Label4" runat="server" Text="Selling Price" AssociatedControlID="SellingPrice"></asp:Label></td>
            <td><asp:TextBox ID="SellingPrice" runat="server" ToolTip="Enter the selling price"></asp:TextBox></td>
                </tr>
    </table>
            </fieldset>
                <asp:Button ID="Add" runat="server" Text="Add Book" OnClick="Add_Click" CausesValidation="true" />&nbsp;&nbsp;

            <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click" CausesValidation="false" />
            <asp:Label ID="Message" runat="server" ></asp:Label><br />
                <hr style="width:5px" />
                <asp:GridView ID="BookListDisplay" runat="server"></asp:GridView>
        </div>
    </div>
    
    <script src="Scripts/bootwrap-freecode.js"></script>
</asp:Content>
