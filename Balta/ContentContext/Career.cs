using System.Collections.Generic;

namespace Balta.ContentContext
{
    public class Carrer : Content
    {
        public Carrer(string title, string url)
            : base(title, url)
        {
            Courses = new List<CarrerItem>();
        }
        public List<CarrerItem> Courses { get; set; }
        public int TotalCourser => Courses.Count;
    }
}