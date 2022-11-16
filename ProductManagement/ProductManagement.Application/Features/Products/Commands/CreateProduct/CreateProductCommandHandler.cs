
using ProductManagement.Application.Contracts.Persistence;

namespace ProductManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
{
    private readonly IAsyncRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var createProductCommandResponse = new CreateProductCommandResponse();
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            createProductCommandResponse.Success = false;
            createProductCommandResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (createProductCommandResponse.Success)
        {
            var product = new Product()
            {
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductQuantity = request.ProductQuantity,
                ProductDescription = request.ProductDescription,
                Active = true,
                CreatedDate = DateTime.Now
            };

            product = await _productRepository.AddAsync(product);
            createProductCommandResponse.Product = _mapper.Map<CreateProductDto>(product);
        }

        return createProductCommandResponse;
    }
}