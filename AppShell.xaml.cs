using ProfGid.View;
namespace ProfGid
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ProfessionTestResultPage", typeof(ProfessionTestResultPage));
            Routing.RegisterRoute(nameof(ProfessionTestPage), typeof(ProfessionTestPage));
        }
    }
}
