using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Fit.Models;

namespace Fit.ViewModels
{
    internal class WorkoutEntryViewModel : INotifyPropertyChanged
    {

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

        public WorkoutEntryViewModel()
        {
            WorkoutEntries = new ObservableCollection<WorkoutEntry>
            {
                new WorkoutEntry {Id = 0, Date = DateTime.Now.AddDays(-1), Exercises = new List<ExerciseEntry> {new ExerciseEntry(0, "latpulldowns", 3, 2, (float)10.5), new ExerciseEntry(0, "pulldowns", 3, 2, (float)150.5), new ExerciseEntry(0, "latpulldowns", 3, 2, (float)10000.5)}}
            };

            AddWorkoutCommand = new Command(() =>
            {
                var newEntry = new WorkoutEntry
                {
                    Id = WorkoutEntries.Count + 1,
                    Date = DateTime.Now,
                    Exercises = new List<ExerciseEntry> { new ExerciseEntry(0, "latpulldowns", 3, 2, (float)10.5), new ExerciseEntry(0, "pulldowns", 3, 2, (float)150.5), new ExerciseEntry(0, "latpulldowns", 3, 2, (float)10000.5)}
                };

                WorkoutEntries.Add(newEntry);
            });
        }

    }
}
