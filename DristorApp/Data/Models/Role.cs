using System;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace DristorApp.Data.Models
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<User> Users { set; get; }
      
    }
}

