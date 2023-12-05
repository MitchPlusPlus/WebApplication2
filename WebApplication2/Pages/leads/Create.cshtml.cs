using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Data.SqlClient;
using static WebApplication2.Pages.leads.Lead_InfoModel;

namespace WebApplication2.Pages.leads
{
    public class CreateModel : PageModel
    {

        public ProjectInfo projectInfo = new ProjectInfo();

        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
        }
        public void OnPost()
        {
            projectInfo.ProjectName = Request.Form["ProjectName"];
            projectInfo.email = Request.Form["email"];
            projectInfo.phone = Request.Form["phone"];
            projectInfo.address = Request.Form["address"];

//            if (projectInfo.ProjectName.Length == 0 || projectInfo.email.Length == 0 || projectInfo.email.Length == 0 || projectInfo.address.email.Length == 0)

            if (projectInfo.ProjectName.Length == 0 || projectInfo.address.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }

            // save to db
            try
            {
                String connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProjectDB2;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO projects " +
                                 "(projectName, email, phone, address) VALUES " +
                                 "(@ProjectName, @email, @phone, @address );";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectName", projectInfo.ProjectName);
                        command.Parameters.AddWithValue("@email", projectInfo.email);
                        command.Parameters.AddWithValue("@phone", projectInfo.phone);
                        command.Parameters.AddWithValue("@address", projectInfo.address);

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            projectInfo.ProjectName = "";
            projectInfo.email = "";
            projectInfo.phone = "";
            projectInfo.address = "";

            successMessage = "New Client Added Correctly";

            Response.Redirect("/leads/Lead_Info");
        }
    }
}
