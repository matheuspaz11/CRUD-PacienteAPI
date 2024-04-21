using AutoMapper;
using CRUD_PacienteAPI.Models.DTOs;
using CRUD_PacienteAPI.Models.Entities;
using CRUD_PacienteAPI.Repository;
using CRUD_PacienteAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static CRUD_PacienteAPI.Models.Enums.Enum;

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

        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatient(PatientDTO patientDTO)
        {
            object result;

            try
            {
                await _patientService.ValidatePatient(patientDTO, _repository);

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

                    return StatusCode(500, result);
                }
            }
            catch(Exception ex) 
            {
                await _repository.DisposeAsync();

                result = new { Success = false, Message = ex.Message };

                return StatusCode(400, result);
            }
        }

        [HttpGet("GetPatient/{name?}")]
        public async Task<IActionResult> GetPatients(string? name)
        {
            object result;

            try
            {
                var patients = await _repository.GetPatients(name);

                if (!patients.Any())
                    throw new Exception("Paciente(s) não encontrado(s) na base de dados");
                else
                {
                    result = new { Success = true, Result = patients };

                    return StatusCode(200, result);
                }
            }
            catch (Exception ex)
            {
                result = new { Success = false, Message = ex.Message };

                return StatusCode(400, result);
            }
        }

        [HttpPatch("Inactivatepatient/{id}")]
        public async Task<IActionResult> Inactivatepatient(int id)
        {
            object result;

            try
            {
                Patient patient = await _repository.GetPatientById(id);

                _patientService.ValidateActivePatient(patient);

                patient.Status = PatientStatus.Inactive;

                _repository.Update(patient);

                if (await _repository.SaveChangesAsync())
                {
                    result = new { Success = true, Message = "Paciente inativado com sucesso!" };

                    return StatusCode(200, result);
                }
                else
                {
                    result = new { Success = false, Message = "Houve um erro no sistema, tente novamente mais tarde." };

                    return StatusCode(500, result);
                }
            }
            catch(Exception ex)
            {
                result = new { Success = false, Message = ex.Message };

                return StatusCode(400, result);
            }
        }

        [HttpPut("UpdatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, UpdatePatientDTO updatedPatientDTO)
        {
            object result;

            try
            {
                Patient patient = await _repository.GetPatientById(id);

                _patientService.PatientExists(patient);

                await _patientService.ValidateUpdatePatient(updatedPatientDTO, _repository);

                Patient updatePatient = _mapper.Map(updatedPatientDTO, patient);

                _repository.Update(updatePatient);

                if (await _repository.SaveChangesAsync())
                {
                    result = new { Success = true, Message = "Paciente atualizado com sucesso!", Object = updatePatient };

                    return StatusCode(200, result);
                }
                else
                {
                    result = new { Success = false, Message = "Houve um erro no sistema, tente novamente mais tarde." };

                    return StatusCode(500, result);
                }
            }
            catch(Exception ex)
            {
                result = new { Success = false, Message = ex.Message };

                return StatusCode(400, result);
            }
        }

        [HttpDelete("DeletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            object result;

            try
            {
                Patient patient = await _repository.GetPatientById(id);

                if (patient == null)
                    throw new Exception("Paciente não encontrado na base de dados");
                else
                    _repository.Delete(patient);

                if (await _repository.SaveChangesAsync())
                {
                    result = new { Success = true, Message = "Paciente deletado com sucesso!" };

                    return StatusCode(200, result);
                }
                else
                {
                    result = new { Success = false, Message = "Houve um erro no sistema, tente novamente mais tarde." };

                    return StatusCode(500, result);
                }
            }
            catch(Exception ex)
            {
                result = new { Success = false, Message = ex.Message };

                return StatusCode(400, result);
            }
        }
    }
}