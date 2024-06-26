﻿using ParkoviskoCheckingAPP.services;
using Refit;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ParkoviskoCheckingAPP.Validations;

public class ValidationHelper
{
    private readonly IAPI _api;

    public ValidationHelper()
    {
        _api = RestService.For<IAPI>(GlobalVars.CarApiUrl);
    }

    public async Task<bool> ValidateAndCheckLicensePlate(string licensePlate)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await AuthenticationService.GetToken());
            var car = await _api.CheckForExistingCar(licensePlate, token.ToString());

            return true; //!car; //ValidateLicensePlate(licensePlate) && !car;
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

