using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SportAccountApi.Models
{
    public class Status
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 

        [JsonIgnore]
        public int RoleId { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }
    }
}
