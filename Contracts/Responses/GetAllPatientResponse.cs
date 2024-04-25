using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public class GetAllPatientResponse
    {
        public IEnumerable<SinglePatientResponse> Items { get; set; } = Enumerable.Empty<SinglePatientResponse>();
    }
}
