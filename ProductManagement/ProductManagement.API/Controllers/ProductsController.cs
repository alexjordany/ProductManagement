using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Features.Products.Commands.CreateProduct;
using ProductManagement.Application.Features.Products.Commands.DeleteProduct;
using ProductManagement.Application.Features.Products.Commands.UpdateProduct;
using ProductManagement.Application.Features.Products.Queries.GetProductDetail;
using ProductManagement.Application.Features.Products.Queries.GetProductsByName;
using ProductManagement.Application.Features.Products.Queries.GetProductsList;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<ActionResult<CreateProductCommandResponse>> Create(
            [FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);
            return Ok(response);
        }

        [HttpPut("{id:int}", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            var dtos = await _mediator.Send(updateProductCommand);
            return Ok(dtos);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteProductCommand = new DeleteProductCommand() { ProductId = id };
            await _mediator.Send(deleteProductCommand);
            return NoContent();
        }

        [HttpGet("all", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductsListVm>>> GetAllProducts()
        {
            var dtos = await _mediator.Send(new GetProductsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDetailVm>> GetProductById(int id)
        {
            var getProductDetailQuery = new GetProductDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getProductDetailQuery));
        }

        [HttpGet("getbyname/{name}", Name = "GetProductsByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductByNameVm>>> GetProductsByName(string name)
        {
            var dtos = await _mediator.Send(new GetProductByNameQuery { Name = name });
            if (dtos.Any())
                return Ok(dtos);
            return NotFound();
        }






    }
}
