using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProveVarie.Models
{
    public class CostCenter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OfficeManager { get; set; }

        public List<Carnet> Carnets { get; set; }

    }
}