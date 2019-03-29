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
                <h3>Form Description</h3>
                <p>
                    <div>FormA.System is where our BLL and DAL are stored, meaning our controllers and stored procedures are stored here. It references FormA.Data.</div>
                    <div>FormA.Data contains our classes, where we have fully and manually implemented properties to grav from our database.</div>
                    <div>StarTED Database is what holds our site master, our pages, our web sontraints and so on. It's basically the meat on the bones, so to speak, and links to our Forms (currently only A is active).</div>
                    <div>StarTED WebApp references both FormA.System and FormA.Data.</div>
                </p>
            </section>
            <section>
                <h3>Known Bugs</h3>
                <p>
                      Current issues:
                    <div>-When trying to use the search function for Courses, the ddl won't populate. However, the GridView has worked in the past.</div>
                    <div>-Clicking on the second Courses? button leads to an error in finding the text field.</div>
                    <div>-The autopostback list only loads Assessment A.</div>
                    <div>-If you aren't searching 'acc', 'too many rows' error pops up in first textbox.</div>
                    <div>-Similarly, if you try to search with something less than 3 letters, you get 'too many rows' error.</div>
                </p>
            </section>
            <section>
                <h3>Entity Relationship Diagram</h3>
                <p>
                    <asp:Image ID="CourseERD" runat="server" src="Image/CourseERD.PNG" alt="ERD"/>
                </p>
            </section>
            <section>
                <h3>Stored Procedures</h3>
                <p>
                    <h4>Used:</h4>
                    <div>-"public DbSet<Course> Courses { get; set; }"</div>
                    <div>-"public DbSet<PlannedAssessments> PlannedAssessments { get; set; }"</div>
                    <div>-"public DbSet<AssessmentTypes> AssessmentTypes { get; set; }"</div>
                    <div>-"public AssessmentTypes AssessmentTypes_Get(int assessmenttypeid)"</div>
                    <div>-"public List<AssessmentTypes> AssessmentType_List()"</div>
                    <div>-"public Course Course_Get(int courseid)"</div>
                    <div>-"public List<Course> Course_List()"</div>
                    <div>-"public List<Course> Course_GetByPartialName(string partialname)"</div>
                    <div>-"public List<Course> Courses_FindByPartialName(string partialname)"</div>
                    <div>-"public PlannedAssessments PlannedAssessment_Get(int assessmentid)"</div>
                    <div>-"public List<PlannedAssessments> PlannedAssessment_List()"</div>
                    <div>-"public List<Course> Courses_FindByPartialName(string partialname)"</div>
                  
                </p>
            </section>
        </div>        
    </div>

</asp:Content>