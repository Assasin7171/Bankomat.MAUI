using Bankomat.MAUI.Views;

namespace Bankomat.MAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AdminPanelView), typeof(AdminPanelView));
        Routing.RegisterRoute(nameof(AccountView), typeof(AccountView));
    }
}
