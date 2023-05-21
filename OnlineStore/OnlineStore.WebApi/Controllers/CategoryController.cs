using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Categories.Commands.CreateCategory;
using OnlineStore.Application.Categories.Commands.DeleteCategory;
using OnlineStore.Application.Categories.Commands.UpdateCategory;
using OnlineStore.Application.Categories.Queries.GetCategoryList;

namespace OnlineStore.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CategoryController : BaseController
    {
        /// <summary>
        /// Gets the list of categories
        /// </summary>
        /// <param name="categotyId">Category id</param>
        /// <returns>Returns CategoryListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet()]
        public async Task<ActionResult<CategoryListVm>> GetAll(Guid? categotyId)
        {
            var query = new GetCategoryListQuery { CategoryId = categotyId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the category
        /// </summary>
        /// <param name="createCategoryCommand"></param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var categoryId = await Mediator.Send(createCategoryCommand);
            return Ok(categoryId);
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="updateCategoryCommand"></param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            await Mediator.Send(updateCategoryCommand);
            return NoContent();
        }

        /// <summary>
        /// Deletes the category by id
        /// </summary>
        /// <param name="id">Id of the category (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
