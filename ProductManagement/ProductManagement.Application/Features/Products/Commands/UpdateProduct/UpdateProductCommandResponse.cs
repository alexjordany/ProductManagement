using ProductManagement.Application.Responses;

namespace ProductManagement.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandResponse : BaseResponse
{
    public UpdateProductCommandResponse(): base()
    {
        
    }
    
    public UpdateProductDto Product { get; set; }
}