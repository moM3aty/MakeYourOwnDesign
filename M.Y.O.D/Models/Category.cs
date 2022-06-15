using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M.Y.O.D.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "اسم الفئه")]
        [Required(ErrorMessage ="Category Is Required")]
        [MaxLength(50, ErrorMessage = "Maximum Length is 50 word")]
        public string Cat { get; set; }

        public virtual ICollection<menu_item> Menu_Items { get; set; }
            = new HashSet<menu_item>();
    }

}