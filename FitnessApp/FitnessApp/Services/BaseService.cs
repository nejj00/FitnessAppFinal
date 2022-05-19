using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FitnessApp.Services
{
    public abstract class BaseService<T>
    {
        public static SQLiteConnection db;
        public static string DbPath { get; } = Path.Combine(FileSystem.AppDataDirectory, "WourkoutAppData");
        public abstract List<T> GetAllRecords();
        public abstract T GetRecord(int id);
    }
}
