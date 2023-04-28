namespace Taskr.Models
{
    public class UpdateTaskStatusViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Boolean Status { get; set; }
        public string? Tag { get; set; }
        public DateTime DueDate { get; set; }
    }
}
