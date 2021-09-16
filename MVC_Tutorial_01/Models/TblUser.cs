using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_Tutorial_01.Models
{
    public partial class TblUser
    {
        public int CUserId { get; set; }
        public string CUserName { get; set; }
        public string CUserAccout { get; set; }
        public string CUserPassword { get; set; }
        public string CUserMail { get; set; }
        public int CCreatorId { get; set; }
        public DateTime CCreatorDt { get; set; }
    }
}
