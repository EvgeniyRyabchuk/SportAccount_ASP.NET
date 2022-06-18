using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System;

namespace SportAccountApi.Models
{
    public class ScheduleWorkday
    {

        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [JsonIgnore]
        public int CoachId { get; set; } 
        public User Coach { get; set; }
        

        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }

    }
}
