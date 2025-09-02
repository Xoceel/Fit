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

        public float WeightEntered { get; set; }

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
        public ICommand DeleteAllWeightEntriesCommand { get; }

        public WeightEntryViewModel(FitnessDatabase database)
        {
            _database = database;
            WeightEntries = new ObservableCollection<WeightEntry>();

            AddWeightCommand = new Command(async () => await AddWeightAsync());
            DeleteAllWeightEntriesCommand = new Command(async () => await DeleteAllEntriesAsync(WeightEntries));

            Task.Run(async () => await LoadEntriesAsync());
        }

        public async Task LoadEntriesAsync()
        {
            var entries = await _database.GetWeightEntriesAsync();
            WeightEntries = new ObservableCollection<WeightEntry>();
            foreach (var entry in entries)
            {
                WeightEntries.Add(entry);
            }
        }

        private async Task DeleteAllEntriesAsync(ObservableCollection<WeightEntry> weights)
        {
            foreach (var entry in weights)
            {
                await _database.DeleteWeightEntryAsync(entry);
            }
            await LoadEntriesAsync();
        }

        private async Task AddWeightAsync()
        {
            var newEntry = new WeightEntry
            {
                Date = DateTime.Now,
                Weight = (float)WeightEntered
            };

            await _database.SaveWeightEntryAsync(newEntry);
            WeightEntries.Add(newEntry);
        }
    }
}
