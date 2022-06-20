using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAccountApi.DAL;
using SportAccountApi.DTO.WorkDay;
using SportAccountApi.DTO.WorkOut;
using SportAccountApi.Mapper;
using SportAccountApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportAccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {

        private readonly UserDAO userDAO;
        private readonly GroupDAO groupDAO;
        private readonly RoleDAO roleDAO;
        private readonly WorkdayDAO workdayDAO;
        private readonly WorkoutDAO workoutDAO;

        private readonly IHttpContextAccessor httpContextAccessor;
        public ScheduleController(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            userDAO = new UserDAO(dataContext);
            roleDAO = new RoleDAO(dataContext);
            groupDAO = new GroupDAO(dataContext);
            workdayDAO = new WorkdayDAO(dataContext);
            workoutDAO = new WorkoutDAO(dataContext);

            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("workday")]
        public async Task<ActionResult<ScheduleWorkday>> AllWorkday()
        {
            var list = await workdayDAO.GetAllAsync();
            return Ok(list); 
        }


        [HttpGet("workout")]
        public async Task<ActionResult<ScheduleWorkday>> AllWorkout()
        {
            var list = await workoutDAO.GetAllAsync();
            return Ok(list);
        }

        // get all workdays by coach 
        [HttpGet("coach/{coachId}/workday")]
        public async Task<ActionResult<ScheduleWorkday>> AllDaysByCoachAsync(int coachId)
        {
            User coach = await userDAO.FindByIdAsync(coachId);
            ICollection<ScheduleWorkday> list = await workdayDAO.GetAllByUserIdAsync(coach.Id);
            return Ok(list);
        }

        // get all workouts by workday 
        [HttpGet("coach/{coachId}/workday/{workdayId}")]
        public async Task<IActionResult> AllWorkoutsByDayAsync(int coachId, int workdayId)
        {
            User coach = await userDAO.FindByIdAsync(coachId);
            ScheduleWorkday workday = await workdayDAO.FindByIdAsync(workdayId);
            ICollection<ScheduleWorkout> list = await workoutDAO.GetAllByDayIdAsync(workdayId);
            return Ok(list);
        }


        [HttpPost("coach/{coachId}/workday")] 
        public async Task<ActionResult<ScheduleWorkday>>
            AddWorkDayToCoachAsync(CreateWorkdayDTO createWorkdayDTO, int coachId)
        {
            User coach = await userDAO.FindByIdAsync(coachId); 
            ScheduleWorkday scheduleWorkdayMapper = WorkdayMapper.FromCreateModel(createWorkdayDTO, coach);
            var list = await workdayDAO.AddAsync(scheduleWorkdayMapper); 
            return Ok(list);
        }

        //TODO: check if time interval is free for workout 
        [HttpPost("coach/{coachId}/workday/{workdayId}/workout")]
        public async Task<ActionResult<ScheduleWorkday>> 
            AddWorkOutToWorkDayAsync(CreateWorkoutDTO createWorkoutDTO, int coachId, int workdayId)
        {
            User coach = await userDAO.FindByIdAsync(coachId);
            ScheduleWorkday scheduleWorkday = await workdayDAO.FindByIdAsync(workdayId);
            ScheduleWorkout scheduleWorkoutMapped = WorkoutMapper.FromCreateModel(createWorkoutDTO, scheduleWorkday.Id);

            var list = await workoutDAO.AddAsync(scheduleWorkoutMapped);
            return Ok(list);
        }


        [HttpDelete("workday/{workdayId}")]
        public async Task<ActionResult<ScheduleWorkday>> DeleteWorkDayAsync(int workdayId)
        {
            var list = await workdayDAO.DeleteAsync(workdayId);
            return Ok(list); 
        } 

        [HttpDelete("workout/{workoutId}")]
        public async Task<ActionResult<ScheduleWorkday>> DeleteWorkOutAsync(int workoutId)
        {
            var list = await workoutDAO.DeleteAsync(workoutId);
            return Ok(list); 
        }
    }
}
