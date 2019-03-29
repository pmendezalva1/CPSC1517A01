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
                List<PlannedAssessment> datainfo = sysmgr.PlannedAssessment_List();
                datainfo.Sort((x, y) => x.Name.CompareTo(y.Name)); //Asc sort
                PlannedAssessmentList.DataSource = datainfo;
                PlannedAssessmentList.DataTextField = nameof(PlannedAssessment.Name);
                PlannedAssessmentList.DataValueField = nameof(PlannedAssessment.AssessmentID);
                PlannedAssessmentList.DataTextField = nameof(PlannedAssessment.Description);
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
                CourseList.DataTextField = nameof(Course.Description);
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
                List<AssessmentType> datainfo = sysmgr.AssessmentType_List();
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

        //1st Courses? Button
        protected void SearchCoursesPartial_Click(object sender, EventArgs e)
        {
            //if (PlannedAssessmentList.SelectedIndex == 0)
            if (string.IsNullOrEmpty(SearchPartialName.Text))
            {
                //No selection
                errors.Add("Enter a course to view an assessment.");
                LoadMessageDisplay(errors, "alert alert-danger");
                PlannedAssessmentList.DataSource = null;
                PlannedAssessmentList.DataBind();
            }
            else
            {
                //Process request for lookup here
                try
                {
                    CourseController sysmgr = new CourseController();
                    List<Course> datainfo = sysmgr.Courses_FindByPartialName(PartialName.Text);
                    if (datainfo.Count == 0)
                    {
                        errors.Add("No data found for the partial course name.");
                        LoadMessageDisplay(errors, "alert alert-danger");
                    }
                    else
                    {
                        datainfo.Sort((x, y) => x.CourseName.CompareTo(y.CourseName));

                        string ddlist = "";
                        foreach (ListItem ddl in CourseList.Items)
                        {
                            if (ddl.Selected)
                            {
                                ddlist += ddl.Text + " ";
                            }
                        }
                        CourseList.DataValueField = nameof(Course.CourseID);
                        CourseList.DataValueField = nameof(Course.CourseName);
                        CourseList.DataTextField = nameof(Course.Description);
                        CourseList.DataSource = datainfo;
                        CourseList.DataBind();

                        //GV
                        CoursesGridView.DataSource = datainfo;
                        CoursesGridView.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    errors.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
            }
        }

        //This affects PA! If it can find something, it loads it in the DDL to be clicked on later.
        //Assessment?
        protected void SearchPlannedAssessmentsPartial_Click(object sender, EventArgs e)
        {
            if (PlannedAssessmentList.SelectedIndex == 0)
            //if (string.IsNullOrEmpty(SearchPartialName.Text))
            {
                errors.Add("Please select a planned assessment.");
                LoadMessageDisplay(errors, "alert alert-info");
                CoursesGridView.DataSource = null;
                CoursesGridView.DataBind();
            }
            else if (string.IsNullOrEmpty(SearchPartialName.Text))
            {
                errors.Add("Please enter a course name.");
                LoadMessageDisplay(errors, "alert alert-info");
                CoursesGridView.DataSource = null;
                CoursesGridView.DataBind();
            }
            else
            {
                try
                {
                    PlannedAssessmentController sysmgr = new PlannedAssessmentController();
                    List<PlannedAssessment> datainfo = sysmgr.PlannedAssessments_FindByCourse(PartialName.Text);
                    if (datainfo.Count == 0)
                    {
                        errors.Add("No assessment data found for the partial course name.");
                        LoadMessageDisplay(errors, "alert, alert-info");
                    }
                    else
                    {
                        datainfo.Sort((x, y) => x.Name.CompareTo(y.Name));
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

        protected void CoursesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CoursesGridView.PageIndex = e.NewPageIndex;
            SearchCoursesPartial_Click(sender, new EventArgs());
            GridViewRow cgvrow = CoursesGridView.Rows[CoursesGridView.SelectedIndex];
            string courseid = (cgvrow.FindControl("CourseID") as Label).Text;
            string coursename = (cgvrow.FindControl("CourseName") as Label).Text;
            string description = (cgvrow.FindControl("Description") as Label).Text;
        }
        
        //2nd Courses? Button
        protected void AssessSearch_Click(object sender, EventArgs e)
        {

            //if(CourseList.SelectedIndex == 0)
            //{
            //    errors.Add("Please put in a partial course name.");
            //    LoadMessageDisplay(errors, "alert alert-danger");
            //    CoursesGridView.DataSource = null;
            //    CoursesGridView.DataBind();
            //}
            //else
            //{
            //    try
            //    {
            //        PlannedAssessmentController sysmgr = new PlannedAssessmentController();
            //        List<PlannedAssessments> datainfo = sysmgr.PlannedAssessment_Get(CourseAssess.Text);
            //        if(datainfo.Count == 0)
            //        {
            //            errors.Add("Please put in a partial course name.");
            //            LoadMessageDisplay(errors, "alert alert-danger");
            //        }
            //        else
            //        {
            //            datainfo.Sort((x, y) => x.Name.CompareTo(y.Name));
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        errors.Add(GetInnerException(ex).ToString());
            //        LoadMessageDisplay(errors, "alert, alert-danger");
            //    }
            //}
            string partialname = CourseAssess.Text;
            if (string.IsNullOrEmpty(partialname))
            {
                errors.Add("Please put in a partial course name.");
                LoadMessageDisplay(errors, "alert alert-danger");
            }
            else
            {
                string ddlist2 = "";
                foreach (ListItem ddl in CourseList.Items)
                {
                    if (ddl.Selected)
                    {
                        ddlist2 += ddl.Text + " ";
                    }
                }
                CoursesGridView.DataSource = partialname;
                CoursesGridView.DataBind();
            }
        }
    }
}