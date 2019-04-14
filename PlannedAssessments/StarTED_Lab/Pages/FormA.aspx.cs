using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using A05_System.BLL;
using A05_System.Data;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
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
                BindAssessmentTypesList();
            }
        }
        protected void BindPlannedAssessmentList()
        {
            try
            {
                PlannedAssessmentController sysmgr = new PlannedAssessmentController();
                List<PlannedAssessment> datainfo = sysmgr.PlannedAssessment_List();
                datainfo.Sort((x, y) => x.Name.CompareTo(y.Name)); //Asc sort
                CourseList.DataSource = datainfo;
                CourseList.DataTextField = nameof(PlannedAssessment.Name);
                CourseList.DataValueField = nameof(PlannedAssessment.AssessmentID);
                CourseList.DataBind();
                CourseList.Items.Insert(0, "select...");

                AssessmentList.DataSource = datainfo;
                AssessmentList.DataTextField = nameof(PlannedAssessment.Name);
                AssessmentList.DataValueField = nameof(PlannedAssessment.AssessmentID);
                AssessmentList.DataBind();
                AssessmentList.Items.Insert(0, "select...");
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

                CourseIDList.DataSource = datainfo;
                CourseIDList.DataTextField = nameof(Course.CourseName);
                CourseIDList.DataValueField = nameof(Course.CourseID);
                CourseIDList.DataBind();
                CourseIDList.Items.Insert(0, "select...");
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
                CourseList.DataSource = datainfo;
                CourseList.DataTextField = nameof(AssessmentType.Name);
                CourseList.DataValueField = nameof(AssessmentType.AssessmentTypeID);
                CourseList.DataBind();
                CourseList.Items.Insert(0, "select...");

                AssessmentList.DataSource = datainfo;
                AssessmentList.DataTextField = nameof(PlannedAssessment.Name);
                AssessmentList.DataValueField = nameof(PlannedAssessment.AssessmentTypeID);
                AssessmentList.DataBind();
                AssessmentList.Items.Insert(0, "select...");

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
            if (string.IsNullOrEmpty(PartialName.Text))
            {
                //No selection
                errors.Add("Enter a course to view an assessment.");
                LoadMessageDisplay(errors, "alert alert-danger");
                CourseList.DataSource = null;
                CourseList.DataBind();
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

                        //GV
                        CourseList.DataSource = datainfo;
                        CourseList.DataTextField = nameof(Course.CourseName);
                        CourseList.DataValueField = nameof(Course.CourseID);
                        CourseList.DataBind();
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
        protected void SearchPlannedAssessments_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CourseList.Text))
            {
                errors.Add("Please select a planned assessment.");
                LoadMessageDisplay(errors, "alert alert-info");
                AssessmentsGridView.DataSource = null;
                AssessmentsGridView.DataBind();
            }
            else
            {
                PlannedAssessmentController sysmgr = new PlannedAssessmentController();
                List<PlannedAssessment> datainfo = sysmgr.PlannedAssessments_FindByCourse(
                    CourseList.SelectedValue);
                try
                {
                    if (datainfo.Count == 0)
                    {
                        errors.Add("No data found for the partial course name.");
                        LoadMessageDisplay(errors, "alert, alert-info");
                    }
                    else
                    {
                        datainfo.Sort((x, y) => x.Name.CompareTo(y.Name));
                        CourseList.DataSource = datainfo;
                        CourseList.DataTextField = nameof(PlannedAssessment.Name);
                        CourseList.DataValueField = nameof(PlannedAssessment.AssessmentID);
                        CourseList.DataBind();
                        CourseList.Items.Insert(0, "select...");
                        //GV
                        AssessmentsGridView.DataSource = datainfo;
                        AssessmentsGridView.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    errors.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
            }
        }

        protected void AssessmentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AssessmentsGridView.PageIndex = e.NewPageIndex;
            SearchPlannedAssessments_Click(sender, new EventArgs());
            GridViewRow agvrow = AssessmentsGridView.Rows[AssessmentsGridView.SelectedIndex];
            string assessmentid = (agvrow.FindControl("AssessmentID") as Label).Text;
            string name = (agvrow.FindControl("Name") as Label).Text;
            string description = (agvrow.FindControl("Description") as Label).Text;
        }

        protected void AssessmentsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agvrow = AssessmentsGridView.Rows[AssessmentsGridView.SelectedIndex];
            AssessmentID.Text = (agvrow.FindControl("AssessmentID") as Label).Text;
            Name.Text = (agvrow.FindControl("Name") as Label).Text;
            AssessmentList.SelectedValue = (agvrow.FindControl("AssessmentTypeID") as DropDownList).SelectedValue;
            Description.Text = (agvrow.FindControl("Description") as Label).Text;
            CourseIDList.SelectedValue = (agvrow.FindControl("CourseID") as DropDownList).SelectedValue;
            Weight.Text = (agvrow.FindControl("Weight") as Label).Text;
            Required.Checked = (agvrow.FindControl("RequiredPass") as CheckBox).Checked;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if(AssessmentList.SelectedIndex == 0)
            {
                errors.Add("Select an assessment.");
            }
            if(CourseIDList.SelectedIndex == 0)
            {
                errors.Add("Select a course.");
            }
            if(errors.Count() > 0)
            {
                LoadMessageDisplay(errors, "alert alert-info");
            }
            else
            {
                try
                {
                    //New instance of T!
                    PlannedAssessment item = new PlannedAssessment();
                    item.Name = Name.Text.Trim();
                    item.AssessmentTypeID = int.Parse(CourseList.SelectedValue);
                    item.Description = Description.Text.Trim();
                    item.CourseID = CourseList.SelectedValue;
                    if(string.IsNullOrEmpty(Weight.Text.Trim()))
                    {
                        item.Weight = null;
                    }
                    else
                    {
                        item.Weight = Int16.Parse(Weight.Text.Trim());
                    }
                    item.RequiredPass = false;
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errors.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errors.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errors.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errors.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (AssessmentList.SelectedIndex == 0)
            {
                errors.Add("Select an assessment.");
            }
            if (CourseIDList.SelectedIndex == 0)
            {
                errors.Add("Select a course.");
            }
            if (string.IsNullOrEmpty(AssessmentID.Text.Trim()))
            {
                errors.Add("Search for the planned assessment you wish to update.");
            }
            if(errors.Count() > 0)
            {
                LoadMessageDisplay(errors, "alert alert-info");
            }
            else
            {
                try
                {
                    PlannedAssessment item = new PlannedAssessment();
                    item.AssessmentID = int.Parse(AssessmentID.Text.Trim());

                    item.Name = Name.Text.Trim();
                    item.AssessmentTypeID = int.Parse(CourseList.SelectedValue);
                    item.Description = Description.Text.Trim();
                    item.CourseID = CourseList.SelectedValue;
                    if (string.IsNullOrEmpty(Weight.Text.Trim()))
                    {
                        item.Weight = null;
                    }
                    else
                    {
                        item.Weight = Int16.Parse(Weight.Text.Trim());
                    }
                    item.RequiredPass = Required.Checked;

                    //Checks if anything updated.
                    PlannedAssessmentController sysmgr = new PlannedAssessmentController();
                    int rowsaffected = sysmgr.PlannedAssessment_Update(item);
                    if(rowsaffected == 0)
                    {
                        errors.Add(Name.Text + "has not been updated. Please search for the course again.");
                        LoadMessageDisplay(errors, "alert alert-warning");
                        BindPlannedAssessmentList();
                    }
                    else
                    {
                        errors.Add(Name.Text + "has been updated.");
                        LoadMessageDisplay(errors, "alert alert-warning");
                        BindPlannedAssessmentList();
                        AssessmentList.SelectedValue = AssessmentList.Text;
                    }
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errors.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errors.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errors.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errors.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
            }
        }
        protected void Discontinued_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(AssessmentID.Text.Trim()))
            {
                errors.Add("Search for the planned assessment you wish to manage.");
            }
            if (errors.Count() > 0)
            {
                LoadMessageDisplay(errors, "alert alert-info");
            }
            else
            {
                try
                {
                    PlannedAssessmentController sysmgr = new PlannedAssessmentController();
                    int rowsaffected = sysmgr.PlannedAssessment_Delete(int.Parse(AssessmentID.Text.Trim()));
                    if(rowsaffected == 0)
                    {
                        errors.Add(Name.Text + "has not been discontinued. Please search for the course again.");
                        LoadMessageDisplay(errors, "alert alert-warning");
                        BindPlannedAssessmentList();
                    }
                    else
                    {
                        errors.Add(Name.Text + "has been discontinued.");
                        LoadMessageDisplay(errors, "alert alert-warning");
                        BindPlannedAssessmentList();
                        Required.Checked = true;
                        AssessmentList.SelectedValue = AssessmentID.Text;
                    }
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errors.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errors.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errors.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errors.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errors, "alert alert-danger");
                }
            }
        }
    }

}