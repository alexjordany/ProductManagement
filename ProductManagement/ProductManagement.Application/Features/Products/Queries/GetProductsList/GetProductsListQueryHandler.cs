namespace ProductManagement.Application.Features.Products.Queries.GetProductsList;

public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductsListVm>>
{
    private readonly IAsyncRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetProductsListQueryHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<ProductsListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        var allProducts = (await _productRepository.ListAllAsync()).OrderBy(x => x.ProductName);
        return _mapper.Map<List<ProductsListVm>>(allProducts);
    }
}