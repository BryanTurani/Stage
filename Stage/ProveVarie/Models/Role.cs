using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProveVarie.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }

    }
}