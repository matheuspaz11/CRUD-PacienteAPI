using AutoMapper;
using CRUD_PacienteAPI.Models.DTOs;
using CRUD_PacienteAPI.Models.Entities;

namespace CRUD_PacienteAPI.Helpers
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<PatientDTO, Patient>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();
            CreateMap<UpdatePatientDTO, Patient>().ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember, context) => {
                if (srcMember != null)
                {
                    if (srcMember is Enum && (src.SexualGender == (int)dest.SexualGender))
                        return false;

                    if (srcMember is Enum && (src.Status == (int)dest.Status))
                        return false;

                    return true;
                }

                return false;
            }));
        }
    }
}