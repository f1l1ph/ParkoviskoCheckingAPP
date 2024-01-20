using ParkoviskoCheckingAPP.services;
using Refit;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace ParkoviskoCheckingAPP.Data;

public class CarService
{
    public string carURL = "https://localhost:7069/Car";
    //public string carURL = "http://10.0.2.2:5026";
    //public string carURL = "http://192.168.1.35:5026";

    readonly AuthentificationService authService_;
    readonly IAPI api;

    public CarService(AuthentificationService authService)
    {
        authService_ = authService;
        api = RestService.For<IAPI>(carURL);
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());
            var cars = await api.GetAllCars(token.ToString());
            return cars;
        }
        catch(ApiException ex) 
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<Car> GetCarAsync(int id)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());
            var car = await api.GetCarByID(id ,token.ToString());
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
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());
            var car = await api.GetCarByPlate(licensePlate, token.ToString());
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
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());
            await api.DeleteCar(id, token.ToString());
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
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());
            await api.CreateNewCar(car, token.ToString());
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
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());
            await api.EditCar(id, car, token.ToString());
            return true;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return false;
        }
    }
}