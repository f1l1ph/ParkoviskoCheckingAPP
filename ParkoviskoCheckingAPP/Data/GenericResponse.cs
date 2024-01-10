namespace ParkoviskoCheckingAPP.Data;

public class GenericResponse<T>
{ 
    public bool IsSuccess { get; set; }
    public List<Car> Result { get; set; }
    public string Message { get; set; }
}
