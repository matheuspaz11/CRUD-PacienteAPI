using AutoMapper;
using CRUD_PacienteAPI.Models.DTOs;
using CRUD_PacienteAPI.Models.Entities;
using static CRUD_PacienteAPI.Models.Enums.Enum;

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
                    var enumType = srcMember.GetType();

                    if (enumType == typeof(SexualGender) && (src.SexualGender != (int)srcMember))
                        return false;

                    if (enumType == typeof(PatientStatus) && (src.Status != (int)srcMember))
                        return false;

                    return true;
                }

                return false;
            }));
        }
    }
}