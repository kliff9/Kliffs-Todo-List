using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KliffsTodo.Models
{
    public class The_Todo_class
    {
        public int Id { get; set; }
        public string Description { get; set; }   
        public bool Finished { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}