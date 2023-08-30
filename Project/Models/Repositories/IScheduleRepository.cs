using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IScheduleRepository
    {
        public Schedule AddSchedule(Schedule schedule);
        public Schedule UpdateSchedule (Schedule schedule);
        public Schedule DeleteSchedule(Schedule schedule);
        public Schedule GetSchedule(int id);
        public List<Schedule> ListSchedules();
    }
}
