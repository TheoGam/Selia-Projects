using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    interface IDal : IDisposable
    {
        List<Tache> GetAllTasks();
        void CreateTask(string description, User user);
        List<User> GetAllUsers();
        void CreateUser(string name);
        List<Tache> GetCompletedTasks();
        List<Tache> GetNotCompletedTasks();
    }
}
