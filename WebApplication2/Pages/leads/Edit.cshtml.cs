using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

using Microsoft.EntityFrameworkCore.Query.Internal;
using static WebApplication2.Pages.leads.Lead_InfoModel;

namespace WebApplication2.Pages.leads
{
    public class EditModel : PageModel
    {
        public ProjectInfo projectInfo = new ProjectInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String id = Request.Query["id"];
            try
            {
                String connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProjectDB2;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM projects WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
//                                ProjectInfo projectinfo = new ProjectInfo();
                                projectInfo.id = "" + reader.GetInt32(0);
                                projectInfo.ProjectName = reader.GetString(1);
                                projectInfo.email = reader.GetString(2);
                                projectInfo.phone = reader.GetString(3);
                                projectInfo.address = reader.GetString(4);
//                                projectinfo.created_at = reader.GetDateTime(5).ToString();

                                //listProjects.Add(projectinfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            projectInfo.id = Request.Form["id"];
            projectInfo.ProjectName = Request.Form["ProjectName"];
            projectInfo.email = Request.Form["email"];
            projectInfo.phone = Request.Form["phone"];
            projectInfo.address = Request.Form["address"];

            try
            {
                String connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProjectDB2;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE projects " +
                                 "SET ProjectName=@ProjectName, email=@email, phone=@phone, address=@address " +
                                 "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectName", projectInfo.ProjectName);
                        command.Parameters.AddWithValue("@email", projectInfo.email);
                        command.Parameters.AddWithValue("@phone", projectInfo.phone);
                        command.Parameters.AddWithValue("@address", projectInfo.address);
                        command.Parameters.AddWithValue("@id", projectInfo.id);

                        command.ExecuteNonQuery();                        
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/leads/Lead_Info");
        }
    }
}
