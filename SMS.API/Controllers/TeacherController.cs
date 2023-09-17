using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.ClientEntity.Response;
using SMS.Entity.Domain;
using SMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.Service.teacher;
using SMS.ClientEntity.Response.Teacher;
using SMS.ClientEntity.Request.Teacher;
using FluentValidation;
using SMS.ClientEntity.Request.Student;

namespace SMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IValidator<TeacherRequest> _validator;
        private readonly IMapper _mapper;

        public TeacherController(IMapper mapper, ITeacherService teacherService, IValidator<TeacherRequest> validator)
        {
            _mapper = mapper;
            _teacherService = teacherService;
            _validator = validator;
        }

        [HttpGet("teachers")]
        public async Task<IActionResult> GetAllTeachers([FromQuery] int page = 1, [FromQuery] int pageSize = 1)
        {
            try
            {
                var listOfTeachers = await _teacherService.GetAllTeacherAsync(page, pageSize);

                return listOfTeachers is not null ? Ok(new Response(true, "Data consumed successfully", "200", "OK", _mapper.Map<List<TeacherResponse>>(listOfTeachers)))
                                                   : NotFound(new Response(true, "There is no data", "200", "OK", new List<Teacher>()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("teachers/{id:int}")]
        public async Task<IActionResult> GetTeacherById([FromRoute] int id)
        {
            try
            {
                var teacher = await _teacherService.GetTeacherByIdAsync(id);

                return teacher is not null ? Ok(new Response(true, "Data consumed successfully", "200", "OK", _mapper.Map<TeacherResponse>(teacher)))
                                          : NotFound(new Response(false, "Item Not Found in Database", "404", "Not Found", null));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("teachers")]
        public async Task<IActionResult> AddTeacher([FromBody] TeacherRequest teacherRequest)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(teacherRequest);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new Response(false, "something wrong in requested object", "400", "BadRequest", validationResult.Errors));
                }


                var teacher = _mapper.Map<Teacher>(teacherRequest);

                var isInserted = await _teacherService.AddTeacherAsync(teacher);

                return isInserted ? Ok(new Response(true, "Insert Item Successful", "200", "OK", teacherRequest))
                                  : BadRequest(new Response(false, "Something wrong with the requested object", "400", "BadRequest", teacherRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("teachers")]
        public async Task<IActionResult> UpdateTeacher(TeacherRequest teacherRequest)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(teacherRequest);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new Response(false, "something wrong in requested object", "400", "BadRequest", validationResult.Errors));
                }

                var teacher = _mapper.Map<Teacher>(teacherRequest);

                var isUpdate = await _teacherService.UpdateTeacherAsync(teacher);

                return isUpdate ? Ok(new Response(true, "Update item Successful", "200", "OK", teacherRequest))
                                : BadRequest(new Response(false, "Item Not Found", "200", "OK", teacherRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("teachers/{id:int}")]
        public async Task<IActionResult> DeleteTeacherAsync([FromRoute] int id)
        {
            var isDelete = await _teacherService.DeleteTeacherAsync(id);

            return isDelete ? Ok(new Response(true, "Delete item Successful", "200", "OK", id))
                            : NotFound(new Response(false, "Item Not Found", "404", "Not Found", id));
        }
    }
}
