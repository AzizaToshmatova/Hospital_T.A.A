using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public class SingleDoctorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Experience { get; set; }

        public string Specialty { get; set; }
       // public Registration Registrations { get; set; }
        public Guid RegistrationId { get; set; }
    }
}
