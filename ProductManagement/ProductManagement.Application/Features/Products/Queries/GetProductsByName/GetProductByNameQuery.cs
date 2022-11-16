namespace ProductManagement.Application.Features.Products.Queries.GetProductsByName;

public class GetProductByNameQuery : IRequest<List<ProductByNameVm>>
{
    public string? Name { get; set; }
}