namespace Fit.Views;

using Fit.Data;
using Fit.ViewModels;

public partial class CalorieTrackingPage : ContentPage
{
	private readonly FitnessDatabase _database;
	public CalorieTrackingPage(FitnessDatabase database)
	{
		InitializeComponent();
		_database = database;
		BindingContext = new CalorieEntryViewModel(_database);
	}

    private void ClickToShowPopup_Clicked(object sender, EventArgs e)
    {
        popup.Show();
    }

    private void ClickToClosePopup_Clicked(object sender, EventArgs e)
    {
        popup.Dismiss();
    }
}