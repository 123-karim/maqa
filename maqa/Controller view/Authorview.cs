﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace maqa.Controller_view
{
    public class Authorview
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
        [Display(Name = "صورة")]

        public IFormFile ProfileImgUrl { get; set; }
        [Display(Name = "السيرة الذاتية")]

        public string Bio { get; set; }
        [Display(Name = "فيس بوك")]

        public string Facebook { get; set; }
        [Display(Name = "انستجرام")]

        public string Instgram { get; set; }
        [Display(Name = "تويتر")]

        public string Twitter { get; set; }
    }
}
