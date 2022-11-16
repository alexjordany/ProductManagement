namespace ProductManagement.Application.Features.Products.Queries.GetProductDetail;

public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
{
    private readonly IAsyncRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetProductDetailQueryHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
    {
        var productDetail = await _productRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ProductDetailVm>(productDetail); 
    }
}