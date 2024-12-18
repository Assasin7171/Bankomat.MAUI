using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat.MAUI.Services;

namespace Bankomat.MAUI.Views;

public partial class LoadingPage : ContentPage
{
    private readonly AuthService _authService;

    public LoadingPage(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authService.IsFirstRunAsync())
        {
            //it's first run of ATM
            IsVisible = false; //hide this page
            //(Shell.Current as AppShell).ItsFirstRunOfAtm = true;
            await Shell.Current.GoToAsync($"{nameof(AdminPanelView)}");
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }
        else
        {
            //it's not first run of ATM
            await Shell.Current.GoToAsync($"{nameof(MainView)}");
        }

    }
}