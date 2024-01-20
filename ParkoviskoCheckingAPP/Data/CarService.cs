using ParkoviskoCheckingAPP.services;
using Refit;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace ParkoviskoCheckingAPP.Data;

public class CarService
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;
    public string carURL = "https://localhost:7069/Car";
    //public string carURL = "http://10.0.2.2:5026";
    //public string carURL = "http://192.168.1.35:5026";

    readonly AuthentificationService authService_;

    public CarService(AuthentificationService authService)
    { 
        authService_ = authService;

        _client = new HttpClient();
        _client.BaseAddress = new Uri(carURL);
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
    
    public async Task<List<Car>> GetCarsAsync()
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

            var carApi = RestService.For<IAPI>(carURL);
            var cars = await carApi.GetAllCars(token.ToString());
            return cars;
        }
        catch(ApiException ex) 
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;

            /* var errors = await e.GetContentAsAsync<string>();

             //todo - handle exceptions better
             //var message = string.Join("; ", errors.Values);

             return null;
             throw new Exception(errors);*/
        }

        /*if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.Content.Message);
        }
        var cars = response.Content.Result;
        return cars;*/

        /*List<Car> cars;

        cars = new List<Car>();
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());
        try
        {
            HttpResponseMessage response = await _client.GetAsync(carURL + "/Car/GetAll");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                cars = JsonSerializer.Deserialize<List<Car>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return cars;*/
    }

    public async Task<Car> GetCarAsync(int id)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

            var carApi = RestService.For<IAPI>(carURL);
            var car = await carApi.GetCarByID(id ,token.ToString());
            return car;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
            /*
            Car car = null;
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

            try
            {
                HttpResponseMessage response = await _client.GetAsync(carURL + "/Car/GetById/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    car = JsonSerializer.Deserialize<Car>(content, _serializerOptions);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return car;*/
        }

    public async Task<Car> GetCarByPlateAsync(string licensePlate)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

            var carApi = RestService.For<IAPI>(carURL);
            var car = await carApi.GetCarByPlate(licensePlate, token.ToString());
            return car;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }

        /*Car car = null;
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

        try
        {
            HttpResponseMessage response = await _client.GetAsync(carURL + "/Car/GetByPlate/" + licensePlate);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                car = JsonSerializer.Deserialize<Car>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return car;*/
    }

    public async Task<bool> DeleteCar(int id) 
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

            var carApi = RestService.For<IAPI>(carURL);
            await carApi.DeleteCar(id, token.ToString());
            return true;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return false;
        }

        /*_client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

        try
        {
            HttpResponseMessage response = await _client.DeleteAsync(carURL + "/Car/DeleteById/" + id);
            if (response.IsSuccessStatusCode)
            {
                return true; 
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return false;*/
    } 

    public async Task<bool> AddCar(Car car)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

            var carApi = RestService.For<IAPI>(carURL);
            await carApi.CreateNewCar(car, token.ToString());
            return true;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return false;
        }

        /*
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());
        try
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(carURL + "/Car/Create", 
                new { 
                    id = car.ID, 
                    name = car.Name, 
                    plateNumber = car.PlateNumber,
                    expirationDate = car.ExpirationDate,
                    description = car.Description 
                });

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return false;*/
    }

    public async Task<bool> EditCar(int id, Car car)
    {
        try
        {
            var token = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

            var carApi = RestService.For<IAPI>(carURL);
            await carApi.EditCar(id, car, token.ToString());
            return true;
        }
        catch (ApiException ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return false;
        }
    }
}