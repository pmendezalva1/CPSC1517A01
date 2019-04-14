<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormA.aspx.cs" Inherits="StarTED_Lab.Pages.FormA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Planned Assessment: Form A</h1>
    </div>
    <br />
    <asp:DataList ID="Message" runat="server">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
        </asp:DataList>
    <br />
    <div class="col-md-6">
    <fieldset class="form-horizontal">
        <legend>Form A: Planned Assessment - Insert/Edit/Update/Delete</legend>
    <br />
        <asp:Label ID="Label1" runat="server" Text="Course: " Font-Bold="True"></asp:Label>&nbsp;
        <asp:TextBox ID="PartialName" runat="server" ToolTip="Enter a course name"> </asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="SearchCoursesPartialName" runat="server" Text="Courses?" OnClick="SearchCoursesPartial_Click" />

        <br />
        <asp:Label ID="Label3" runat="server" Text="Assessments:" Font-Bold="True"></asp:Label>&nbsp;
        <asp:DropDownList ID="CourseList" align="right" runat="server" OnSelectedIndexChanged="CourseList_SelectedIndexChanged"></asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button ID="SearchPlannedAssessments" runat="server" Text="Assessments?" OnClick="SearchPlannedAssessments_Click" />&nbsp;
    <br />

        <br />
        <asp:GridView ID="AssessmentsGridView" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="AssessmentsGridView_PageIndexChanging" CellPadding="5" CellSpacing="5" GridLines="Horizontal" OnSelectedIndexChanged="AssessmentsGridView_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ShowSelectButton="true" CausesValidation="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="AssessmentID" runat="server" Text='<%# Eval("AssessmentID") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="Name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#CC99FF" Font-Bold="True" HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assessment Type ID">
                    <ItemTemplate>
                        <asp:Label ID="AssessmentTypeID" runat="server" Text='<%# Eval("AssessmentTypeID") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#CC99FF" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="Description" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Description" runat="server" Text='<%# Eval("CourseID") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#CC99FF" Font-Bold="True" HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Course ID">
                    <ItemTemplate>
                        <asp:Label ID="CourseID" runat="server" Text='<%# Eval("CourseID") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#CC99FF" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Weight">
                    <ItemTemplate>
                        <asp:Label ID="Weight" runat="server" Text='<%# Eval("Weight") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#CC99FF" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Required Pass">
                    <ItemTemplate>
                        <asp:CheckBox ID="RequiredPass" runat="server" 
                            Checked='<%# Eval("RequiredPass") %>' 
                            Enabled="false"/>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#CC99FF" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BorderStyle="None" />
            <PagerSettings FirstPageText="Start" LastPageText="End" />
        </asp:GridView>
        
    </fieldset>
            </div>
    <div class="col-md-6">
        <fieldset class="form-horizontal">
        <legend>Planned Assessments</legend>
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Assessment ID:"
             AssociatedControlID="AssessmentID"></asp:Label>
        &nbsp;<asp:Label ID="AssessmentID" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Name:"
             AssociatedControlID="Name"></asp:Label>
        &nbsp;<asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Assessment Type ID:"
             AssociatedControlID="AssessmentList"></asp:Label>
&nbsp;<asp:DropDownList ID="AssessmentList" runat="server" OnSelectedIndexChanged="AssessmentList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Description:"
             AssociatedControlID="Description"></asp:Label>
&nbsp;<asp:TextBox ID="Description" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Course ID:"
             AssociatedControlID="CourseIDList"></asp:Label>
&nbsp;<asp:DropDownList ID="CourseIDList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Weight:"
             AssociatedControlID="Weight"></asp:Label>
&nbsp;<asp:TextBox ID="Weight" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Required Pass"
             AssociatedControlID="Required"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBox ID="Required" runat="server" />
        <br />
        <br />
        <asp:LinkButton ID="Add" runat="server" Font-Italic="True" OnClick="Add_Click">Add</asp:LinkButton>
&nbsp;<asp:LinkButton ID="Update" runat="server" Font-Italic="True" OnClick="Update_Click">Update</asp:LinkButton>
&nbsp;<asp:LinkButton ID="Discontinued" runat="server" OnClick="Discontinued_Click" Font-Bold="False" Font-Italic="True">Discontinued</asp:LinkButton>
        <br />
            </fieldset>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
