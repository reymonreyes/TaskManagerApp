namespace TaskManagerApp.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
        public string Filename { get; set; }
        public string InternalFilename { get; set; }
    }
}
