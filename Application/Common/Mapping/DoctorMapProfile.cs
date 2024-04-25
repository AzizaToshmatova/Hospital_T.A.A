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
    public class DoctorMapProfile : Profile
    {
        public DoctorMapProfile()
        {
            CreateMap<CreateDoctorRequest, Doctor>();

            CreateMap<Doctor, SingleDoctorResponse>();

            CreateMap<GetAllDoctorRequest, GetAllDoctorResponse>();

            CreateMap<UpdateDoctorRequest, Doctor>();
        }
    }
}
