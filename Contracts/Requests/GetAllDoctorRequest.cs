using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests
{
    public class GetAllDoctorRequest
    {
        public IEnumerable<Doctor> Items { get; set; } = Enumerable.Empty<Doctor>();
    }
}
