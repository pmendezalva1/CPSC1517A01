using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeExercises.Exercises
{
    public partial class CDLibrary : System.Web.UI.Page
    {
        public static List<CDInfo> SongInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                SongInfo = new List<CDInfo>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string isbn = ISBN.Text;
            string title = Title.Text;
            string artists = Artists.Text;
            int year = int.Parse(Year.Text);
            int tracks = int.Parse(Tracks.Text);
            Message.Text = "Added!";

            SongInfo.Add(new CDInfo(isbn, title, artists, year, tracks));
            songList.DataSource = SongInfo;
            songList.DataBind();
        }
    }
}