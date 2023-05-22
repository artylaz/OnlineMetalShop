using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Characteristics.Commands.CreateCharacteristic;
using OnlineStore.Application.Characteristics.Commands.DeleteCharacteristic;
using OnlineStore.Application.Characteristics.Commands.UpdateCharacteristic;

namespace OnlineStore.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CharacteristicController : BaseController
    {
        /// <summary>
        /// Creates the characteristic for а product
        /// </summary>
        /// <param name="createCharacteristicCommand"></param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] 
        CreateCharacteristicCommand createCharacteristicCommand)
        {
            var characteristicId = await Mediator.Send(createCharacteristicCommand);
            return Ok(characteristicId);
        }

        /// <summary>
        /// Updates the characteristic
        /// </summary>
        /// <param name="updateCharacteristicCommand"></param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] 
        UpdateCharacteristicCommand updateCharacteristicCommand)
        {
            await Mediator.Send(updateCharacteristicCommand);
            return NoContent();
        }

        /// <summary>
        /// Deletes the characteristic by id
        /// </summary>
        /// <param name="id">Id of the category (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            var command = new DeleteCharacteristicCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
