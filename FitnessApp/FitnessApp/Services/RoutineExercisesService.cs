using FitnessApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Services
{
    public class RoutineExercisesService : BaseService<RoutineExercise>
    {
        static RoutineExercisesService()
        {
            if (db != null)
                return;

            db = new SQLiteConnection(DbPath);
            db.CreateTable<RoutineExercise>();
        }
        public override List<RoutineExercise> GetAllRecords()
        {

            var exercises = db.Table<RoutineExercise>().ToList();
            return exercises;
        }
        public override RoutineExercise GetRecord(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoutineExercise> GetExercisesForRoutine(int routineId)
        {
            var exercises = db.Table<RoutineExercise>().Where(re => re.RoutineId == routineId).ToList();
            return exercises;
        }
    }
}
