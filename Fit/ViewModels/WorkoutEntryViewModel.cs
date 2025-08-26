using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Fit.Data;
using Fit.Models;

namespace Fit.ViewModels
{
    internal class WorkoutEntryViewModel : INotifyPropertyChanged
    {
        private readonly FitnessDatabase _database;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<WorkoutEntry> _workoutEntries;

        public ObservableCollection<WorkoutEntry> WorkoutEntries
        {
            get => _workoutEntries;
            set
            {
                if (_workoutEntries != value)
                {
                    _workoutEntries = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddWorkoutCommand { get; }
        public ICommand AddExerciseCommand { get; }

        public ICommand DeleteAllWorkoutsCommand { get; }

        public WorkoutEntryViewModel(FitnessDatabase database)
        {
            _database = database;

            WorkoutEntries = new ObservableCollection<WorkoutEntry>();

            AddWorkoutCommand = new Command(async () => await AddWorkoutAsync());

            //AddExerciseCommand = new Command(async () => await AddExerciseAsync());

            DeleteAllWorkoutsCommand = new Command(async () => await DeleteAllWorkoutsAsync(WorkoutEntries));

            Task.Run(async () => await LoadEntriesAsync());
        }

        public async Task LoadEntriesAsync()
        {
            var entries = await _database.GetWorkoutEntriesAsync();
            WorkoutEntries = new ObservableCollection<WorkoutEntry>();
            foreach (var entry in entries)
            {
                WorkoutEntries.Add(entry);
            }
        }

        private async Task DeleteAllWorkoutsAsync(ObservableCollection<WorkoutEntry> workouts)
        {
            foreach (var entry in workouts)
            {
                await _database.DeleteWorkoutEntryAsync(entry);
            }
            await LoadEntriesAsync();
        }

        private async Task AddWorkoutAsync()
        {
            var newEntry = new WorkoutEntry
            {
                Date = DateTime.Now,
            };

            await _database.SaveWorkoiutEntryAsync(newEntry);
            WorkoutEntries.Add(newEntry);
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
