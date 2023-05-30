using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Products.Commands.CreateProduct;
using OnlineStore.Application.Products.Commands.DeleteCommand;
using OnlineStore.Application.Products.Commands.UpdateProduct;
using OnlineStore.Application.Products.Queries.GetProductDetails;
using OnlineStore.Application.Products.Queries.GetProductList;

namespace OnlineStore.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ProductController : BaseController
    {
        /// <summary>
        /// Get product information
        /// </summary>
        /// <param name="id">Product id (guid)</param>
        /// <returns>Returns ProductDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDetailsVm>> Get(Guid id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of products by category id
        /// </summary>
        /// <param name="categotyId">Category id</param>
        /// <returns>Returns ProductListVm</returns>
        /// <response code="200">Success</response>
        //[HttpGet("{categotyId}")]
        //public async Task<ActionResult<ProductListVm>> GetAllByCategory(Guid categotyId)
        //{
        //    var query = new GetProductListQuery { CategoryId = categotyId };
        //    var vm = await Mediator.Send(query);
        //    return Ok(vm);
        //}

        /// <summary>
        /// Creates the product
        /// </summary>
        /// <param name="createProductCommand"></param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var productId = await Mediator.Send(createProductCommand);
            return Ok(productId);
        }

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="updateProductCommand"></param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await Mediator.Send(updateProductCommand);
            return NoContent();
        }

        /// <summary>
        /// Deletes the product by id
        /// </summary>
        /// <param name="id">Id of the product (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
