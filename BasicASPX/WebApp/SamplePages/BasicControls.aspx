<%@ Page Title="Basic Controls" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasicControls.aspx.cs" Inherits="WebApp.BasicControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br /><br />
<table align="center" class="auto-style1">
                    <tr>
                        <td align="right">Enter your choice (1-4):</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="TextBoxNumericChoice" runat="server" ToolTip="Enter a number from 1 to 4
  representing the Course Choice."></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Button ID="SubmitChoice" runat="server" Text="Submit Choice" OnClick="SubmitChoice_Click" />

                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Course Choice" Font-Size="Medium"
                                 ForeColor="#9204bb" Font-Bold="true"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:RadioButtonList ID="RadioButtonListChoice" runat="server"
                                RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1">COMP1008</asp:ListItem>
                                <asp:ListItem Value="2">CPSC1517</asp:ListItem>
                                <asp:ListItem Value="4">DMIT1508</asp:ListItem>
                                <asp:ListItem Value="3">DMIT2018</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal ID="Literal1" runat="server" Text="Programming Choice"></asp:Literal>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxChoice" runat="server" Text="(active if checked)"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" align="right" runat="server" Text="Readonly Label Display"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="DisplayDataReadOnly" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Choice Selection"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="CollectionList" runat="server">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Button ID="ListSubmit" runat="server" Text="List Submit" OnClick="ListSubmit_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="OutputMessage" runat="server"></asp:Label></td>
                    </tr>
                </table>
    </asp:Content>