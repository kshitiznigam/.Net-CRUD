using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public required string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Contact No is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact No should be 10 digits")]
        public required string ContactNo { get; set; }

        [Required(ErrorMessage = "Last Order Date is required")]
        public required string LastOrderDate { get; set; }
}
}