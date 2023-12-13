using ParkoviskoCheckingAPP.services;
using System.Diagnostics;
using System.Text.Json;

namespace ParkoviskoCheckingAPP.Data
{
    public class CarService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        //public string carURL = "https://localhost:7069";
        //public string carURL = "http://10.0.2.2:5026";
        public string carURL = "http://192.168.1.35:5026";

        AuthentificationService authService_;

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
            List<Car> cars;

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
            return cars;
        }


        public async Task<Car> GetCarAsync(int id)
        {
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
            return car;
        }
        public async Task<Car> GetCarByPlateAsync(string licensePlate)
        {
            Car car = null;
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
            return car;
        }

        public async Task<bool> DeleteCar(string id) 
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService_.GetToken());

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
            return false;
        } 
    }
}