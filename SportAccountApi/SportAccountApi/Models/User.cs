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
        public string MiddletName { get; set; }
        [Required]
        public string Login { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        public string RefreshToken { get; set; }
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; } 


        [Required]
        public DateTime BirthDate { get; set; }


        [JsonIgnore]
        public int SpecializationId { get; set; }
        public Specialization Specialization { set; get; }

        //[JsonIgnore]
        public int StatusId { get; set; } 
        //TODO: cascade error 
        ////public Status status { get; set; } 

        [JsonIgnore]
        public int SexId { get; set; }
        public Sex Sex { get; set; } 


        [JsonIgnore]
        public int RoleId { get; set; } 
        public Role Role { get; set; } 

        public List<Phone> Phones { get; set; } 

        
        public List<Group> groups { get; set; }
     
    }
}
