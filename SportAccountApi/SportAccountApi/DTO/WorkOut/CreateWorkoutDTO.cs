using System;
using System.ComponentModel.DataAnnotations;

namespace SportAccountApi.DTO.WorkOut
{
    public class CreateWorkoutDTO
    {
        public int? GroupId { get; set; }
        public int? ClientId { get; set; }

        [Required]
        public int RoomId { get; set; }
        [Required]
        public int WorkoutTypeId { get; set; }

        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
