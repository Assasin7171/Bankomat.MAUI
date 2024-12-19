using System.Windows.Input;
using Bankomat.MAUI.Commands;
using Bankomat.MAUI.Services;
using Bankomat.MAUI.Views;

namespace Bankomat.MAUI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private AuthService AuthService { get; }
    public ICommand GoToAdminPageCommand { get; }
    public ICommand InsertCardCommand { get; }
    
    public bool IsFirstRun => AuthService.IsFirstRun;
    public bool DisplayLayout => !IsFirstRun;

    private bool _isThereIsACard = false;
    public bool IsThereIsACard
    {
        get
        {
            return _isThereIsACard;
        }
        set
        {
            SetField(ref _isThereIsACard, value);
        }
    }

    public MainViewModel(AuthService authService)
    {
        AuthService = authService;
        GoToAdminPageCommand = new RelayCommandAsync(async o => await GoToAdminPanelView());
        InsertCardCommand = new RelayCommand(o => InsertCardToAtm());
    }

    private async Task GoToAdminPanelView()
    {
        await Shell.Current.GoToAsync(nameof(AdminPanelView));
    }

    private void InsertCardToAtm()
    {
        IsThereIsACard = true;
    }

}