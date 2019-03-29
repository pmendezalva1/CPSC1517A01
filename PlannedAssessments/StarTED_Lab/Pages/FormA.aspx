<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormA.aspx.cs" Inherits="StarTED_Lab.Pages.FormA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Planned Assessment: Form A</h1>
    </div>
    <br />
    <asp:DataList ID="Message" runat="server" Enabled="False">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    <br />

    <table align="center" style="width: 80%">
    <tr>
        <td align="right">
            <asp:Label ID="Label1" runat="server" Text="Course"></asp:Label>&nbsp;</td>
    <td>
            <asp:TextBox ID="TextBox1" runat="server">Enter a course name: </asp:TextBox>&nbsp;</td>
        <td>
            <asp:Button ID="SearchPartialName" runat="server" Text="Courses?" OnClick="SearchCoursesPartial_Click" />&nbsp;</td>
    </tr>
        <tr>
        <td align="right"></td>
    <td>
        <asp:DropDownList ID="CourseList" align="right" runat="server"></asp:DropDownList>&nbsp;</td>
    &nbsp;&nbsp;
    <td>
        <asp:Button ID="SearchPlannedAssessmentsPartial" runat="server" Text="Assessments?" OnClick="SearchPlannedAssessmentsPartial_Click" />&nbsp;</td>
            </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" Text="Assessments"></asp:Label>&nbsp;</td>
            </td>
            <td align="center">
                <asp:GridView ID="CoursesGridView" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="CoursesGridView_PageIndexChanging" CellPadding="5" CellSpacing="5" GridLines="Horizontal">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" CausesValidation="False" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="CourseID" runat="server" Text='<%# Eval("CourseID") %>' Visible="False"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="CourseName" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#CC99FF" Font-Bold="True" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="Description" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#CC99FF" Font-Bold="True" HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BorderStyle="None" />
                    <PagerSettings FirstPageText="Start" LastPageText="End" PageButtonCount="5" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right">
            <asp:Label ID="Label2" runat="server" Text="Courses"></asp:Label></td>
            <td><asp:TextBox ID="CourseAssess" runat="server">Select your course: </asp:TextBox>&nbsp;</td>
            <td><asp:Button ID="Button3" runat="server" Text="Courses?" OnClick="CourseSearch_Click" />&nbsp;</td>
            <td><asp:DropDownList ID="PlannedAssessmentList" runat="server"></asp:DropDownList></td>
        </tr>
    </table>
</asp:Content>
