namespace ProductManagement.Application.Features.Products.Queries.GetProductDetail;

public class GetProductDetailQuery : IRequest<ProductDetailVm>
{
    public int Id { get; set; }
}