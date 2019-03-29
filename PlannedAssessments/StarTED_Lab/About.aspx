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
                    <div>When trying to use the search function for Courses, it fails to find our stored procedure "Course_GetByPartialName"</div>
                    <div>Despite this, somehow the assessments still load. Unfortunately, the need for a course prevents this from working.</div>
                    <div>The stored procedures seem broken, so I can't test the next phase to see if the gridview will load up.</div>
                </p>
            </section>
            <section>
                <h3>Entity Relationship Diagram</h3>
                <p>
                    <asp:Image ID="CourseERD" runat="server" src="~/Image/CourseERD.PNG" alt="ERD"/>
                </p>
            </section>
            <section>
                <h3>Stored Procedures</h3>
                <p>
                    <h4>Used:</h4>
                    <div>"public DbSet<Course> Courses { get; set; }"</div>
                    <div>"public DbSet<PlannedAssessments> PlannedAssessments { get; set; }"</div>
                    <div></div>"public DbSet<AssessmentTypes> AssessmentTypes { get; set; }"</div>
                             </div>
                    <h4>To Be Implemented:</h4>
                    <div>"SELECT CourseID, CourseName, Credits, TotalHours, ClassroomType, Term, Tuition, Description
                         FROM Courses ORDER BY CourseName"
                    </div>
                    <div>
                        "SELECT AssessmentID, Name, AssessmentTypeID, Description, CourseID, Weight, RequiredPass, LastModified
                        FROM PlannedAssessments ORDER BY Name"
                    </div>
                    <div>
                        "SELECT AssessmentTypeID, Name from AssessmentTypes ORDER BY Name"
                    </div>
                    <div>
                        "SELECT CourseID, Name FROM PlannedAssessments WHERE CourseID = @0"
                    </div>
                </p>
            </section>
        </div>        
    </div>

</asp:Content>