using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace maqa.controler
{
    public class Category
    {
        [Required]
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "أسم الصنف")]
        [MaxLength(50, ErrorMessage = "اعلى قيمة للإدخال هى 50 حرف")]
        [MinLength(3, ErrorMessage = "أقل قيمة للإدخال هى 3 حرف")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public virtual List<AuthorPost> AuthorPosts { get; set; }


    }
}
