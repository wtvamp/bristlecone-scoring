using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bristlecone.ViewModels.DTO;
using System.Net;
using Bristlecone.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;

namespace Bristlecone.API.Private.Controllers
{
    [Route("v1/application")]
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetApplicationAsync(long id)
        {
            var response = await _applicationService.GetApplicationAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateApplicationAsync([FromBody] ApplicationDTO application)
        {
            if (!ModelState.IsValid || application == null)
                return BadRequest("ApplicationDTO");

            var response = await _applicationService.CreateApplicationAsync(application);

            if (response.ReturnObject != null && response.StatusCode == HttpStatusCode.Created)
                return Created($"{Request.GetDisplayUrl()}/{response.Id}", response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateApplicationAsync(long id, ApplicationDTO application)
        {
            if (!ModelState.IsValid || application == null)
                return BadRequest("ApplicationDTO");

            if (id != application.ApplicationID)
                return BadRequest();


            var response = await _applicationService.UpdateApplicationAsync(application);

            if (response.ReturnObject != null && response.StatusCode == HttpStatusCode.OK)
                return Ok(response.ReturnObject);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound();

            return BadRequest(response.Message);
        }
    }
}
