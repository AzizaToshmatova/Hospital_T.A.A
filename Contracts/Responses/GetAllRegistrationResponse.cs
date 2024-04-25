using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public class GetAllRegistrationResponse
    {
        public IEnumerable<SingleRegistrationResponse> Items { get; set; } = Enumerable.Empty<SingleRegistrationResponse>();
    }
}
