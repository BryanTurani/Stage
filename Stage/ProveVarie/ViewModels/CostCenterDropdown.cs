using ProveVarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProveVarie.ViewModels
{
    public class CostCenterDropdown
    {
        public IEnumerable<SelectListItem> CostCenters { get; set; }
        //public int? ID { get; set; }
        //public string Name { get; set; }
    }
}