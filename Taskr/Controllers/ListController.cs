using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Diagnostics;
using Taskr.Infrastructure;
using Taskr.Models;
using Taskr.Models.Domain;
using Taskr.ViewModel;

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
        public async Task<IActionResult> Add()
        {
            ToDoViewModel toDoViewModel = new ToDoViewModel();
            toDoViewModel.ToDoList = new ToDoList();
            toDoViewModel.ToDoList.DueDate = DateTime.Now;  
            toDoViewModel.ToDoLists = await mvcTodoContext.ToDoList.ToListAsync();
            return View(toDoViewModel);
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
        public async Task<IActionResult> CompleteToDo(UpdateTaskStatusViewModel completeTask)
        {
            var  completedTask = await mvcTodoContext.ToDoList.FindAsync(completeTask.Id);

            if(completedTask != null)
            {
                completedTask.Name = completeTask.Name;
                completedTask.DueDate = completeTask.DueDate;
                completedTask.Description = completeTask.Description;
                completedTask.Status = true;
                completedTask.Tag = completeTask.Tag;
                
                await mvcTodoContext.SaveChangesAsync();
                return RedirectToAction("TaskList");
            }
            return RedirectToAction("TaskList");

        }


        [HttpPost]
        public async Task<IActionResult> Add(ToDoViewModel addNewTask)
        {
            var list = new ToDoList()
            {
                Id = Guid.NewGuid(),
                Name = addNewTask.ToDoList.Name,
                DueDate = addNewTask.ToDoList.DueDate,
                Description = addNewTask.ToDoList.Description,
                Status = addNewTask.ToDoList.Status,
                Tag = addNewTask.ToDoList.Tag
            };

            await mvcTodoContext.AddAsync(list);
            await mvcTodoContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

    }
}
