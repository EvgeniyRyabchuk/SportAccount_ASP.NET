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
        public DateTime date { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
 

        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

    }
}
