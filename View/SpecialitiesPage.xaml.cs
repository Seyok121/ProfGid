using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Toast;
namespace ProfGid;

public partial class SpecialitiesPage : ContentPage
{
	public SpecialitiesPage()
	{
		InitializeComponent();
	}
    private async void HomeButton_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
    private void SpecialitiesButton_Tapped(object sender, TappedEventArgs e)
    {

    }
    private async void PhoneButton_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactsPage");
    }
}