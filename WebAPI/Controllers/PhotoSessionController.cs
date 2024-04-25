using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IBaseService<Registration> _RegistrationService;
        private readonly IMapper _mapper;

        public RegistrationController(IBaseService<Registration> RegistrationService, IMapper mapper)
        {
            _RegistrationService = RegistrationService;
            _mapper = mapper;
        }


        [HttpPost(ApiEndpoints.Method.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRegistrationRequest request, CancellationToken token)
        {
            var Registration = _mapper.Map<Registration>(request);

            var response = await _RegistrationService.CreateAsync(Registration, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }
        [HttpGet(ApiEndpoints.Method.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var RegistrationExist = await _RegistrationService.GetAsync(id);

            if (RegistrationExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleRegistrationResponse>(RegistrationExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Method.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var Registration = await _RegistrationService.GetAllAsync(token);

            var response = new GetAllRegistrationResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleRegistrationResponse>>(Registration)
            };

            return Ok(response);
        }


        [HttpPut(ApiEndpoints.Method.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRegistrationRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Registration Registration = _mapper.Map<Registration>(request);

            await _RegistrationService.UpdateAsync(Registration, token);

            var response = _mapper.Map<SingleRegistrationResponse>(Registration);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Method.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _RegistrationService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Registration with ID {id} not found.");
        }

    }
}
