using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M.Y.O.D.Models
{
    public class Register
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="الاسم الاول :")]
        [Required(ErrorMessage ="يجب ادخال الاسم الاول !!!")]
        [StringLength(15, ErrorMessage = "الاسم الاول يجب ان يكون أقل من 15 حرف")]
        [DataType(DataType.Text)]
        public string Fname { get; set; }

        [Display(Name = "اسم العائله :")]
        [Required(ErrorMessage = "يجب ادخال اسم العائله !!!")]
        [StringLength(15, ErrorMessage = "اسم العائله يجب ان يكون اقل من 15 حرف")]
        [DataType(DataType.Text)]
        public string Lname { get; set; }

        [Display(Name = "الايميل :")]
        [Required(ErrorMessage = "يجب ادخال الايميل !!!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "الايميل المستخدم خطأ !!!")]
        [System.Web.Mvc.Remote("EmailExist", "Index", ErrorMessage = "الايميل المكتوب مستخدم من قبل  !!!")]
        public string Email { get; set; }

        [Display(Name = "الباسورد :")]
        [Required(ErrorMessage = "يجب ادخال الباسورد !!!")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "الباسورد يجب ان يكون اكثر من 8 احرف")]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "يجب استخدام الحروف والارقام")]
        public string pwd { get; set; }

        [Display(Name = "تاكيد الباسورد :")]
        [Required(ErrorMessage = "يجب تأكيد الباسورد !!!")]
        [DataType(DataType.Password)]
        [Compare("pwd", ErrorMessage = "الباسورد غير متطابق !!!")]
        public string Cpwd { get; set; }

        [Display(Name = "تاريخ الميلاد :")]
        [Required(ErrorMessage = "يجب ادخال تاريخ الميلاد !!!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }

        [Display(Name ="النوع :")]
        [Required(ErrorMessage = "يجب ادخال النوع !!!")]
        public string Gender { get; set; }

    }
}