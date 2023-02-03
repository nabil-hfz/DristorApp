using System;
namespace DristorApp.Data.DTOs.User
{
    public class UserDTO
    {
        public int Id { set; get; }
        public string Email { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public List<string> Roles { set; get; }
        public List<int> Addresses { set; get; }

    }
}

