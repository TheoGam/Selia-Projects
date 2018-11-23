using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class HomeViewModel
    {
        public List<Tache> NotCompletedTasks { get; set; }
        public List<Tache> CompletedTasks { get; set; }
    }
}