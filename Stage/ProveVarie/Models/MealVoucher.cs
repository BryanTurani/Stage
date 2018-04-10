using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProveVarie.Models
{
    public class MealVoucher
    {
        public int ID { get; set; }
        public decimal Barcode { get; set; }
        public DateTime? AssignementDate { get; set; }
        public DateTime? UseDate { get; set; }

        public int CarnetID { get; set; }
        public Carnet Carnet { get; set; }

    }
}