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
    public class DoctorController : Controller
    {
        private readonly IBaseService<Doctor> _DoctorService;
        private readonly IMapper _mapper;

        public DoctorController(IBaseService<Doctor> DoctorService, IMapper mapper)
        {
            _DoctorService = DoctorService;
            _mapper = mapper;
        }


        [HttpPost(ApiEndpoints.Method.Create)]
        public async Task<IActionResult> Create([FromBody] CreateDoctorRequest request, CancellationToken token)
        {
            var Doctor = _mapper.Map<Doctor>(request);

            var response = await _DoctorService.CreateAsync(Doctor, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }
        [HttpGet(ApiEndpoints.Method.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var DoctorExist = await _DoctorService.GetAsync(id);

            if (DoctorExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleDoctorResponse>(DoctorExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Method.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var Doctor = await _DoctorService.GetAllAsync(token);

            var response = new GetAllDoctorResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleDoctorResponse>>(Doctor)
            };

            return Ok(response);
        }


        [HttpPut(ApiEndpoints.Method.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDoctorRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Doctor Doctor = _mapper.Map<Doctor>(request);

            await _DoctorService.UpdateAsync(Doctor, token);

            var response = _mapper.Map<SingleDoctorResponse>(Doctor);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Method.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _DoctorService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Doctor with ID {id} not found.");
        }

    }
}
