using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SMS.API.Validator;
using SMS.ClientEntity.Request.Student;
using SMS.ClientEntity.Response;
using SMS.ClientEntity.Response.Student;
using SMS.Entity.Domain;
using SMS.Infrastructure.UnitOfWork;
using SMS.Service.student;

namespace SMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IValidator<StudentRequest> _validator;

        public StudentController(IMapper mapper, IStudentService studentService, IValidator<StudentRequest> validator)
        {

            _mapper = mapper;
            _studentService = studentService;
            _validator = validator;
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudent([FromQuery]int page = 1, [FromQuery]int pageSize = 1)
        {
            try
            {
                var listOfStudent = await _studentService.GetAllStudentAsync(page,pageSize);

                return listOfStudent is not null ? Ok(new Response(true,"data consume successful","200","OK",_mapper.Map<List<StudentResponse>>(listOfStudent)))
                                                 : NotFound(new Response(true, "there is no data", "200", "OK", new List<StudentResponse>()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }

        }

        [HttpGet("students/{id:int}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);

                return student is not null ? Ok(new Response(true, "data consume successful", "200", "OK", _mapper.Map<StudentResponse>(student)))
                                           : NotFound(new Response(false, "Item Not Found in Database", "404", "Not Found",null));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        [HttpPost("students")]
        public async Task<IActionResult> AddStudent([FromBody]StudentRequest studentRequest)
        {
            try
            {

                var validationResult = await _validator.ValidateAsync(studentRequest);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new Response(false, "something wrong in requested object", "400", "BadRequest", validationResult.Errors));
                }

                var student = _mapper.Map<Student>(studentRequest);
               
                var isInserted = await _studentService.AddStudentAsync(student);

                return isInserted ? Ok(new Response(true, "Insert Item Succesful", "200", "OK", studentRequest))
                                  : BadRequest(new Response(false, "something wrong in requested object", "400", "BadRequest", studentRequest));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("students")]
        public async Task<IActionResult> UpdateStudent([FromBody]StudentRequest studentRequest)
        {
            try
            {

                var validationResult = await _validator.ValidateAsync(studentRequest);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new Response(false, "something wrong in requested object", "400", "BadRequest", validationResult.Errors));
                }

                var student = _mapper.Map<Student>(studentRequest);

                var isUpdate = await _studentService.UpdateStudentAsync(student);

                return isUpdate ? Ok(new Response(true, "Update item Succesful", "200", "OK", studentRequest))
                                : BadRequest(new Response(false, "item NotFound", "200", "OK", studentRequest));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("student/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            try
            {
                var isDelete = await _studentService.DeleteStudentAsync(id);

                return isDelete ? Ok(new Response(true, "delete item Succesful", "200", "OK", id))
                                : NotFound(new Response(false, "item NotFound", "404", "Not Found", id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("students/active/{id:int}")]

        public async Task<IActionResult> MakeActive([FromRoute]int id)
        {
            try
            {
                var isSucces = await _studentService.ActiveAsync(id);

                return isSucces ? Ok(new Response(true, "activate succesful", "200", "OK", id))
                                : BadRequest(new Response(false, "item NotFound or user already active", "404", "Not Found", id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("students/inactive/{id:int}")]

        public async Task<IActionResult> MakeInActive([FromRoute] int id)
        {
            try
            {
                var isSucces = await _studentService.InActiveAsync(id);

                return isSucces ? Ok(new Response(true, "inactivate succesful", "200", "OK", id))
                                : BadRequest(new Response(false, "item NotFound or user already inactive", "404", "Not Found", id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}