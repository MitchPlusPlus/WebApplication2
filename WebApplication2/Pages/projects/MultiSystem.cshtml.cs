using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.ConstrainedExecution;
using static WebApplication2.Pages.projects.MultSystem.MultiSystemModel; 


namespace WebApplication2.Pages.projects.MultSystem
{
    public class MultiSystemModel : PageModel
    {
        public List<ProjectInfo> listProjects = new List<ProjectInfo>();

        private readonly ILogger<MultiSystemModel> _logger;

        public MultiSystemModel(ILogger<MultiSystemModel> logger)
        {
            _logger = logger;
        }

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
                                projectinfo.Array_ID___Address = reader.GetString(1);
                                projectinfo.Current_Usage = reader.GetString(2);
                                projectinfo.Cost_per_KWh = reader.GetString(3);
                                projectinfo.Total_Cost = reader.GetString(4);
                                projectinfo.Solar_Cost = reader.GetString(5);
                                projectinfo.plus_insure = reader.GetString(6);


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
    }
    public class ProjectInfo
    {
        public String id = "";
        public String Array_ID___Address = "";
        public String Current_Usage = "";
        public String Cost_per_KWh = "";
        public String Total_Cost = "";
        public String Solar_Cost = "";
        public String plus_insure = "";
        


    }
}
