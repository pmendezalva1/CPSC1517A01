using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeExercises.Exercises
{
    public partial class MovieLibrary : System.Web.UI.Page
    {
        public static List<Movies> movieList;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                movieList = new List<Movies>();
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string title = MovieTitle.Text;
            int year = int.Parse(MovieYear.Text);
            string review = Review.Text;
            string rating = Rating.Text;
            string isbn = ISBN.Text;

            string media = "";

            foreach(ListItem mediatype in Media.Items)
            {
                if (mediatype.Selected)
                {
                    media += mediatype + " ";
                }
            }
            movieList.Add(new Movies(title, year, media, rating, review, isbn));
            ListMovies.DataSource = movieList;
            ListMovies.DataBind();
        }
    }    
}
