namespace Bankomat.MAUI.Services;

public class AuthService
{
    private bool _isFirstRun = true;
    
    public async Task<bool> IsFirstRunAsync()
    {
        await Task.Delay(2000);

        return _isFirstRun;
    }

    public void SetFirstRun()
    {
        _isFirstRun = false;
    }
}