using System;
using Microsoft.AspNetCore.Identity;

namespace DristorApp.Data.Models
{
	public class Role : IdentityRole<int>
    {
		public ICollection<User> Users { set; get; }
	}
}

