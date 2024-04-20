using AutoMapper;
using CRUD_PacienteAPI.Models.DTOs;
using CRUD_PacienteAPI.Models.Entities;
using CRUD_PacienteAPI.Repository.Interfaces;
using CRUD_PacienteAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_PacienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PatientService _patientService;
        private readonly IBaseRepository _patientRepository;

        public PatientController(IMapper mapper, PatientService patientService, IBaseRepository patientRepository)
        {
            _mapper = mapper;
            _patientService = patientService;
            _patientRepository = patientRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientDTO patientDTO)
        {
            object result;

            try
            {
                _patientService.ValidatePatient(patientDTO);

                Patient patient = _mapper.Map<Patient>(patientDTO);    

                _patientRepository.Add(patient);

                if (await _patientRepository.SaveChangesAsync())
                {
                    result = new { Success = true, Message = "Paciente salvo com sucesso!" };

                    return StatusCode(200, result);
                }
                else
                {
                    result = new { Success = false, Message = "Houve um erro no sistema, tente novamente mais tarde." };

                    return StatusCode(400, result);
                }
            }
            catch(Exception ex) 
            {
                await _patientRepository.DisposeAsync();

                result = new { Success = false, Error = ex.Message };

                return StatusCode(400, result);
            }
        }
    }
}