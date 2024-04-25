using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping
{
    public class RegistrationMapProfile : Profile
    {
        public RegistrationMapProfile()
        {
            CreateMap<CreateRegistrationRequest, Registration>();

            CreateMap<Registration, SingleRegistrationResponse>();

            CreateMap<GetAllRegistrationRequest, GetAllRegistrationResponse>();

            CreateMap<UpdateRegistrationRequest, Registration>();
        }
    }
}
