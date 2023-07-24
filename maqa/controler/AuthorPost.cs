using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace maqa.controler
{
    public class AuthorPost
    {
        [Required]
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Required]
        [Display(Name = " معرف المستخدم")]

        public string UserId { get; set; }
        [Required]
        [Display(Name = "اسم المستخدم")]

        public string UserName { get; set; }
        [Required]
        [Display(Name = "الاسم الكامل")]

        public string FullName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الصنف")]
        [DataType(DataType.Text)]
        public string PostCategory { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "العنوان")]
        [DataType(DataType.Text)]

        public string Posttitle { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الوصف")]
        [DataType(DataType.MultilineText)]

        public string PostDiscription { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "صورة")]
        [DataType(DataType.Upload)]

        public string PostImgUrl { get; set; }
        [Display(Name = "تاريخ الاضافة")]
        public DateTime AddeddDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }

    }
}
