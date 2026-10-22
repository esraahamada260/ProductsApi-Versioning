using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTOs;
using ProductsApi.Models;

namespace ProductsApi.Controllers;

[ApiController]
[ApiVersion(1.0)]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/products")]
public class ProductsController : ControllerBase
{
private static readonly List<Product> Products = new()
{
new Product
{
Id = 1,
Name = "Laptop",
Price = 25000
},
new Product
{
Id = 2,
Name = "Mouse",
Price = 500
}
};


///////////////////////////////////////////////////////////////////////////////////////////
[HttpGet]
[MapToApiVersion(1.0)]
public ActionResult<IEnumerable<ProductV1Dto>> GetProductsV1()
{
    var products = Products.Select(product => new ProductV1Dto
    {
        Id = product.Id,
        Name = product.Name,
        Price = product.Price
    });

    return Ok(products);
}

///////////////////////////////////////////////////////////////////////////////////
[HttpGet]
[MapToApiVersion(2.0)]
public ActionResult<IEnumerable<ProductV2Dto>> GetProductsV2()
{
    var products = Products.Select(product => new ProductV2Dto
    {
        Id = product.Id,
        Name = product.Name,
        Price = product.Price,
        CategoryName = product.Id == 1 ? "Electronics" : "Accessories"
    });

    return Ok(products);
}

}
