using ParkoviskoCheckingAPP.Data;
using Refit;

namespace ParkoviskoCheckingAPP.services;

//[Headers("Authorization")]
public interface IAPI
{
    [Get("/GetByID/{id}")]
    Task GetCarByID(int id);

    [Get("/GetByPlate/{plate}")]
    Task GetCarByPlate(string plate);

    [Get("/GetAll")]
    Task<List<Car>> GetAllCars();

    [Get("/CheckForExisting/{plate}")]
    Task CheckForExistingCar(string plate);

    [Post("/Create")]
    Task CreateNewCar(Car car);

    [Post("/Edit")]
    Task EditCar(int id, Car car);

    [Delete("/DeleteById/{id}")]
    Task DeleteCar(int id);
}
