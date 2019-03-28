using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeExercises
{
    public class Movies
    {
        public string MovieTitle { get; set; }
        public int MovieYear { get; set; }
        public string Media { get; set; }
        public string Rating { get; set; }
        public string Review { get; set; }
        public string ISBN { get; set; }

        public Movies()
        {

        }
        public Movies(string movietitle, int movieyear, string media, string rating, string review, string isbn)
        {
            MovieTitle = movietitle;
            MovieYear = movieyear;
            Media = media;
            Rating = rating;
            Review = review;
            ISBN = isbn;
        }
    }

}