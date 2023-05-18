using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Products.Commands.CreateProduct;
using OnlineStore.Application.Products.Commands.DeleteCommand;
using OnlineStore.Application.Products.Commands.UpdateProduct;
using OnlineStore.Application.Products.Queries.GetProductDetails;
using OnlineStore.Application.Products.Queries.GetProductList;

namespace OnlineStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsVm>> Get(Guid id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{categoryId}",Name = "GetAllByCategory")]
        public async Task<ActionResult<ProductDetailsVm>> GetAllByCategory(Guid categoryId)
        {
            var query = new GetProductListQuery
            {
                CategoryId = categoryId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var productId = await Mediator.Send(createProductCommand);
            return Ok(productId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await Mediator.Send(updateProductCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
