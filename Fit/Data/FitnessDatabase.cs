using Fit.Models;
using SQLite;

namespace Fit.Data
{
    public class FitnessDatabase
    {
        SQLiteAsyncConnection _database;

        async Task Init()
        {
            if (_database is not null)
            {
                return;
            }

            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await _database.CreateTableAsync<WorkoutEntry>();
            await _database.CreateTableAsync<WeightEntry>();
            await _database.CreateTableAsync<CalorieEntry>();

        }

        public async Task<List<WeightEntry>> GetWeightEntriesAsync()
        {
            await Init();
            return await _database.Table<WeightEntry>().ToListAsync();
        }

        public async Task<int> SaveWeightEntryAsync(WeightEntry weight)
        {
            await Init();
            if (weight.Id != 0)
            {
                return await _database.UpdateAsync(weight);
            }
            else
            {
                return await _database.InsertAsync(weight);
            }
        }

        public async Task<int> DeleteWeightEntryAsync(WeightEntry weight)
        {
            await Init();
            return await _database.DeleteAsync(weight);
        }

        public async Task<List<CalorieEntry>> GetCalorieEntriesAsync()
        {
            await Init();
            return await _database.Table<CalorieEntry>().ToListAsync();
        }

        public async Task<int> SaveCalorieEntryAsync(CalorieEntry calorie)
        {
            await Init();
            if (calorie.Id != 0)
            {
                return await _database.UpdateAsync(calorie);
            }
            else
            {
                return await _database.InsertAsync(calorie);
            }
        }

        public async Task<int> DeleteCalorieEntryAsync(CalorieEntry calorie)
        {
            await Init();
            return await _database.DeleteAsync(calorie);
        }

        // workout db section
        public async Task<List<WorkoutEntry>> GetWorkoutEntriesAsync()
        {
            await Init();
            return await _database.Table<WorkoutEntry>().ToListAsync();
        }

        public async Task<int> SaveWorkoiutEntryAsync(WorkoutEntry workout)
        {
            await Init();
            if (workout.Id != 0)
            {
                return await _database.UpdateAsync(workout);
            }
            else
            {
                return await _database.InsertAsync(workout);
            }
        }

        public async Task<int> DeleteWorkoutEntryAsync(WorkoutEntry workout)
        {
            await Init();
            return await _database.DeleteAsync(workout);
        }
    }
}
