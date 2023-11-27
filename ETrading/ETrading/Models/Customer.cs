//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETrading.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        public int CustomerId { get; set; }
        [DisplayName("User Name")][Required]
        public string CustomerName { get; set; }
        [Required][DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required][DataType(DataType.PhoneNumber)]
        public long PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required][DataType(DataType.Currency)]
        public double AccountBalance { get; set; }
        [Required][DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
