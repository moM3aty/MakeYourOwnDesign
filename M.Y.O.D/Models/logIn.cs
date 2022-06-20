using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M.Y.O.D.Models
{
    public class logIn
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "الايميل :")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "الباسورد :")]
        [DataType(DataType.Password)]
        public string pwd { get; set; }

        public string DateTime { get; set; }
    }
}