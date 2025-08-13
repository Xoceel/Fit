using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Fit.Data;
using Fit.Models;

namespace Fit.ViewModels
{
    internal class CalorieEntryViewModel : INotifyPropertyChanged
    {
        private readonly FitnessDatabase _database;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<CalorieEntry> _calorieEntries;

        public ObservableCollection<CalorieEntry> CalorieEntries
        {
            get => _calorieEntries;
            set
            {
                if (_calorieEntries != value)
                {
                    _calorieEntries = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCalorieCommand { get; }
        public ICommand DeleteAllCaloriesCommand { get; }

        public CalorieEntryViewModel(FitnessDatabase database)
        {
            _database = database;
            CalorieEntries = new ObservableCollection<CalorieEntry>();


            AddCalorieCommand = new Command(async () => await AddCalorieAsync());
            DeleteAllCaloriesCommand = new Command(async () => await DeleteAllCaloriesAsync(CalorieEntries));

            Task.Run(async () => await LoadEntriesAsync());

        }

        public async Task LoadEntriesAsync()
        {
            var entries = await _database.GetCalorieEntriesAsync();
            CalorieEntries = new ObservableCollection<CalorieEntry>();
            foreach (var entry in entries)
            {
                CalorieEntries.Add(entry);
            }
        }

        private async Task DeleteAllCaloriesAsync(ObservableCollection<CalorieEntry> calories)
        {
            foreach (var entry in calories)
            {
                await _database.DeleteCalorieEntryAsync(entry);
            }
            await LoadEntriesAsync();
        }

        private async Task AddCalorieAsync()
        {
            var newEntry = new CalorieEntry
            {
                Date = DateTime.Now,
                Calories = 2000,
                Fat = 300,
                Carbs = 200,
                Protein = 300
            };

            await _database.SaveCalorieEntryAsync(newEntry);
            CalorieEntries.Add(newEntry);
        }
    }
}
