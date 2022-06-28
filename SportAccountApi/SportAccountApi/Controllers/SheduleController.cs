using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportAccountApi.DAL;
using SportAccountApi.DTO.WorkDay;
using SportAccountApi.DTO.WorkOut;
using SportAccountApi.Mapper;
using SportAccountApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        DataContext db;

        public ScheduleController(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            userDAO = new UserDAO(dataContext);
            roleDAO = new RoleDAO(dataContext);
            groupDAO = new GroupDAO(dataContext);
            workdayDAO = new WorkdayDAO(dataContext);
            workoutDAO = new WorkoutDAO(dataContext);
            db = dataContext; 
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
        public async Task<ActionResult<ScheduleWorkday>> AllWorkDaysByCoachAsync(int coachId)
        {
            User coach = await userDAO.FindByIdAsync(coachId);
            ICollection<ScheduleWorkday> list = await workdayDAO.GetAllByUserIdAsync(coach.Id);
            return Ok(list);
        }

        // get workday by workday 
        [HttpGet("coach/{coachId}/workday/{workdayId}")] 
        public async Task<IActionResult> GetWorkDayByIdAsync(int coachId, int workdayId)
        {
            User coach = await userDAO.FindByIdAsync(coachId);
            ScheduleWorkday workday = await workdayDAO.FindByIdAsync(workdayId);
            return Ok(workday); 
        }

        // get all workouts by workday 
        [HttpGet("coach/{coachId}/workday/{workdayId}/workout")] 
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
            await workdayDAO.AddAsync(scheduleWorkdayMapper);
            var list = await workdayDAO.GetAllByUserIdAsync(coachId); 
            return Ok(list);
        }


        //TODO: check if time interval is free for workout 
        
        [HttpPost("coach/{coachId}/workday/{workdayId}/workout")]
        public async Task<ActionResult<ScheduleWorkday>> 
            AddWorkOutToWorkDayAsync(CreateWorkoutDTO createWorkoutDTO, int coachId, int workdayId)
        {

            User coach = await userDAO.FindByIdAsync(coachId);
            ScheduleWorkday scheduleWorkday = await workdayDAO.FindByIdAsync(workdayId);

            DateTime startTimeForNewWorkout = createWorkoutDTO.start; 
            DateTime endTimeForNewWorkout = createWorkoutDTO.end;

            // проверка коректности ведённых временных рамок 
            if(startTimeForNewWorkout.TimeOfDay > endTimeForNewWorkout.TimeOfDay)
            {
                return BadRequest("Time params does not correct"); 
            }
            // проверка не выходит ли переданное время за рамки рабочего дня трененра 
            if(startTimeForNewWorkout.TimeOfDay < scheduleWorkday.StartTime.TimeOfDay
                || endTimeForNewWorkout.TimeOfDay > scheduleWorkday.EndTime.TimeOfDay)
            {
                return BadRequest("This time out of coach schedule"); 
            }

            // проверка не записался ли клиент к тренеру на время которое уже занято другим 
            ScheduleWorkout lastWorkOut = null; 
            try
            {
                lastWorkOut = await db.ScheduleWorkouts
                    .Where(wo => wo.SheduleWorkdayId == scheduleWorkday.Id)
                    .OrderByDescending(wo => wo.end)
                    .FirstAsync();
            }
            catch(Exception ex)
            {

            }
            if(lastWorkOut != null)
            {
                if (startTimeForNewWorkout.TimeOfDay < lastWorkOut.end.TimeOfDay)
                {
                    return BadRequest("A coach cannot be in two places at the same time");
                }
            }
            
            // получаем расписание всех тренеровв на этот день 
            ICollection<ScheduleWorkday> workdayList = await db.ScheduleWorkdays
                .Where(wd => wd.Date == scheduleWorkday.Date)
                .ToListAsync(); 

            // провнряем нет ли временных коллизий с другими тренерами на этот день, в это время, в этом зале   
            foreach(ScheduleWorkday workday in workdayList)
            {
                ICollection<ScheduleWorkout> workoutsList = await db.ScheduleWorkouts
                    .Where(wo => wo.SheduleWorkdayId == workday.Id)
                    .ToListAsync();

                foreach(ScheduleWorkout scheduleWorkout in workoutsList)
                {
                    if(scheduleWorkout.RoomId == createWorkoutDTO.RoomId)
                    {
                        if (startTimeForNewWorkout.TimeOfDay < scheduleWorkout.end.TimeOfDay
                            || endTimeForNewWorkout.TimeOfDay < scheduleWorkout.end.TimeOfDay) 
                        {
                            return BadRequest("Workout time collision"); 
                        } 
                    }
                   
                }
            }
            
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
