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

    private bool _isFirstRun, _isThereIsACard, _displayLayout;

    public bool IsFirstRun
    {
        get => _isFirstRun;
        set
        {
            if (_isFirstRun != value)
            {
                SetField(ref _isFirstRun, value);
            }
        }
    }

    public bool DisplayLayout
    {
        get => _displayLayout;
        set => SetField(ref _displayLayout, value);
    }

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

        Task.Run(async () =>
        {
            _isFirstRun = await authService.CheckIfFirstRunAsync();
            _displayLayout = !_isFirstRun;

            OnPropertyChanged(nameof(IsFirstRun));
            OnPropertyChanged(nameof(DisplayLayout));
        });

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