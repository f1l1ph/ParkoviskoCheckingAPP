using Microsoft.AspNetCore.Mvc;
using ParkoviskoCheckingAPP.Data;
using Refit;

namespace ParkoviskoCheckingAPP.services;

public interface IAPI
{
    [Get("/Car/GetByID/{id}")]
    Task<Car> GetCarByID(int id, [Header("Authorization")] string bearerToken);

    [Get("/Car/GetByPlate/{plate}")]
    Task<Car> GetCarByPlate(string plate, [Header("Authorization")] string bearerToken);

    [Get("/Car/GetAll")]
    Task<List<Car>> GetAllCars([Header("Authorization")] string bearerToken);

    [Get("/Car/CheckForExisting/{plate}")]
    Task<bool> CheckForExistingCar(string plate, [Header("Authorization")] string bearerToken);

    [Post("/Car/Create")]
    Task CreateNewCar(Car car, [Header("Authorization")] string bearerToken);

    [Post("/Car/Edit")]
    Task<bool> EditCar (int id, Car car, [Header("Authorization")] string bearerToken);

    [Delete("/Car/DeleteById/{id}")]
    Task<bool> DeleteCar(int id, [Header("Authorization")] string bearerToken);

    [Post("/User/login")]
    Task<TokenLoginModel> LoginUser(LoginModel model);

    [Post("/CheckLicensePlate/")]
    Task<string> CheckPlateByImage([AliasAs("image")] ByteArrayPart image, [Header("Authorization")] string bearerToken);

}
