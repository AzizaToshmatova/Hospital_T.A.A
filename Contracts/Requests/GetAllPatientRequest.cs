

using Domain.Entities;

namespace Contracts.Requests
{
    public class GetAllPatientRequest
    {
        public IEnumerable<Patient> Items { get; set; } = Enumerable.Empty<Patient>();

    }
}
