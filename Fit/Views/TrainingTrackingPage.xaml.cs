using Fit.Data;
using Fit.ViewModels;

namespace Fit.Views;

public partial class TrainingTrackingPage : ContentPage
{
	private readonly FitnessDatabase _database;
	public TrainingTrackingPage(FitnessDatabase database)
	{
		InitializeComponent();
		_database = database;
		BindingContext = new WorkoutEntryViewModel(_database);
	}
}