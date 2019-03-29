using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using FormA.BLL;
using FormA.Data;

#endregion

namespace StarTED_Lab.Pages
{
    public partial class FormA : System.Web.UI.Page
    {
        List<string> errors = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                BindPlannedAssessmentList();
                BindCourseList();
                //BindAssessmentTypesList();
            }
        }

        protected void BindPlannedAssessmentList()
        {
            try
            {
                PlannedAssessmentController sysmgr = new PlannedAssessmentController();
                List<PlannedAssessments> datainfo = sysmgr.PlannedAssessment_List();
                datainfo.Sort((x, y) => x.Name.CompareTo(y.Name)); //Asc sort
                PlannedAssessmentList.DataSource = datainfo;
                PlannedAssessmentList.DataTextField = nameof(PlannedAssessments.Name);
                PlannedAssessmentList.DataValueField = nameof(PlannedAssessments.AssessmentID);
                PlannedAssessmentList.DataBind();
                PlannedAssessmentList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errors.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errors, "alert alert-danger");
            }
        }

        protected void BindCourseList()
        {
            try
            {
                CourseController sysmgr = new CourseController();
                List<Course> datainfo = sysmgr.Course_List();
                datainfo.Sort((x, y) => x.CourseName.CompareTo(y.CourseName)); //Asc sort
                CourseList.DataSource = datainfo;
                CourseList.DataTextField = nameof(Course.CourseName);
                CourseList.DataValueField = nameof(Course.CourseID);
                CourseList.DataBind();
                CourseList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errors.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errors, "alert alert-danger");
            }
        }

        protected void BindAssessmentTypesList()
        {
            try
            {
                AssessmentTypesController sysmgr = new AssessmentTypesController();
                List<AssessmentTypes> datainfo = sysmgr.AssessmentType_List();
                datainfo.Sort((x, y) => x.Name.CompareTo(y.Name));
                PlannedAssessmentList.DataSource = datainfo;
                PlannedAssessmentList.DataTextField = nameof(Course.CourseName);
                PlannedAssessmentList.DataValueField = nameof(Course.CourseID);
                PlannedAssessmentList.DataBind();
                PlannedAssessmentList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errors.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errors, "alert alert-danger");
            }
        }

        //Find the innermost errors with this:
        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        //Use this to have messages written out:
        protected void LoadMessageDisplay(List<string> errorslist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errorslist;
            Message.DataBind();
        }

        //This affects PA! If it can find something, it loads it in the DDL to be clicked on later.
        protected void SearchPlannedAssessmentsPartial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchPartialName.Text))
            {
                errors.Add("Please enter a partial course name for the search!");
                LoadMessageDisplay(errors, "alert alert-info");
                CoursesGridView.DataSource = null;
                CoursesGridView.DataBind();
            }
            else
            {
                try
                {
                    CourseController sysmgr = new CourseController();
                    List<Course> datainfo = sysmgr.Courses_FindByPartialName(PartialName.Text);
                    if (datainfo.Count == 0)
                    {
                        errors.Add("No data found for the partial course name.");
                        LoadMessageDisplay(errors, "alert, alert-info");
                    }
                    else
                    {
                        //datainfo.Sort((x, y) => x.CourseName.CompareTo(y.CourseName));
                        //foreach (ListItem name in CourseList.Text)
                        //{
                        //    if(string.Contains(PartialName.Text))
                        //    {

                        //    }
                        //}
                        //GV
                        CoursesGridView.DataSource = datainfo;
                        CoursesGridView.DataBind();
                    }
                }
                catch(Exception ex)
                {
                    errors.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
            }
        }

        protected void SearchCoursesPartial_Click(object sender, EventArgs e)
        {
            //if (PlannedAssessmentList.SelectedIndex == 0)
            if (string.IsNullOrEmpty(SearchPartialName.Text))
            {
                //No selection
                errors.Add("Select a course to view an assessment.");
                LoadMessageDisplay(errors, "alert alert-danger");
                PlannedAssessmentList.DataSource = null;
                PlannedAssessmentList.DataBind();
            }
            //else if (string.IsNullOrEmpty(CourseAssess.Text))
            //{
            //    errors.Add("Enter a course (partial) name.");
            //    LoadMessageDisplay(errors, "alert alert-danger");
            //    CoursesGridView.DataSource = null;
            //    CoursesGridView.DataBind();
            //}
            else
            {
                //Process request for lookup here
                try
                {
                    PlannedAssessmentController sysmgr = new PlannedAssessmentController();
                    List<PlannedAssessments> datainfo = sysmgr.PlannedAssessment_FindByCourse(
                        int.Parse(PlannedAssessmentList.SelectedValue),
                        CourseAssess.Text);
                    if (datainfo.Count == 0)
                    {
                        errors.Add("No data found for the partial course name.");
                        LoadMessageDisplay(errors, "alert alert-danger");
                    }
                    else
                    {
                        datainfo.Sort((x, y) => x.Name.CompareTo(y.Name));

                        CourseList.DataTextField = nameof(Course.Description);
                        CourseList.DataValueField = nameof(Course.CourseID);
                        CourseList.DataBind();
                        //CourseList.Items.Insert(0, "select....");
                    }
                }
                catch (Exception ex)
                {
                    errors.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
            }
        }

        protected void CoursesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CoursesGridView.PageIndex = e.NewPageIndex;
            SearchCoursesPartial_Click(sender, new EventArgs());
            GridViewRow cgvrow = CoursesGridView.Rows[CoursesGridView.SelectedIndex];
            string courseid = (cgvrow.FindControl("CourseID") as Label).Text;
            string coursename = (cgvrow.FindControl("CourseName") as Label).Text;
            string description = (cgvrow.FindControl("Description") as Label).Text;
        }

        protected void AssessSearch_Click(object sender, EventArgs e)
        {
            string partialname = CourseAssess.Text;
            if (string.IsNullOrEmpty(partialname))
            {
                errors.Add("Please put in a partial course name.");
                LoadMessageDisplay(errors, "alert alert-danger");
            }
            else
            {
                CourseList.SelectedValue = CourseAssess.Text;
                CoursesGridView.DataSource = partialname;
                CoursesGridView.DataBind();
            }
        }
    }
}