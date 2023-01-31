using System;
namespace DristorApp.Data.DTOs.Address
{
    public class AddressUpdateDTO
    {
        public int Id { set; get; }
        public string Country { set; get; }
        public string City { set; get; }
        public string AddressLine { set; get; }
        public string postalCode { set; get; }
        public string PhoneNumber { set; get; }

        public int User { set; get; }
    }
}

