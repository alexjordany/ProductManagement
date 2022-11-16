namespace ProductManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductCommandResponse>
{
    public string ProductName { get; set; } = string.Empty;
    public int ProductQuantity { get; set; }
    public double ProductPrice { get; set; }
    public string? ProductDescription { get; set; }
}