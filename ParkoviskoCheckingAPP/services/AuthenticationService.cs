using ParkoviskoCheckingAPP.Data;
using Refit;

namespace ParkoviskoCheckingAPP.services;

public class AuthenticationService
{
    private readonly IAPI _api;


    public AuthenticationService()
    {
        _api = RestService.For<IAPI>(GlobalVars.CarApiUrl);
    }

    public async Task<bool> Login(LoginModel model)
    {
        try
        {
            var token = await _api.LoginUser(model);
            if(token != null)
            {
                await SecureStorage.SetAsync(GlobalVars.TokenKey, token.Token);
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"\tERROR {0}", ex.Message);
            return false;
        }
        return false;
    }

    public static async Task<string> GetToken()
    {
        return await SecureStorage.GetAsync(GlobalVars.TokenKey);
    }
}
