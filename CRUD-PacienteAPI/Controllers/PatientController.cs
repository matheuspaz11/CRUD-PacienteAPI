using AutoMapper;
using CRUD_PacienteAPI.Models.DTOs;
using CRUD_PacienteAPI.Models.Entities;
using CRUD_PacienteAPI.Repository;
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
        private readonly PatientRepository _repository;

        public PatientController(IMapper mapper, PatientService patientService, PatientRepository repository)
        {
            _mapper = mapper;
            _patientService = patientService;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientDTO patientDTO)
        {
            object result;

            try
            {
                _patientService.ValidatePatient(patientDTO);

                Patient patientExists = await _repository.GetPatientByTaxNumber(patientDTO.TaxNumber);

                if (patientExists != null)
                    throw new Exception("TaxNumber já cadastrado na base de dados");

                Patient patient = _mapper.Map<Patient>(patientDTO);

                _repository.Add(patient);

                if (await _repository.SaveChangesAsync())
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
                await _repository.DisposeAsync();

                result = new { Success = false, Error = ex.Message };

                return StatusCode(400, result);
            }
        }
    }
}