namespace ProductManagement.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"No se encontro {name} ({key} is not found")
    {
        
    }
}