using ProfGid.Model;
using ProfGid.ViewModel;
using System.Threading.Tasks;

namespace ProfGid.View;
[QueryProperty(nameof(Profession), "profession")]
public partial class ProfessionTestResultPage : ContentPage
{
    private string _profession;
    public string Profession
    {
        get => _profession;
        set
        {
            _profession = Uri.UnescapeDataString(value);
            OnPropertyChanged();
        }
    }

    public ProfessionTestResultPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
    private async void OnWebsiteTapped(object sender, EventArgs e)
    {
        if (sender is Label label)
        {
            await label.FadeTo(0.5, 100);
            await Task.Delay(100);
            await label.FadeTo(1, 100);

            try
            {
                await Launcher.OpenAsync(new Uri("https://vfilial.rgust.ru"));
            }
            catch
            {
                await DisplayAlert("Ошибка", "Не удалось открыть сайт", "OK");
            }
        }
    }
}