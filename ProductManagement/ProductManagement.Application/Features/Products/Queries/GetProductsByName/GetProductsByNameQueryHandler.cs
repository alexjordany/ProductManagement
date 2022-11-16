namespace ProductManagement.Application.Features.Products.Queries.GetProductsByName;

public class GetProductsByNameQueryHandler : IRequestHandler<GetProductByNameQuery, List<ProductByNameVm>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsByNameQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<ProductByNameVm>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var getByName = await _productRepository.GetProductsByName(request.Name);
        return _mapper.Map<List<ProductByNameVm>>(getByName);
    }
}