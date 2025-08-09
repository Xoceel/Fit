namespace Fit.Views;
using Fit.ViewModels;

public partial class CalorieTrackingPage : ContentPage
{
	public CalorieTrackingPage()
	{
		InitializeComponent();
		BindingContext = new CalorieEntryViewModel();
	}
}