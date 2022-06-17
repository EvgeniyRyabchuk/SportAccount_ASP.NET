using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SportAccountApi.Models
{
    public class WorkoutType
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}



