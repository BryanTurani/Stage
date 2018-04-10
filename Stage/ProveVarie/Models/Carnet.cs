using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProveVarie.Models
{
    public class Carnet
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a barcode for the carnet")]
        //[StringLength(13, MinimumLength = 13, ErrorMessage ="Please enter a valid barcode")]
        public string Barcode { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        //[Range(1,50, ErrorMessage = "Insert a value between 1 and 50")]
        public int Capacity { get; set; }


        public string Stockist { get; set; }

        public decimal Cost { get; set; }

        public DateTime? AssignmentDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int? CostCenterID { get; set; }
        public CostCenter CostCenter { get; set; }
        public List<MealVoucher> MealVouchers { get; set; }
    }
}