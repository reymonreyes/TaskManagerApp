using System.Security.Principal;

namespace TaskManagerApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }
    }
}
