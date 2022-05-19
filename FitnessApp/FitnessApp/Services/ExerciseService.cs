using FitnessApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FitnessApp.Services
{
    public class ExerciseService : BaseService<Exercise>
    {

        static ExerciseService()
        {
            if (db != null)
                return;

            db = new SQLiteConnection(DbPath);
            db.CreateTable<Exercise>();
        }

        public override List<Exercise> GetAllRecords()
        {
            var exercises = db.Table<Exercise>().ToList();
            return exercises;
        }

        public override Exercise GetRecord(int id)
        {
            var exercise = db.Table<Exercise>().FirstOrDefault(e => e.Id == id);
            return exercise;
        }
    }
}
