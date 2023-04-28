using Taskr.Models.Domain;

namespace Taskr.ViewModel
{
    public class ToDoViewModel
    {
        public ToDoList ToDoList { get; set; }
        public List<ToDoList> ToDoLists { get; internal set; }
    }
}
