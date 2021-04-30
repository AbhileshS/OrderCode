using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcOderModel
    {
        public int ORDERID { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string ORDERNAME { get; set; }
        public Nullable<int> ITEMS { get; set; }
    }
}