using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public class SingleRegistrationResponse
    {
        public Guid Id { get; set; }
        public string Date { get; set; }

     

      //  public virtual ICollection<Doctor> Doctors { get; set; }

       // public virtual ICollection<Magazine> Magazines { get; set; }
    }
}
