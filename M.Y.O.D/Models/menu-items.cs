using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M.Y.O.D.Models
{
    public class menu_item
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "السعر :")]
        [Required(ErrorMessage = "يجب ادخال السعر !!!")]
        public float price { get; set; }
        

        [NotMapped]
        public HttpPostedFileBase Myfile { get; set; }

        public string Path { get; set; }

        [ForeignKey("Category")]
        public int CatID { get; set; }

        [Display(Name ="الفئه : ")]
        public virtual Category Category { get; set; }

    }
}