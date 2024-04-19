using CRUD_PacienteAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_PacienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        public PatientController() { }

        public async Task<IActionResult> CreatePatient(PatientDTO patientDTO)
        {
            return Ok();
        }
    }
}
