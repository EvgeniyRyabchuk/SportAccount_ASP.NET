using System;
using System.ComponentModel.DataAnnotations;

namespace SportAccountApi.Models
{
    public class _RefreshToken
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string RefreshToken { get; set; } 
        [Required]
        public DateTime Expired_At { get; set; }
        [Required]
        public DateTime Created_At { get; set; }

        public User User { get; set; } 
        public int UserId { get; set; }
    }
}
