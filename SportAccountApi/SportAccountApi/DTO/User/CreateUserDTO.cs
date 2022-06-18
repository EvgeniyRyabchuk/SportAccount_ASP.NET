using SportAccountApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SportAccountApi.DTO.User
{
    public class CreateUserDTO 
    {
        
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddletName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }  
        public int RoleId { get; set; } = 1;
        public int SpecializationId { get; set; } = 1;
        public int StatusId { get; set; }
        public int SexId { get; set; } = 1;

    }
}
