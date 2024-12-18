using Bankomat.MAUI.Views;

namespace Bankomat.MAUI;

public partial class AppShell : Shell
{
    public bool ItsFirstRunOfAtm
    {
        get => (bool)GetValue(IsLoggedProperty);
        set => SetValue(IsLoggedProperty, value);
    }

    public static readonly BindableProperty IsLoggedProperty = BindableProperty.Create(nameof(ItsFirstRunOfAtm),
        typeof(bool), typeof(AppShell), false, propertyChanged: IsLogged_PropertyChanged);

    private static void IsLogged_PropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if ((bool)newvalue)
        {

        }
        else
        {

        }
    }

    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AdminPanelView), typeof(AdminPanelView));
        Routing.RegisterRoute(nameof(AccountView), typeof(AccountView));
        Routing.RegisterRoute(nameof(MainView), typeof(MainView));
    }
}