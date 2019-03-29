<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="StarTED_Lab.About" %>
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
                    
                </p>
            </section>
            <section>
                <h3>Known Bugs</h3>
                <p>
                      Current issues:
                    <div>When trying to use the search function for Courses, it can't find anything from the database.</div>
                    <div>Despite this, somehow the assessmentd ddl still load. Unfortunately, the need for a course prevents this from working.</div>
                    <div>The stored procedures seem broken, so I can't test the next phase to see if the gridview will load up.</div>
                    <div>Home and Default fail to redirect for some reason, they don't consider themselves part of the class.</div>
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