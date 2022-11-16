namespace ProductManagement.Application.Features.Products.Commands.UpdateProduct;

public record UpdateProductDto(int ProductId, string ProductName, int ProductQuantity, double ProductPrice);