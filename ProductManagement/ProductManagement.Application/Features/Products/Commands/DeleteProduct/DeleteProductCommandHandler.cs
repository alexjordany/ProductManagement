namespace ProductManagement.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IAsyncRepository<Product> _productRepository;

    public DeleteProductCommandHandler(IAsyncRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var medicineToDelete = await _productRepository.GetByIdAsync(request.ProductId);

        await _productRepository.DeleteAsync(medicineToDelete);
        return Unit.Value;
    }
}