using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MVC4_WebGridSample.Models
{
    public class StudentViewModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string Sort { get; set; }
        public string Sortdir { get; set; }
        public IList<Student> StudentData { get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public Student()
        {
        }
    }
}