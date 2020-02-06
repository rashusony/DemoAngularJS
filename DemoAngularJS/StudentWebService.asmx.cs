using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace DemoAngularJS
{
    /// <summary>
    /// Summary description for StudentWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StudentWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetAllStudent()
        {
            List<Student> Liststudent = new List<Student>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select *from Student", con);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();

                    student.Id = Convert.ToInt32( rdr["Id"]);
                    student.Name = rdr["Name"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    student.City = rdr["City"].ToString();

                    Liststudent.Add(student);
                }
            }

            JavaScriptSerializer JS = new JavaScriptSerializer();

            Context.Response.Write(JS.Serialize(Liststudent));
        }

        [WebMethod]

        public void GetStudent(int Id)
        {
            Student student = new Student();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select *from Student where Id=@Id", con);

                SqlParameter param = new SqlParameter()
                {
                    ParameterName="@Id",
                    Value=Id
                };

                cmd.Parameters.Add(param);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    

                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.Name = rdr["Name"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    student.City = rdr["City"].ToString();

                    
                }
            }

            JavaScriptSerializer JS = new JavaScriptSerializer();

            Context.Response.Write(JS.Serialize(student));
        }


        [WebMethod]
        public void GetStudentByName( string name)
        {
            List<Student> Liststudent = new List<Student>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select *from Student where Name like @name", con);

                SqlParameter para = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = name + '%'
                };

                cmd.Parameters.Add(para);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();

                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.Name = rdr["Name"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    student.City = rdr["City"].ToString();

                    Liststudent.Add(student);
                }
            }

            JavaScriptSerializer JS = new JavaScriptSerializer();

            Context.Response.Write(JS.Serialize(Liststudent));
        }

        [WebMethod]
        public void AddStudent(string name,string gender,string city)
        {
            List<Student> Liststudent = new List<Student>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into Student values(@name,@gender,@city)", con);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@city", city);
                SqlParameter para = new SqlParameter();

                con.Open();

                cmd.ExecuteNonQuery();

            }

        }


    }
}
