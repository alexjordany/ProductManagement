namespace ProductManagement.Application.Features.Products.Queries.GetProductDetail;

public record ProductDetailVm(int ProductId, string ProductName, int ProductQuantity, double ProductPrice, string ProductDescription);