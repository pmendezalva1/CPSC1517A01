using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using FSISSystem.PMend.BLL;
using FSISSystem.PMend.Data;

#endregion

namespace BigFootWebApp.ExercisePages
{
    public partial class Default : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                BindGuardianList();
            }
        }

        protected void BindGuardianList()
        {
            try
            {
                GuardianController sysmgr = new GuardianController();
                List<Guardian> datainfo = sysmgr.Guardian_List();
                datainfo.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                GuardianList.DataSource = datainfo;
                GuardianList.DataTextField = nameof(Guardian.FullName);
                GuardianList.DataValueField = nameof(Guardian.GuardianID);
                GuardianList.DataBind();
                GuardianList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (GuardianList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select one of the guardians.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                GuardianList.DataSource = null;
                GuardianList.DataBind();
            }
            else
            {
                try
                {
                    GuardianController sysmgr = new GuardianController();
                    List<Guardian> datainfo = sysmgr.Guardian_Find(int.Parse(GuardianList.SelectedValue));
                    if(datainfo.Count == 0)
                    {
                        errormsgs.Add("No data found for those guardians.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        datainfo.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                        GuardianList.DataSource = datainfo;
                        GuardianList.DataTextField = nameof(Guardian.FullName);
                        GuardianList.DataValueField = nameof(Guardian.GuardianID);
                        BindGuardianList();
                        GuardianList.SelectedValue = LastName.Text;                        
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            GuardianList.ClearSelection();
            Message.DataSource = null;
            Message.DataBind();
        }
    }
}