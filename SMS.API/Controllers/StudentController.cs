using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Entity.Domain;
using SMS.Infrastructure.UnitOfWork;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                var listOfStudent = await _unitOfWork.studentRepository.GetAllAsync();

                return listOfStudent is not null ? Ok(listOfStudent) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody]Student student)
        {
            try
            {
                await _unitOfWork.studentRepository.InsertAsync(student);

                var isAdded = await _unitOfWork.SaveChangesAsync();

                return isAdded ? Ok("Insert Item SuccessFully") : BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}