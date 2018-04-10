using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProveVarie.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FiscalCode { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}