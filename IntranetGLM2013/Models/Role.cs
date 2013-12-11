using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntranetGLM2013.Models;

namespace IntranetGLM2013.Models
{
    public enum ActionRole : int { view = 1, html = 2, external = 3 }

    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconURL { get; set; }
        public ActionRole Action { get; set; }
        public bool InMenuPpal { get; set; }
        public bool InMenuPersonal { get; set; }
        public bool IsActive { get; set; }
        public int? IdFather { get; set; }

        //public virtual ICollection<Person> People { get; set; }
    }
}