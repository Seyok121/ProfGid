using System.Threading.Tasks;

namespace ProfGid;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}
    private async void HomeButton_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
    private async void SpecialitiesButton_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//SpecialitiesPage");
    }
    private void PhoneButton_Tapped(object sender, TappedEventArgs e)
    {

    }
    private async void EmailLabel_Tapped(object sender, TappedEventArgs e)
    {
        await Clipboard.Default.SetTextAsync("v-filial@mail.ru");
    }
}