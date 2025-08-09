namespace Fit.Views;

using Fit.ViewModels;

public partial class WeightTrackingPage : ContentPage
{
	public WeightTrackingPage()
	{
		InitializeComponent();
		BindingContext = new WeightEntryViewModel();
	}
}