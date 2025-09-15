using Fit.Data;
using Fit.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Fit.ViewModels
{
    internal class ExerciseEntryViewModel : INotifyPropertyChanged
    {
        private readonly FitnessDatabase _database;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<ExerciseEntry> _exerciseEntries;

        public string Date
        {
            get => DateTime.Now.ToString("dddd, MMM d");
        }

        public ObservableCollection<ExerciseEntry> ExerciseEntries
        {
            get => _exerciseEntries;
            set
            {
                if (_exerciseEntries != value)
                {
                    _exerciseEntries = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddExerciseCommand { get; }

        public ICommand DeleteAllExercisesCommand { get; }

        public ExerciseEntryViewModel(FitnessDatabase database)
        {
            _database = database;

            ExerciseEntries = new ObservableCollection<ExerciseEntry>();

            AddExerciseCommand = new Command(async () => await AddExerciseAsync());

            //AddExerciseCommand = new Command(async () => await AddExerciseAsync());

            DeleteAllExercisesCommand = new Command(async () => await DeleteAllExercisesAsync(ExerciseEntries));

            Task.Run(async () => await LoadEntriesAsync());
        }

        public async Task LoadEntriesAsync()
        {
            var entries = await _database.GetExerciseEntriesAsync();
            ExerciseEntries = new ObservableCollection<ExerciseEntry>();
            foreach (var entry in entries)
            {
                ExerciseEntries.Add(entry);
            }
        }

        private async Task DeleteAllExercisesAsync(ObservableCollection<ExerciseEntry> exercises)
        {
            foreach (var entry in exercises)
            {
                await _database.DeleteWorkoutEntryAsync(entry);
            }
            await LoadEntriesAsync();
        }

        private async Task AddExerciseAsync()
        {
            var newEntry = new ExerciseEntry
            {
                Date = DateTime.Now,
                ExerciseName = "YO",
                Sets = 10,
                Reps = 11,
                Weight = 100
            };

            await _database.SaveExerciseEntryAsync(newEntry);
            ExerciseEntries.Add(newEntry);
        }

        // adding this soon

        //private async Task AddExerciseAsync()
        //{
        //    var newEntry = new ExerciseEntry
        //    {
        //        ExerciseName = "water buffalo",
        //        Sets = 99,
        //        Reps = 99,
        //        Weight = (float)99.9
        //    };

        //    await _database.save
        //}
    }
}
