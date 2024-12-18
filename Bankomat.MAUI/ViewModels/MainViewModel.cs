using System.Windows.Input;
using Bankomat.MAUI.Commands;
using Bankomat.MAUI.Views;

namespace Bankomat.MAUI.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ICommand GoToAdminPageCommand { get; }
    public ICommand InsertCardCommand { get; }

    private bool _isFirstRun = true;

    public bool IsFirstRun
    {
        get => _isFirstRun;
        set => SetField(ref _isFirstRun, value);
    }

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