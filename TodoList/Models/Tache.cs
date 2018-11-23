using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Tache
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public Boolean IsArchived { get; set; }
        public Boolean IsCompleted { get; set; }
        public User User { get; set; } 
    }
}