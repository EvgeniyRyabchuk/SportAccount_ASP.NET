using Microsoft.EntityFrameworkCore;
using SportAccountApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAccountApi.DAL
{
    public class WorkoutDAO : IStandartDAO<ScheduleWorkout>
    {

        private readonly DataContext db;
        public WorkoutDAO(DataContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<ScheduleWorkout>> AddAsync(ScheduleWorkout model)
        {
            await db.ScheduleWorkouts.AddAsync(model); 
            await db.SaveChangesAsync();
            return await this.GetAllByDayIdAsync(model.SheduleWorkdayId);
        }

        public async Task<ICollection<ScheduleWorkout>> DeleteAsync(int id)
        {
            ScheduleWorkout scheduleWorkout = await FindByIdAsync(id);
            db.ScheduleWorkouts.Remove(scheduleWorkout);
            await db.SaveChangesAsync();
            return await db.ScheduleWorkouts.ToListAsync();
        }

        public async Task<ScheduleWorkout> FindByIdAsync(int id)
        {
            ScheduleWorkout scheduleWorkout = await db.ScheduleWorkouts.FindAsync(id);
            return scheduleWorkout;
        }

        public async Task<ICollection<ScheduleWorkout>> GetAllAsync()
        {
            ICollection<ScheduleWorkout> list = await db.ScheduleWorkouts
                .Include(workout => workout.SheduleWorkday)
                .Include(workout => workout.Client) 
                .Include(workout => workout.Group)
                .Include(workout => workout.Room)
                .Include(workout => workout.WorkoutType)
                .ToListAsync();
            return list;
        }

        public async Task<ICollection<ScheduleWorkout>> GetAllByDayIdAsync(int dayId)
        {
            ICollection<ScheduleWorkout> list = await db.ScheduleWorkouts
                .Where(workout => workout.SheduleWorkdayId == dayId) 
                .Include(workout => workout.Client)
                .Include(workout => workout.Group)
                .Include(workout => workout.Room)
                .Include(workout => workout.WorkoutType)
                .ToListAsync();
            return list; 
        }

        public Task<ICollection<ScheduleWorkout>> UpdateAsync(ScheduleWorkout model)
        {
            throw new System.NotImplementedException();
        }
    }
}
