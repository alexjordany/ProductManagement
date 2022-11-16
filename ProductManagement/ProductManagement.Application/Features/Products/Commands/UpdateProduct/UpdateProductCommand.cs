namespace ProductManagement.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int ProductQuantity { get; set; }
    public double ProductPrice { get; set; }
    public string? ProductDescription { get; set; }
}