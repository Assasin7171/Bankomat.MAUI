using Bankomat.MAUI.Commands;
using Bankomat.MAUI.Services;

namespace Bankomat.MAUI.ViewModels;

public class AdminPanelViewModel
{
    private readonly AuthService _authService;
    public RelayCommandAsync SaveChangesCommandAsync { get; }

    public AdminPanelViewModel(AuthService authService)
    {
        _authService = authService;
        SaveChangesCommandAsync = new RelayCommandAsync((o => SaveItsNotFirstTimeStart()));
    }

    private async Task SaveItsNotFirstTimeStart()
    {
        await SecureStorage.Default.SetAsync("IsFirstRun", "false");
    }
}