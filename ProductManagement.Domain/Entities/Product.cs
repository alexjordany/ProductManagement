namespace ProductManagement.Domain.Entities;

public class Product : AuditableEntity
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int ProductQuantity { get; set; }
    public double ProductPrice { get; set; }
    
}