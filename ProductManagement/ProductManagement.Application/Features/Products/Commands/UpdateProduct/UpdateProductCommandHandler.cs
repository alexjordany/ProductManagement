namespace ProductManagement.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
{
    private readonly IAsyncRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var updateProductCommandResponse = new UpdateProductCommandResponse();
        var validator = new UpdateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        var productToUpdate = await _productRepository.GetByIdAsync(request.ProductId);

        if (validationResult.Errors.Count > 0)
        {
            updateProductCommandResponse.Success = false;
            updateProductCommandResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                updateProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (updateProductCommandResponse.Success)
        {
            productToUpdate.LastModifiedDate = DateTime.Now;
            var product = _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));
            await _productRepository.UpdateAsync(productToUpdate);
            updateProductCommandResponse.Product = _mapper.Map<UpdateProductDto>(product);
        }

        return updateProductCommandResponse;
    }
}