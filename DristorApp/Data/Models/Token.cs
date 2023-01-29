using System;
using System.ComponentModel.DataAnnotations;
namespace DristorApp.Data.Models
{
	public class Token
	{
        [Key]
        public string Jti { set; get; }

        [Required]
		public DateTime ExpirationDate { set; get; }

        [Required]
        public int UserId { set; get; }

        public User User { set; get; }
    }
}

