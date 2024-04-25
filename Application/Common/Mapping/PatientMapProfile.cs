using AutoMapper;
using Domain.Entities;
using Contracts.Requests;
using Contracts.Responses;

namespace Application.Common.Mapping
{
    public class PatientMapProfile : Profile
    {
        public PatientMapProfile()
        {
            CreateMap<CreatePatientRequest, Patient>();

            CreateMap<Patient, SinglePatientResponse>();

            CreateMap<GetAllPatientRequest, GetAllPatientResponse>();

            CreateMap<UpdatePatientRequest, Patient>();
        }
    }
}
