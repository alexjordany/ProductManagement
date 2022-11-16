namespace ProductManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty().WithMessage("El nombre del producto es obligatorio").MaximumLength(35)
            .WithMessage("{PropertyName} no debe exceder 35 caracteres").NotNull();
        RuleFor(p => p.ProductQuantity).GreaterThanOrEqualTo(0)
            .WithMessage("La cantidad de este producto debe ser mayor o igual que 0");
        RuleFor(p => p.ProductDescription).MaximumLength(150)
            .WithMessage("La descripcion no debe exceder 150 caracteres");
        RuleFor(p => p.ProductPrice).NotEmpty().WithMessage("El precio del producto es obligatorio").NotNull()
            .GreaterThanOrEqualTo(0).WithMessage("El precio no debe ser inferior a 0");
    }
}