using SportAccountApi.DTO.WorkOut;
using SportAccountApi.Models;

namespace SportAccountApi.Mapper
{
    public class WorkoutMapper
    {
        public static ScheduleWorkout FromCreateModel(CreateWorkoutDTO createWorkdayDTO, int workdayId)
        {
            if (createWorkdayDTO.WorkoutTypeId == 1)
            {
                return new ScheduleWorkout()
                {
                    SheduleWorkdayId = workdayId,
                    GroupId = createWorkdayDTO.GroupId,
                    RoomId = createWorkdayDTO.RoomId,
                    WorkoutTypeId = createWorkdayDTO.WorkoutTypeId,
                    start = createWorkdayDTO.start,
                    end = createWorkdayDTO.end
                };
            }
            else
            {
                return new ScheduleWorkout()
                {
                    SheduleWorkdayId = workdayId,
                    ClientId = createWorkdayDTO.ClientId, 
                    RoomId = createWorkdayDTO.RoomId,
                    WorkoutTypeId = createWorkdayDTO.WorkoutTypeId,
                    start = createWorkdayDTO.start,
                    end = createWorkdayDTO.end
                };
            }
           
        }
    }
}
