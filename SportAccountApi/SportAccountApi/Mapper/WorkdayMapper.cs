using SportAccountApi.DTO.WorkDay;
using SportAccountApi.Models;

namespace SportAccountApi.Mapper
{
    public class WorkdayMapper
    {
        public static ScheduleWorkday FromCreateModel(CreateWorkdayDTO createWorkdayDTO, User user)
        {
            return new ScheduleWorkday()
            {
                Date = createWorkdayDTO.Date,
                CoachId = user.Id,
                StartTime = createWorkdayDTO.StartTime,
                EndTime = createWorkdayDTO.EndTime
            }; 
        }
    }
}
