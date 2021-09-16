using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_Tutorial_01.Models
{
    public partial class TblNewsType
    {
        public int TypeId { get; set; }
        public string TypeText { get; set; }
        public string TypeValue { get; set; }
    }
}
