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
            await _database.CreateTableAsync<WeightEntry>();
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

        public async Task<int> DeleteItemAsync(WeightEntry weight)
        {
            await Init();
            return await _database.DeleteAsync(weight);
        }
    }
}
