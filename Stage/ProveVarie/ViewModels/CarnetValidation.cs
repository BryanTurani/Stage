using ProveVarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProveVarie.ViewModels
{
    public class CarnetValidation
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string CostCenter { get; set; }

        public static CarnetValidation Map(CostCenterDropdown list, Carnet model)
        {
            return new CarnetValidation()
            {
                Id = model.ID,
                Barcode = model.Barcode,
                //CostCenter = list.CostCenter            
            };
        }
    }    
}