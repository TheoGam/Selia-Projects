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

        [HttpPost]
        public ActionResult PostDeleteTask(int id)
        {
            dal.DeleteTask(id);
            // Affiche la vue Index
            return RedirectToAction("Index");
        }

        public ActionResult EditTask(int id)
        {
            Tache tacheToUpdate = dal.GetTask(id);
            if (tacheToUpdate != null)
            {
                ViewData.Model = tacheToUpdate;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult PostEditTask(int id, string description, string responsable)
        {
            dal.EditTask(id,description,responsable);
            return RedirectToAction("Index");
        }
    }
}