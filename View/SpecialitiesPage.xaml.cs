using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Toast;
namespace ProfGid;

public partial class SpecialitiesPage : ContentPage
{
    public List<Speciality> Specialities { get; } = new()
    {
        new Speciality { Code = "10.02.05", Name = "Обеспечение информационной безопасности автоматизированных систем" },
        new Speciality { Code = "38.02.01", Name = "Экономика и бухгалтерский учёт (по отраслям)" },
        new Speciality { Code = "09.02.07", Name = "Информационные системы и программирование" },
        new Speciality { Code = "54.02.01", Name = "Дизайн (по отраслям)" },
        new Speciality { Code = "21.02.19", Name = "Землеустройство" },
        new Speciality { Code = "40.02.04", Name = "Юриспруденция" },
        new Speciality { Code = "38.02.08", Name = "Торговое дело" },
        new Speciality { Code = "38.01.02", Name = "Продавец" },
        new Speciality { Code = "38.02.06", Name = "Финансы" }
    };
    public SpecialitiesPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
    private async void OnSpecialityTapped(object sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Speciality speciality)
        {
            await frame.ScaleTo(0.97, 50);
            await frame.ScaleTo(1, 50);
            await Shell.Current.GoToAsync($"ProfessionDetailsPage?profession={Uri.EscapeDataString(speciality.Name)}");
        }
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
    public class Speciality
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string FullName => $"{Code} {Name}";
    }
}