namespace Bankomat.MAUI.Services;

public class AuthService
{
    public async Task<bool> IsFirstRunAsync()
    {
        await Task.Delay(2000);

        return true;
    }
}