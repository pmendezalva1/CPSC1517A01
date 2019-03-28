using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeExercises
{
    public class CDInfo
    {
        public string ISBN { get; set; }
        public string CDTitle { get; set; }
        public string Artists { get; set; }
        public int Year { get; set; }
        public int Tracks { get; set; }

        public CDInfo()
        {

        }
        public CDInfo(string isbn, string cdtitle, string artists, int year, int tracks)
        {
            ISBN = isbn;
            CDTitle = cdtitle;
            Artists = artists;
            Year = year;
            Tracks = tracks;
        }
    }
}