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
        public virtual int UserId { set; get; }

        public virtual User User { set; get; }
    }
}

