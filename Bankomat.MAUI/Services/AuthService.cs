namespace Bankomat.MAUI.Services;

public class AuthService
{
    public AuthService()
    {
        //SecureStorage.Default.RemoveAll();
        Task.Run(async () =>
        {
            await Init();
        });
    }

    public async Task Init()
    {
        try
        {
            var firstRun = await SecureStorage.Default.GetAsync("IsFirstRun");
            if (firstRun == null)
            {
                await SecureStorage.Default.SetAsync("IsFirstRun", "true");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message.ToString());
        }
    }

    public async Task<bool> CheckIfFirstRunAsync()
    {
        var isFirstRun = await SecureStorage.Default.GetAsync("IsFirstRun");
        if (isFirstRun != null)
        {
            if (isFirstRun == "true")
            {
                return true;
            }
            else if (isFirstRun == "false")
            {
                return false;
            }
        }

        return true;
    }

    public async Task ChangeFirstRunToFalse()
    {
        await SecureStorage.Default.SetAsync("IsFirstRun", "false");
    }
}