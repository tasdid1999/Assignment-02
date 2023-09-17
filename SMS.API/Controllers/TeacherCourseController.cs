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
using SMS.Service.teacherCourse;
using SMS.ClientEntity.Request.teacherCourse;
using SMS.ClientEntity.Response.teacherCourse;

namespace SMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TeacherCourseController : ControllerBase
    {
        private readonly ITeacherCourseService _teacherCourseService;
        private readonly IMapper _mapper;

        public TeacherCourseController(IMapper mapper, ITeacherCourseService teacherCourseService)
        {
            _mapper = mapper;
            _teacherCourseService = teacherCourseService;
        }

        [HttpGet("teachercourses")]
        public async Task<IActionResult> GetAllTeacherCourses([FromQuery] int page = 1, [FromQuery] int pageSize = 1)
        {
            try
            {
                var listOfTeacherCourses = await _teacherCourseService.GetAllTeacherCoursesAsync(page, pageSize);

                return listOfTeacherCourses is not null ? Ok(new Response(true, "Data consumed successfully", "200", "OK", _mapper.Map<List<TeacherCourseResponse>>(listOfTeacherCourses)))
                                                        : NotFound(new Response(true, "There is no data", "200", "OK", new List<TeacherCourse>()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("teachercourses/{id:int}")]
        public async Task<IActionResult> GetTeacherCourseById([FromRoute] int id)
        {
            try
            {
                var teacherCourse = await _teacherCourseService.GetTeacherCourseByIdAsync(id);

                return teacherCourse is not null ? Ok(new Response(true, "Data consumed successfully", "200", "OK", _mapper.Map<TeacherCourseResponse>(teacherCourse)))
                                                 : NotFound(new Response(false, "Item Not Found in Database", "404", "Not Found", null));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("teachercourses")]
        public async Task<IActionResult> AddTeacherCourse([FromBody] TeacherCourseRequest teacherCourseRequest)
        {
            try
            {
                var teacherCourse = _mapper.Map<TeacherCourse>(teacherCourseRequest);

                var isInserted = await _teacherCourseService.AddTeacherCourseAsync(teacherCourse);

                return isInserted ? Ok(new Response(true, "Insert Item Successful", "200", "OK", teacherCourseRequest))
                                  : BadRequest(new Response(false, "Something wrong with the requested object", "400", "BadRequest", teacherCourseRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("teachercourses")]
        public async Task<IActionResult> UpdateTeacherCourse(TeacherCourse teacherCourseRequest)
        {
            try
            {
                var isUpdate = await _teacherCourseService.UpdateTeacherCourseAsync(teacherCourseRequest);

                return isUpdate ? Ok(new Response(true, "Update item Successful", "200", "OK", teacherCourseRequest))
                                : BadRequest(new Response(false, "Item Not Found", "200", "OK", teacherCourseRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("teachercourses/{id:int}")]
        public async Task<IActionResult> DeleteTeacherCourseAsync([FromRoute] int id)
        {
            var isDelete = await _teacherCourseService.DeleteTeacherCourseAsync(id);

            return isDelete ? Ok(new Response(true, "Delete item Successful", "200", "OK", id))
                            : NotFound(new Response(false, "Item Not Found", "404", "Not Found", id));
        }
    }
}
