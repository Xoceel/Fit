namespace Fit.Views;

using Fit.Data;
using Fit.ViewModels;

public partial class WeightTrackingPage : ContentPage
{
	private readonly FitnessDatabase _database;
	public WeightTrackingPage(FitnessDatabase database)
	{
		InitializeComponent();
		_database = database;
		BindingContext = new WeightEntryViewModel(_database);
	}
}