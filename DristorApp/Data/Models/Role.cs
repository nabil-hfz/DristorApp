using System;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace DristorApp.Data.Models
{
    public class Role : IdentityRole<int>
    {
        public ICollection<User> Users { set; get; }
        public override string ToString()
        {
            string roles = "No Role";
            if(Users is not null)
            foreach (var rol in Users)
            {
                roles += rol.ToString();
                roles += ' ';
            }
            return string.Format("Role Users: {0}", roles);
        }
    }
}

