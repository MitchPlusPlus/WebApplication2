using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplication2.Pages.leads
{
    public class Lead_InfoModel : PageModel
    {
        public List<ProjectInfo> listProjects = new List<ProjectInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProjectDB2;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM projects";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProjectInfo projectinfo = new ProjectInfo();
                                projectinfo.id = "" + reader.GetInt32(0);
                                projectinfo.ProjectName = reader.GetString(1);
                                projectinfo.email = reader.GetString(2);
                                projectinfo.phone = reader.GetString(3);
                                projectinfo.address = reader.GetString(4);

                                listProjects.Add(projectinfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public class ProjectInfo
        {
            public String id = "";
            public String ProjectName = "";
            public String email = "";
            public String phone = "";
            public String address = "";
        }
    }
}
