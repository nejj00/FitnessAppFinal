using FitnessApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Services
{
    public class RoutineService : BaseService<Routine>
    {
        static RoutineService()
        {
            if (db != null)
                return;

            db = new SQLiteConnection(DbPath);
            db.CreateTable<Routine>();
        }

        public override List<Routine> GetAllRecords()
        {
            

            var routines = db.Table<Routine>().ToList();
            return routines;
        }

        public override Routine GetRecord(int id)
        {
            var routine = db.Table<Routine>().FirstOrDefault(r => r.Id == id);
            return routine;
        }

        public List<Routine> GetRoutinesForWeek(int week)
        {
            var routines = db.Table<Routine>().Where(r => r.Week == week).ToList();
            routines.Add(new Routine { Day = 3, Week = week, IsRestDay = true });
            routines.Add(new Routine { Day = 7, Week = week, IsRestDay = true });
            routines.Sort((r1, r2) => r1.Day.CompareTo(r2.Day));

            return routines;
        }
    }
}
