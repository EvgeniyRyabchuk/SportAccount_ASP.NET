using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System;

namespace SportAccountApi.Models
{
    public class ScheduleWorkout
    {

        [Key]
        public int Id { get; set; }
        public int SheduleWorkdayId { get; set; }


        public int GroupId { get; set; }
        public Group group { get; set; }

        public int ClientId { get; set; } 
        public User Client { get; set; } 


        public Room room { get; set; }
        [JsonIgnore]
        public int RoomId { get; set; }

        public WorkoutType WorkoutType { get; set; } 
        [JsonIgnore]
        public int WorkoutTypeId { get; set; }

        public DateTime start { get; set; }
        public DateTime endT { get; set; }

    }
}
