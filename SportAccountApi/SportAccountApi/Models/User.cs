using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text.Json.Serialization;
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
        public string MiddleName { get; set; }
        [Required]
        public string Login { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }


        [JsonIgnore]
        public int? SpecializationId { get; set; }
        public Specialization Specialization { set; get; }


        [JsonIgnore]
        public int? StatusId { get; set; }
        public Status Status { get; set; } 


        [JsonIgnore]
        public int SexId { get; set; } 
        public Sex Sex { get; set; } 


        [JsonIgnore]
        public int RoleId { get; set; } = 1; 
        public Role Role { get; set; } 

        public List<Phone> Phones { get; set; }


        
        public List<Group> Groups { get; set; }
     
    }
}
