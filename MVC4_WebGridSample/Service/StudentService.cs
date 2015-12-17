using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4_WebGridSample.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC4_WebGridSample.Service
{
    public class StudentService
    {
        public StudentViewModel GetFilterData(StudentViewModel model)
        {
            model.Page = model.Page == 0 ? 1 : model.Page;
            model.PageSize = 10;
            model.Sort = string.IsNullOrEmpty(model.Sort) ? "ID" : model.Sort;
            model.Sortdir = string.IsNullOrEmpty(model.Sortdir) ? "ASC" : model.Sortdir;
            model.StudentData = GetStudents(model.Page, model.PageSize, model.Sort, model.Sortdir);
            model.TotalCount = model.StudentData.Count();
            return model;
        }

        public IList<Student> GetStudents(int Page, int PageSize, string Sort, string Sortdir)
        {
            string connectionStringName = System.Configuration.ConfigurationManager.ConnectionStrings["StudentDBContext"].ConnectionString;
            IList<Student> _Student = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionStringName))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT ID, FirstName,LastName,IsActive FROM Student;", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _Student.Add(new Student()
                        {
                            ID = Convert.ToInt32(reader["ID"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        });
                    }
                }
                reader.Close();
            }

            return _Student;
        }

    }
}