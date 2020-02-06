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
    /// Summary description for EmployeeWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select *from employee", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();

                    employee.ID = Convert.ToInt32( rdr["ID"]);
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.LastName= rdr["LastName"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);

                    employees.Add(employee);

                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer(); //this line basically converts the data into the json formate
            Context.Response.Write(js.Serialize(employees));
        }
    }
}
