using _Subject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _Subject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjetController : ControllerBase
    {
        private readonly ILogger<SubjetController> _logger;
        private readonly SubjetContext _dbcontext;
        private readonly ISubjet _Subjet;

        public SubjetController(ILogger<SubjetController> logger, SubjetContext dbContext, ISubjet Subjet)
        {
            _logger = logger;
            _dbcontext = dbContext;
            _Subjet = Subjet;

        }

        [HttpGet]
        [Route("CreateDatabase")]
        public IActionResult CreateDatabase()
        {
            try
            {
                _logger.LogInformation("Creando base de datos");
                return Ok(_dbcontext.Database.EnsureCreated());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creando base de datos {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetSubjet")]
        public IActionResult GetEstudent()
        {

            return Ok(_Subjet.GetSubjets());
        }

        [HttpGet]
        [Route("GetSubjetByIdentification/{identification}")]
        public IActionResult GetSubjetByIdentification(int identification)
        {
            return Ok(_Subjet.GetSubjetByIdentification(identification));
        }

        [HttpPost]
        [Route("CreateSubjet")]
        public IActionResult CreateUser(Models.Subjet Subjet)
        {
            return Ok(_Subjet.CreateSubjet(Subjet));
        }

        [HttpDelete]
        [Route("DeleteSubjet/{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                if (_Subjet.DeleteSubjet(id))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No se pudo eliminar correctamente ela asignatura");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error eliminando asignatura {ex.Message.ToString()}");
            }
        }
    }
}