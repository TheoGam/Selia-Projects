using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Tache> Taches { get; set; }
        public DbSet<User> Users { get; set; }
    }
}