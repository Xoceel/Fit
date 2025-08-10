using Fit.ViewModels;

namespace Fit.Views;

public partial class TrainingTrackingPage : ContentPage
{
	public TrainingTrackingPage()
	{
		InitializeComponent();
		BindingContext = new WorkoutEntryViewModel();
	}
}