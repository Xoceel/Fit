using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Fit.Models;

namespace Fit.ViewModels
{
    internal class WeightEntryViewModel : INotifyPropertyChanged
    {
        // This event tells the UI that a property has changed
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise the PropertyChanged event
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // The collection bound to the UI
        private ObservableCollection<WeightEntry> _weightEntries;

        public ObservableCollection<WeightEntry> WeightEntries
        {
            get => _weightEntries;
            set
            {
                if (_weightEntries != value)
                {
                    _weightEntries = value;
                    OnPropertyChanged();
                }
            }
        }

        // Command to add a new weight entry
        public ICommand AddWeightCommand { get; }

        // Test set of weight entries
        public WeightEntryViewModel()
        {
            WeightEntries = new ObservableCollection<WeightEntry>
            {
                new WeightEntry {Id = 0, Date = DateTime.Now.AddDays(-2), Weight = 88.4f},
                new WeightEntry {Id = 1, Date = DateTime.Now.AddDays(3), Weight = 80.9f},
                new WeightEntry {Id = 2, Date = DateTime.Now.AddDays(1), Weight = 78.5f}
            };

            AddWeightCommand = new Command(() =>
            {
                var newEntry = new WeightEntry
                {
                    Id = WeightEntries.Count + 1,
                    Date = DateTime.Now,
                    Weight = 99.9f
                };

                WeightEntries.Add(newEntry);
            });
        }
    }
}
