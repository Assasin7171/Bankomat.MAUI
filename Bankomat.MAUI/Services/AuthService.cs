namespace Bankomat.MAUI.Services;

public class AuthService
{
    public bool IsFirstRun { get; private set; }

    public AuthService()
    {
        Task.Run(async () => { await Init(); });
    }

    private async Task Init()
    {
        try
        {
            var isFirstRun = await SecureStorage.Default.GetAsync("IsFirstRun");
            if (isFirstRun != null)
            {
                if (isFirstRun == "true")
                {
                    IsFirstRun = true;
                }
                else if (isFirstRun == "false")
                {
                    IsFirstRun = false;
                }
            }
            else
            {
                IsFirstRun = true;
                await SecureStorage.Default.SetAsync("IsFirstRun", "true");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"SecureStorage error: {e.Message}");
            Console.WriteLine($"Stack trace: {e.StackTrace}");
            // Opcjonalnie przeanalizuj rodzaj wyjątku:
            if (e is UnauthorizedAccessException)
            {
                Console.WriteLine("Brak uprawnień do korzystania z SecureStorage.");
            }
            else
            {
                Console.WriteLine("Inny błąd związany z SecureStorage.");
            }
            throw; 
        }
    }

    public async Task SwitchIsFirstRunToFalse()
    {
        await SecureStorage.Default.SetAsync("IsFirstRun", "false");
        IsFirstRun = false;
    }
}