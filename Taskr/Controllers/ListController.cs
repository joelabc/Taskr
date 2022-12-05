using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Taskr.Infrastructure;
using Taskr.Models.Domain;


namespace Taskr.Controllers
{
    public class ListController : Controller
    {
        private readonly ToDoContext mvcTodoContext;

        public ListController(ToDoContext mvcTodoContext)
        {
            this.mvcTodoContext = mvcTodoContext;
        }

        public ToDoContext ToDoContext { get; }
        [HttpGet]
        public async Task<IActionResult> TaskList()
        {
            var taskList = await mvcTodoContext.ToDoList.ToListAsync();
            return View(taskList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult View(Guid id)
        {
            var taskView = mvcTodoContext.ToDoList.FirstOrDefaultAsync(x => x.Id == id);
            return View(taskView);
        }

        //public JsonResult Search(string SearchInput)
        //{
        //    var temp = SearchInput;

        //    // TODO: look up database and return multiple rows
        //    SearchModel searchModel = new SearchModel
        //    {
        //        Id = IdFromDatabase,
        //        Title = TitleFromDatabase,
        //        //add more if you want according to your model
        //    }

        //return Json(searchModel);
        //}
        [HttpPost]
        public async Task<IActionResult> Add(ToDoList addNewTask)
        {
            var list = new ToDoList()
            {
                Id = Guid.NewGuid(),
                Name = addNewTask.Name,
                DueDate = addNewTask.DueDate,
                Description = addNewTask.Description,
                Status = addNewTask.Status,
                Tag = addNewTask.Tag
            };

            await mvcTodoContext.AddAsync(list);
            await mvcTodoContext.SaveChangesAsync();
            ModelState.Clear();
            return View();
        }

    }
}
