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
            Tache newTask = new Tache { Description = description, User = user, CreationDate = DateTime.Now,
            IsArchived = false, IsCompleted = false };
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

        public List<Tache> GetCompletedTasks()
        {
            string query = "SELECT * FROM Taches WHERE IsArchived = 0 AND IsCompleted = 1";
            return bdd.Taches.SqlQuery(query).ToList();
        }
        public List<Tache> GetNotCompletedTasks()
        {
            string query = "SELECT * FROM Taches WHERE IsArchived = 0 AND IsCompleted = 0";
            return bdd.Taches.SqlQuery(query).ToList();
        }

        public void DeleteTask(int id)
        {
            // Obtenir la tâche à supprimer
            var taskToDelete = bdd.Taches.First(m => m.Id == id);

            // Suppression
            bdd.Taches.Remove(taskToDelete);
            bdd.SaveChanges();
        }

        public Tache GetTask(int id)
        {
            return bdd.Taches.FirstOrDefault(t => t.Id == id);
        }

        public void EditTask(int id, string description, string responsable)
        {
            Tache tacheToUpdate = bdd.Taches.FirstOrDefault(t => t.Id == id);
            if (tacheToUpdate != null)
            {
                tacheToUpdate.Description = description;
                tacheToUpdate.User = new User { Name = responsable };
                bdd.SaveChanges();
            }
        }

    }
}