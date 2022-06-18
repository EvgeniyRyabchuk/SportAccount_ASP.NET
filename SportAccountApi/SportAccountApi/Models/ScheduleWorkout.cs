using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System;

namespace SportAccountApi.Models
{
    public class ScheduleWorkout
    {

        [Key]
        public int Id { get; set; }

        public ScheduleWorkday SheduleWorkday { get; set; }
        
        [JsonIgnore]
        [Required]
        public int SheduleWorkdayId { get; set; }

  
        

        [JsonIgnore]
        public int? GroupId { get; set; }
        public Group Group { get; set; } = null; 

        [JsonIgnore]
        public int? ClientId { get; set; }
        public User Client { get; set; } = null;


        public Room Room { get; set; }
        [JsonIgnore]
        public int RoomId { get; set; }

        public WorkoutType WorkoutType { get; set; } 
        [JsonIgnore]
        public int WorkoutTypeId { get; set; }

        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}
