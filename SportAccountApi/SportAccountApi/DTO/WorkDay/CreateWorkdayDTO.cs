using System;

namespace SportAccountApi.DTO.WorkDay
{
    public class CreateWorkdayDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
