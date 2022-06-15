using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAccountApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddletName { get; set; }
        [Required]
        public string Login { get; set; } = "123";
        [Required]
        public string Password { get; set; } = "123";
        [Required]
        public DateTime BirthDate { get; set; }

        public int specialization_id { get; set; } = 1;
        public int status_id { get; set; } = 1;
        public int sex_id { get; set; } = 1; 

        public int RoleId { get; set; }
        public Role Role { get; set; }  
    }
}
