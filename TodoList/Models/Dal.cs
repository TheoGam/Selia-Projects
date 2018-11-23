﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public List<Tache> GetAllTasks()
        {
            return bdd.Taches.ToList();
        }

        public void CreateTask(string description, User user)
        {
            Tache newTask = new Tache { Description = description, User = user };
            bdd.Taches.Add(newTask);
            bdd.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return bdd.Users.ToList();
        }

        public void CreateUser(string name)
        {
            bdd.Users.Add(new User { Name = name });
            bdd.SaveChanges();
        }

    }
}