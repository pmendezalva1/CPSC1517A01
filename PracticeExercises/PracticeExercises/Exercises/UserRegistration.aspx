<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="PracticeExercises.Exercises.UserRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--Note to self: Add these pages through web form with master!
        Web.sitemap is added by clicking on the web app and then clicking Add Site Map.
        Finally, extra validators just in case:
        (?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$    for 8-10, #s and no special charas
        ^.*(?=.{8,})(?=.*[\d])(?=.*[\W]).*$     for at least 8 characters, one digit and a number.--%>
    <br /><br />
    <div class="page-header">
        <h1>User Registration</h1>
    </div>
    <div class="row col-md-12">
        <div class="alert alert-info">
            <p>
                Please fill in the form below and click submit. After submitting the form, you will receive an email with a link to confirm your registration.
                By clicking on that link, you will complete the registration process.
            </p>
        </div>
    </div>
    <%--Required Validation--%>
    <asp:RequiredFieldValidator ID="RequiredFieldFirstName" runat="server" ErrorMessage="First name is required." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="FirstName"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldLastName" runat="server" ErrorMessage="Last name is required." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="LastName"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldUserName" runat="server" ErrorMessage="Username is required." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Username"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldEmail" runat="server" ErrorMessage="Email address is required." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="EmailAddress"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldCompareEmail" runat="server" ErrorMessage="Email address must match." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="CompareEmail"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldPassword" runat="server" ErrorMessage="Password is required." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Password"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldComparePassword" runat="server" ErrorMessage="Password must match." Display="None"
         SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="ComparePassword"></asp:RequiredFieldValidator>

    <%--Range Validation--%>
    <%--<asp:RangeValidator ID="RangeValidatorPassword" runat="server" ErrorMessage="Password must be between 4 and 8 digits long and include at least 1 numeric digit."
        Display="None" SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Password" MinimumValue="4" MaximumValue="8" Type="String"></asp:RangeValidator>--%>

    <%--RegEx--%>
    <asp:RegularExpressionValidator ID="RegularExpressionEmail" runat="server" 
        ErrorMessage="Please enter a valid email address."
        Display="None" SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="EmailAddress"
        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$">
    </asp:RegularExpressionValidator>

    <asp:RegularExpressionValidator ID="RegularExpressionPassword" runat="server" 
        ErrorMessage="Password must be between 4 and 8 digits long and include at least 1 numeric digit."
        Display="None" SetFocusOnError="true" ForeColor="Crimson" ControlToValidate="Password"
        ValidationExpression="^(?=.*\d).{4,8}$" />
    </asp:RegularExpressionValidator>

    <%--Compare Validation--%>
    <asp:CompareValidator ID="CompareConfirmPassword" runat="server" ErrorMessage="Password must match. Retry."
        ForeColor="Crimson" ControlToValidate="ComparePassword" Display="None" SetFocusOnError="true"
        Type="String" Operator="Equal" ControlToCompare="Password">
    </asp:CompareValidator>

    <asp:CompareValidator ID="CompareConfirmEmailAddress" runat="server" ErrorMessage="Email address not confirmed. Retry."
        ForeColor="Crimson" ControlToValidate="CompareEmail" Display="None" SetFocusOnError="true"
        Type="String" Operator="Equal" ControlToCompare="EmailAddress">
    </asp:CompareValidator>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Correct the following concerns and resubmit."
        CssClass="alert alert-danger"/>

    <%--Form--%>
    <div class="row">
        <div class="col-md-6">
            <fieldset class="form-horizontal">
                <legend>User Registration</legend>
        <asp:Label ID="Label1" runat="server" Text="First Name" AssociatedControlID="FirstName"></asp:Label>
        <asp:TextBox ID="FirstName" runat="server" ToolTip="Enter your first name." MaxLength="25"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" Text="Last Name" AssociatedControlID="LastName"></asp:Label>
        <asp:TextBox ID="LastName" runat="server" ToolTip="Enter your last name." MaxLength="25"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" Text="Username" AssociatedControlID="Username"></asp:Label>
        <asp:TextBox ID="Username" runat="server" ToolTip="Enter your username." MaxLength="25"></asp:TextBox>

        <asp:Label ID="Label4" runat="server" Text="Email" AssociatedControlID="EmailAddress"></asp:Label>
        <asp:TextBox ID="EmailAddress" runat="server" ToolTip="Enter your email address." TextMode="Email"></asp:TextBox> 

        <asp:Label ID="Label5" runat="server" Text="Confirm Email" AssociatedControlID="CompareEmail"></asp:Label>
        <asp:TextBox ID="CompareEmail" runat="server" ToolTip="Confirm your email address." TextMode="Email"></asp:TextBox> 

        <asp:Label ID="Label6" runat="server" Text="Password" AssociatedControlID="Password"></asp:Label>
        <asp:TextBox ID="Password" runat="server" ToolTip="Enter your password." TextMode="Password"></asp:TextBox> 

        <asp:Label ID="Label7" runat="server" Text="Confirm Password" AssociatedControlID="ComparePassword"></asp:Label>
        <asp:TextBox ID="ComparePassword" runat="server" ToolTip="Confirm your password" TextMode="Password"></asp:TextBox> 
      </fieldset>
      <p>
          Note: You must agree to the terms of the site.
          <br />
          <asp:CheckBox ID="Terms" runat="server" Text="I agree to the terms of this site" />
      </p>
        </div>
        <div class="col-md-6">   
            <div class="col-md-offset-2">
                <p>
                    <asp:Button ID="Submit" runat="server" Text="Submit Registration" OnClick="Submit_Click" />&nbsp;&nbsp;
                </p>
                <asp:Label ID="Message" runat="server" ></asp:Label><br />
                <hr style="width:5px" />
                <asp:GridView ID="InfoList" runat="server"></asp:GridView>
            </div>
        </div>
   </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
