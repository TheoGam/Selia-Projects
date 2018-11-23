using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {

        private IDal dal;

        public HomeController()
        {
            dal = new Dal();
        }

        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel
            {
                NotCompletedTasks = dal.GetNotCompletedTasks(),
                CompletedTasks = dal.GetCompletedTasks()
            };
            return View(vm);
        }

        public ActionResult AddNewTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostAddNewTask(string description, string username)
        {
            using (IDal dal = new Dal())
            {
                dal.CreateTask(description, new User { Name = username });
            }


            return RedirectToAction("Index");
        }
    }
}