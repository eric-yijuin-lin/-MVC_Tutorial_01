using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_Tutorial_01.Models
{
    public partial class TblNews
    {
        public int No { get; set; }
        public string Type { get; set; }
        [Required(ErrorMessage = "標題是必須的")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "標題長度必須介在 2~50 個字")]
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDt { get; set; }
        // [EmailAddress(ErrorMessage = "email 格式錯誤")]
        // public string Email { get; set; }
        //[Range(1, 1000, ErrorMessage = "No 必須介在 1~1000")]
        // public int Number { get; set; }
    }
}
