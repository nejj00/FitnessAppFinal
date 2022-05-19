using FitnessApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Services
{
    public class DifficultyService : BaseService<Difficulty>
    {
        static DifficultyService()
        {
            if (db != null)
                return;

            db = new SQLiteConnection(DbPath);
            db.CreateTable<Difficulty>();
        }

        public override List<Difficulty> GetAllRecords()
        {
            var difficulties = db.Table<Difficulty>().ToList();
            return difficulties;
        }

        public override Difficulty GetRecord(int id)
        {
            throw new NotImplementedException();
        }
    }
}
