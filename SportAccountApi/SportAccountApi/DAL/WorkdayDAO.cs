using Microsoft.EntityFrameworkCore;
using SportAccountApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAccountApi.DAL
{
    public class WorkdayDAO : IStandartDAO<ScheduleWorkday>
    {
        private readonly DataContext db;
        public WorkdayDAO(DataContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<ScheduleWorkday>> AddAsync(ScheduleWorkday workday)
        {
            await db.ScheduleWorkdays.AddAsync(workday);
            await db.SaveChangesAsync(); 
            return await db.ScheduleWorkdays.ToListAsync();
        }

        public async Task<ICollection<ScheduleWorkday>> DeleteAsync(int id)
        {
            ScheduleWorkday scheduleWorkday = await FindByIdAsync(id);
            db.ScheduleWorkdays.Remove(scheduleWorkday);
            await db.SaveChangesAsync();
            return await db.ScheduleWorkdays.ToListAsync();
        }

        public async Task<ScheduleWorkday> FindByIdAsync(int id)
        {
            ScheduleWorkday scheduleWorkday = await db.ScheduleWorkdays.FindAsync(id);
            return scheduleWorkday; 
        }

        public async Task<ICollection<ScheduleWorkday>> GetAllAsync()
        {
            ICollection<ScheduleWorkday> list = await db.ScheduleWorkdays
               .Include(workday => workday.Coach)
               .ToListAsync();
            return list;
        }

        public async Task<ICollection<ScheduleWorkday>> GetAllByUserIdAsync(int userId)
        {
            ICollection<ScheduleWorkday> list = await db.ScheduleWorkdays
                .Where(d => d.CoachId == userId).ToListAsync();
            return list; 
        }

        public Task<ICollection<ScheduleWorkday>> UpdateAsync(ScheduleWorkday model)
        {
            throw new System.NotImplementedException();
        }
    }
}
