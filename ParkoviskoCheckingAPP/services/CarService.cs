using Microsoft.AspNetCore.Mvc;
using ParkoviskoCheckingAPP.Data;
using Refit;
using System.Diagnostics;

namespace ParkoviskoCheckingAPP.services;

public class CarService
{
    private readonly IAPI _api;

    public CarService()
    {
        _api = RestService.For<IAPI>(GlobalVars.CarApiUrl);
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await AuthenticationService.GetToken());
            var cars = await _api.GetAllCars(token.ToString());
            return cars;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<Car> GetCarAsync(int id)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await AuthenticationService.GetToken());
            var car = await _api.GetCarByID(id, token.ToString());
            return car;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<Car> GetCarByPlateAsync(string licensePlate)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await AuthenticationService.GetToken());
            var car = await _api.GetCarByPlate(licensePlate, token.ToString());
            return car;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<bool> DeleteCar(int id)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await AuthenticationService.GetToken());
            await _api.DeleteCar(id, token.ToString());
            return true;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return false;
        }
    }

    public async Task<bool> AddCar(Car car)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await AuthenticationService.GetToken());
            await _api.CreateNewCar(car, token.ToString());
            return true;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return false;
        }
    }

    public async Task<bool> EditCar(int id, Car car)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await AuthenticationService.GetToken());
            await _api.EditCar(id, car, token.ToString());
            return true;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return false;
        }
    }

    public async Task<string> CheckLicensePlateByImageTask([FromForm] ByteArrayPart image)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await AuthenticationService.GetToken());
            var something = await _api.CheckPlateByImage(image, token.ToString());
            return something;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}