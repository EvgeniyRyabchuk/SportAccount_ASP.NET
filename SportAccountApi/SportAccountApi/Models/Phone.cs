using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SportAccountApi.Models
{
    public class Phone
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore] 
        public User User { get; set; }
        
    }
}
