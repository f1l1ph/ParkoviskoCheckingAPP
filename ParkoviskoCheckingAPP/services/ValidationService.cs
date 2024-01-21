using Refit;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ParkoviskoCheckingAPP.services;

public class ValidationService
{
    private readonly IAPI _api;

    public ValidationService()
    {
        _api = RestService.For<IAPI>(GlobalVars.CarApiUrl);
    }

    public async Task<bool> ValidateAndCheckLicensePlate(string licensePlate)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await AuthenticationService.GetToken());
            var car = await _api.CheckForExistingCar(licensePlate, token.ToString());

            return (ValidateLicensePlate(licensePlate) && !car);
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return false;
        }
    }

    public bool ValidateLicensePlate(string licensePlate)
    {
        var pattern = @"^[A-Z]{2}\d{3}[A-Z]{2}$";
        var regex = new Regex(pattern);

        return regex.IsMatch(licensePlate);

    }
}

