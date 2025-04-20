using ProfGid.Model;
using ProfGid.ViewModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

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
            _profession = Uri.UnescapeDataString(value ?? string.Empty);
            OnPropertyChanged();
            UpdateResultText();
        }
    }
    public ProfessionTestResultPage()
    {
        InitializeComponent();
    }
    private void UpdateResultText()
    {
        if (!string.IsNullOrEmpty(Profession))
        {
            ResultLabel.Text = $"Вы прошли тест на помощь в выборе специальности. На основе ваших ответов мы определили, что вам может быть интересна такая профессия, как: {Profession}";
        }
    }
    private async void OnMainButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is ProfessionTestViewModel vm)
        {
            vm.ResetTestData();
        }

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