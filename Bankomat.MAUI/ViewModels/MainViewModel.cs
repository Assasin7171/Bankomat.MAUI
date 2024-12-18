using System.Windows.Input;
using Bankomat.MAUI.Commands;
using Bankomat.MAUI.Views;

namespace Bankomat.MAUI.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ICommand GoToAdminPageCommand { get; }

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

    public MainViewModel()
    {
        GoToAdminPageCommand = new RelayCommandAsync(async o => await GoToAdminPanelView());
    }

    private async Task GoToAdminPanelView()
    {
        await Shell.Current.GoToAsync(nameof(AdminPanelView));
    }

}