using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_Tutorial_01.Models
{
    public partial class TblCustomer
    {
        public int CCustomerId { get; set; }
        public string CCustomerName { get; set; }
        public string CCustomerPhone { get; set; }
        public string CCustomerAddress { get; set; }
        public int CCreatorId { get; set; }
        public DateTime CCreatorDt { get; set; }
    }
}
