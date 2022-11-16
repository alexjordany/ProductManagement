namespace ProductManagement.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public  int ProductId { get; set; }
}