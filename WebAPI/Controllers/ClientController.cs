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
    public class PatientController : Controller
    {
        private readonly IBaseService<Patient> _clientService;
        private readonly IMapper _mapper;

        public PatientController( IBaseService<Patient> clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }


        [HttpPost(ApiEndpoints.Method.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePatientRequest request, CancellationToken token)
        {
            var client = _mapper.Map<Patient>(request);

            var response = await _clientService.CreateAsync(client, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }
        [HttpGet(ApiEndpoints.Method.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var clientExist = await _clientService.GetAsync(id);

            if (clientExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SinglePatientResponse>(clientExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Method.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var client = await _clientService.GetAllAsync(token);

            var response = new GetAllPatientResponse()
            {
                Items = _mapper.Map<IEnumerable<SinglePatientResponse>>(client)
            };

            return Ok(response);
        }


        [HttpPut(ApiEndpoints.Method.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePatientRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Patient client = _mapper.Map<Patient>(request);

            await _clientService.UpdateAsync(client, token);

            var response = _mapper.Map<SinglePatientResponse>(client);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Method.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _clientService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"client with ID {id} not found.");
        }

    }
}
