using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Features.Products.Commands.CreateProduct;
using ProductManagement.Application.Features.Products.Commands.DeleteProduct;
using ProductManagement.Application.Features.Products.Commands.UpdateProduct;
using ProductManagement.Application.Features.Products.Queries.GetProductDetail;
using ProductManagement.Application.Features.Products.Queries.GetProductsByName;
using ProductManagement.Application.Features.Products.Queries.GetProductsList;

namespace ProductManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "Crear Producto")]
    public async Task<ActionResult<CreateProductCommandResponse>> Create(
        [FromBody] CreateProductCommand createProductCommand)
    {
        var response = await _mediator.Send(createProductCommand);
        return Ok(response);
    }

    [HttpPut("{id:int}", Name = "Actualizar Producto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {
        var dtos = await _mediator.Send(updateProductCommand);
        return Ok(dtos);
    }

    [HttpDelete("{id}", Name = "Eliminar Producto")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var deleteProductCommand = new DeleteProductCommand() { ProductId = id };
        await _mediator.Send(deleteProductCommand);
        return NoContent();
    }

    [HttpGet("all", Name = "ListaProductos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProductsListVm>>> GetAllProducts()
    {
        var dtos = await _mediator.Send(new GetProductsListQuery());
        return Ok(dtos);
    }
    
    [HttpGet("{id:int}", Name = "ProductoPorId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDetailVm>> GetProductById(int id)
    {
        var dtos = await _mediator.Send(new GetProductDetailQuery { Id = id });
        if (dtos is not null)
            return Ok(dtos);
        return NotFound();


    }

    [HttpGet("getbyname/{name}", Name = "ProductosPorNombre")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProductByNameVm>>> GetProductsByName(string name)
    {
        var dtos = await _mediator.Send(new GetProductByNameQuery { Name = name });
        if (dtos.Any())
            return Ok(dtos);
        return NotFound();
    }

}