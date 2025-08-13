using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Fit.Data;
using Fit.Models;

namespace Fit.ViewModels
{
    internal class WeightEntryViewModel : INotifyPropertyChanged
    {
        private readonly FitnessDatabase _database;

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

        public WeightEntryViewModel(FitnessDatabase database)
        {
            _database = database;
            WeightEntries = new ObservableCollection<WeightEntry>();

            AddWeightCommand = new Command(async () => await AddWeightAsync());

            Task.Run(async () => await LoadEntriesAsync());
        }

        public async Task LoadEntriesAsync()
        {
            var entries = await _database.GetWeightEntriesAsync();
            WeightEntries.Clear();
            foreach (var entry in entries)
            {
                WeightEntries.Add(entry);
            }
        }

        private async Task AddWeightAsync()
        {
            var newEntry = new WeightEntry
            {
                Date = DateTime.Now,
                Weight = 99.9f
            };

            await _database.SaveWeightEntryAsync(newEntry);
            WeightEntries.Add(newEntry);
        }
    }
}
