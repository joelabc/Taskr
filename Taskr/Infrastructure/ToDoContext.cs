using Microsoft.EntityFrameworkCore;
using Taskr.Models;
using Taskr.Models.Domain;

namespace Taskr.Infrastructure
{
    public class ToDoContext : DbContext
    {
       
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
