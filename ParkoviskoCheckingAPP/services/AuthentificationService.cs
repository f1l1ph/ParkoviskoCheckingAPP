using ParkoviskoCheckingAPP.Data;
using System.Net.Http.Json;
using System.Text.Json;

namespace ParkoviskoCheckingAPP.services;

public class AuthentificationService
{
    string tokenKey = "AuthToken";

    HttpClient _client;
    JsonSerializerOptions _serializerOptions;
    //public string userURL = "https://localhost:7069";
    //public string userURL = "http://10.0.2.2:5026";
    public string userURL = "http://192.168.1.35:5026";

    TokenLoginModel tlm;
    public AuthentificationService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(userURL);
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<bool> Login(LoginModel model)
    {
        try
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(userURL + "/User/login", new { name = model.UserName, email = model.Email, password = model.Password });
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                tlm = JsonSerializer.Deserialize<TokenLoginModel>(content, _serializerOptions);

                await SecureStorage.SetAsync(tokenKey, tlm.Token); // save token
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

    public async Task<string> GetToken()
    {
        return await SecureStorage.GetAsync(tokenKey);
    }

    //var value = await SecureStorage.GetAsync(AuthToken); //--for getting value

    //function for http request to /login

    //function for try login on app start-up using already stored tokenKey
}
