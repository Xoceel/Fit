using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Fit.Models;

namespace Fit.ViewModels
{
    internal class CalorieEntryViewModel : INotifyPropertyChanged
    {
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

        public CalorieEntryViewModel()
        {
            CalorieEntries = new ObservableCollection<CalorieEntry>
            {
                new CalorieEntry { Id = 0, Date = DateTime.Now.AddDays(-3), Calories = 500, Carbs = 50, Fat = 30, Protein = 77 },
                new CalorieEntry { Id = 0, Date = DateTime.Now.AddDays(-1), Calories = 200, Carbs = 30, Fat = 100, Protein = 33 },
                new CalorieEntry { Id = 0, Date = DateTime.Now.AddDays(-9), Calories = 800, Carbs = 20, Fat = 15, Protein = 88 }
            };

            AddCalorieCommand = new Command(() =>
            {
                var newEntry = new CalorieEntry
                {
                    Id = CalorieEntries.Count + 1,
                    Date = DateTime.Now,
                    Calories = 99,
                    Carbs = 99,
                    Fat = 99,
                    Protein = 99
                };
                CalorieEntries.Add(newEntry);
            });
        }
    }
}
