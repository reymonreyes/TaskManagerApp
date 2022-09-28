using Microsoft.EntityFrameworkCore;
using Models = TaskManagerApp.Models;

namespace TaskManagerApp.Data
{
    public class TaskManagerAppContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=REYMON\\SQLEXPRESS;Initial Catalog=TaskManagerApp;User ID=appuser;Password=mypassword;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
