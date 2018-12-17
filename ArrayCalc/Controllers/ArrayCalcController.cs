using ArrayCalc.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ArrayCalc.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayCalcController : ControllerBase
    {
        private IArrayCalcService _calcService;

        public ArrayCalcController(IArrayCalcService service)
        {
            _calcService = service;
        }
        /// <summary>
        /// Reverses product ids received in query string
        /// </summary>
        /// <param name="productIds">Array of product ids to be reversed</param>
        /// <returns>Array of reversed Ids</returns>
        [HttpGet]
        [Route("reverse")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ReverseProducts(int[] productIds)
        {
            if (productIds == null || productIds.Length == 0) return BadRequest("Specify product ids in the query string to reverse");
            try
            {
                _calcService.Reverse(productIds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(productIds);
        }


        /// <summary>
        /// Deletes an element at the specified position from the supplied product ids
        /// </summary>
        /// <param name="position">Position of the element to be deleted (Starting index = 1)</param>
        /// <param name="productIds">Array of product ids</param>
        /// <returns>Array of product ids after deletion of the specified element</returns>
        [HttpGet]
        [Route("deletepart")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePart(int position, int[] productIds)
        {
            if (productIds.Length == 0) return BadRequest("Specify product ids in the query string to reverse");
            if (position < 1 || position > productIds.Length) return BadRequest("The position index is out of range");

            try
            {
                //passing position-1 as for client, index starts from 1 rather than 0
                _calcService.RemoveAt(position - 1, ref productIds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(productIds);
        }

    }
}
