using ParkoviskoCheckingAPP.Data;
using Refit;

namespace ParkoviskoCheckingAPP.services;

public interface IAPI
{
    [Get("/GetByID/{id}")]
    Task<Car> GetCarByID(int id, [Header("Authorization")] string bearerToken);

    [Get("/GetByPlate/{plate}")]
    Task<Car> GetCarByPlate(string plate, [Header("Authorization")] string bearerToken);

    [Get("/GetAll")]
    Task<List<Car>> GetAllCars([Header("Authorization")] string bearerToken);

    [Get("/CheckForExisting/{plate}")]
    Task<Car> CheckForExistingCar(string plate, [Header("Authorization")] string bearerToken);

    [Post("/Create")]
    Task CreateNewCar(Car car, [Header("Authorization")] string bearerToken);

    [Post("/Edit")]
    Task EditCar(int id, Car car, [Header("Authorization")] string bearerToken);

    [Delete("/DeleteById/{id}")]
    Task<bool> DeleteCar(int id, [Header("Authorization")] string bearerToken);
}
