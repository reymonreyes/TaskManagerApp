using Microsoft.EntityFrameworkCore;
using Models = TaskManagerApp.Models;

namespace TaskManagerApp.Data
{
    public class TaskManagerAppContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TaskManagerAppContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.Attachment> Attachments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TaskManagerAppContextConnection"));
        }
    }
}
