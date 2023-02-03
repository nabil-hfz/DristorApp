using System;
using System.ComponentModel.DataAnnotations
;
namespace DristorApp.Data.Models
{
    public class Address
    {
        public int Id { set; get; }
        public string Country { set; get; }
        public string City { set; get; }
        public string AddressLine { set; get; }
        public string PostalCode { set; get; }
        public string PhoneNumber { set; get; }

        [Required]
        public User User { set; get; }

        public ICollection<Order> Orders { set; get; }

    }
}

