using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntranetGLM2013.Models
{
    public enum SSOProvider : int { google = 1, microsoft = 2, yahoo = 3 }

    public class Person
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public SSOProvider Provider { get; set; }

        //public virtual ICollection<Role> Roles { get; set; }
    }

}