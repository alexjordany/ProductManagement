using ProductManagement.Application.Features.Products.Commands.CreateProduct;
using ProductManagement.Application.Features.Products.Commands.UpdateProduct;
using ProductManagement.Application.Features.Products.Queries.GetProductDetail;
using ProductManagement.Application.Features.Products.Queries.GetProductsByName;
using ProductManagement.Application.Features.Products.Queries.GetProductsList;

namespace ProductManagement.Application.Profiles.Products;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, ProductDetailVm>().ReverseMap();
        CreateMap<Product, ProductByNameVm>().ReverseMap();
        CreateMap<Product, ProductsListVm>().ReverseMap();
    }
}