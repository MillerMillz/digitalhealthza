using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class ScheduleRepository:IScheduleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ScheduleRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Schedule AddSchedule(Schedule schedule)
        {
            dbContext.Schedules.Add(schedule);
            dbContext.SaveChanges();
            return schedule;

        }

        public Schedule DeleteSchedule(Schedule schedule)
        {
            schedule.Deleted = 1;
            dbContext.Schedules.Update(schedule);
            dbContext.SaveChanges();
            return schedule;
        }

        public Schedule GetSchedule(int id)
        {
            Schedule schedule = dbContext.Schedules.Find(id);
            return schedule;
        }

        public List<Schedule> ListSchedules()
        {
            List<Schedule> schedules = new List<Schedule>();
            foreach (Schedule a in dbContext.Schedules)
            {
                if (a.Deleted == 0)
                { schedules.Add(a); }
            }
            return schedules;
        }

        public Schedule UpdateSchedule(Schedule schedule)
        {
            dbContext.Schedules.Update(schedule);
            dbContext.SaveChanges();
            return schedule;
        }
    }
}
