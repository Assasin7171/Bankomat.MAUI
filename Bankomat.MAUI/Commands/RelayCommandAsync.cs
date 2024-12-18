using System.Windows.Input;

namespace Bankomat.MAUI.Commands;

public class RelayCommandAsync : ICommand
{
    //execute w wersji async, zwraca task
    private readonly Func<object?, Task> _executeAsync;
    //zwraca bool
    private readonly Func<object?, bool> _canExecute;
    //pomocnicza zmienna aby można było wykonać komende tylko jeśli nie jest już wykonywana
    private bool _isExecuting;

    public RelayCommandAsync(Func<object?, Task> executeAsync, Func<object?, bool> canExecute = null)
    {
        _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _canExecute = canExecute;
    }

    //event powiadamiający o możliwych zmianach.
    public event EventHandler? CanExecuteChanged;
    //czy komenda może się wykonać, zwraca true lub false.
    public bool CanExecute(object? parameter)
    {
        return !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);
    }
    //asynchroniczne wykonanie komendy
    public async void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
            return;

        try
        {
            _isExecuting = true;
            await _executeAsync(parameter);
        }
        finally
        {
            _isExecuting = false;
        }

        RaiseCanExecuteChanged();
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}