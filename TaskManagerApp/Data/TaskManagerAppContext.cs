using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models = TaskManagerApp.Models;

namespace TaskManagerApp.Data
{
    public class TaskManagerAppContext : DbContext
    {
        IConfiguration _configuration;
        public TaskManagerAppContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStr = _configuration.GetConnectionString("TaskManagerAppContextConnection");
            optionsBuilder.UseSqlServer(connectionStr);// "Data Source=REYMON\\SQLEXPRESS;Initial Catalog=TaskManagerApp;User ID=appuser;Password=mypassword;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
