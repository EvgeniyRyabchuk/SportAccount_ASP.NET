using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SportAccountApi.Models
{
    public class Group
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> users { get; set; }  
        
    }
}
