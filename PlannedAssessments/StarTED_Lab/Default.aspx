<%@ Page Title="Default" MasterPageFile="~/Site.Master" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StarTED_Lab.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>A05 - Planned Assessment</h1>
        <p class="lead">Planned Assessment Project by Patricia Mendez-Alva</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <section>
                <h2>Lab Documententation</h2>
                <p>
                    Here, I'll be listing everything to do with my project, which is A05 - Planned Assessment. 
                </p>
            </section>
            <section>
                <h3>Form A Description</h3>
                <div>
                    <p>FormA.System is where our BLL and DAL are stored, meaning our controllers and stored procedures are stored here. It references FormA.Data.</p>
                    <p>FormA.Data contains our classes, where we have fully and manually implemented properties to grav from our database.</p>
                    <p>StarTED Database is what holds our site master, our pages, our web sontraints and so on. It's basically the meat on the bones, so to speak, and links to our Forms (currently only A is active).</p>
                    <p>StarTED WebApp references both FormA.System and FormA.Data.</p>
                    <p>Form A is the Web Form CRUD.</p>
                </div>
            </section>
            <section>
                <h3>Known Bugs</h3>
                <div>
                      Current issues:
                    <p>Once everything has been entered and Select has been pressed, the program will crash trying to populate the list since AssessmentList isn't mapped somehow.</p>
                </div>
            </section>
            <section>
                <h3>Entity Relationship Diagram</h3>
                <p>
                    <asp:Image ID="CourseERD" runat="server" src="Image/CourseERD.PNG" alt="ERD"/>
                </p>
            </section>
            <section>
                <h3>Stored Procedures</h3>
                <div>
                    <h4>Used:</h4>
                    <p>-"public DbSet<Course> Courses { get; set; }"</p>
                    <p>-"public DbSet<PlannedAssessments> PlannedAssessments { get; set; }"</p>
                    <p>-"public DbSet<AssessmentTypes> AssessmentTypes { get; set; }"</p>
                    <p>-"public AssessmentTypes AssessmentTypes_Get(int assessmenttypeid)"</p>
                    <p>-"public List<AssessmentTypes> AssessmentType_List()"</p>
                    <p>-"public Course Course_Get(int courseid)"</p>
                    <p>-"public List<Course> Course_List()"</p>
                    <p>-"public List<Course> Courses_FindByPartialName(string partialname)"</p>
                    <p>-"public PlannedAssessments PlannedAssessment_Get(int assessmentid)"</p>
                    <p>-"public List<PlannedAssessments> PlannedAssessment_List()"</p>
                    <p>-"public List<PlannedAssessment> PlannedAssessments_FindByCourse(string courseid)"</p>
                    <p>-"public List<PlannedAssessment> PlannedAssessments_GetByCourseNamePartial(int courseid, string partialcoursename)"</p>
                    <p>-"public int PlannedAssessment_Add(PlannedAssessment item)"</p>
                    <p>-"public int PlannedAssessment_Update(PlannedAssessment item)"</p>
                    <p>-"public int PlannedAssessment_Delete(int assessid)"</p>
                </div>
            </section>
        </div>        
    </div>

</asp:Content>