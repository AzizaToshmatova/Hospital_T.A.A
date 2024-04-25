using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public class GetAllDoctorResponse
    {
        public IEnumerable<SingleDoctorResponse> Items { get; set; } = Enumerable.Empty<SingleDoctorResponse>();
    }
}
