using System.Threading.Tasks;

namespace ProfGid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void HomeButton_Tapped(object sender, TappedEventArgs e)
        { 

        }
        private async void SpecialitiesButton_Tapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync("//SpecialitiesPage");
        }
        private async void PhoneButton_Tapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync("//ContactsPage");
        }
    }

}
