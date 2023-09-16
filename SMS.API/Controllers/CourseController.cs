using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.ClientEntity.Response;
using SMS.Entity.Domain;
using SMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.Service.course;
using SMS.ClientEntity.Request.Course;
using SMS.ClientEntity.Request.Student;
using SMS.ClientEntity.Response.Course;

namespace SMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(IMapper mapper, ICourseService courseService)
        {
            _mapper = mapper;
            _courseService = courseService;
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetAllCourses([FromQuery] int page = 1, [FromQuery] int pageSize = 1)
        {
            try
            {
                var listOfCourses = await _courseService.GetAllCoursesAsync(page, pageSize);

                return listOfCourses is not null ? Ok(new Response(true, "Data consumed successfully", "200", "OK", _mapper.Map<List<CourseResponse>>(listOfCourses)))
                                                 : NotFound(new Response(true, "There is no data", "200", "OK", new List<Course>()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("courses/{id:int}")]
        public async Task<IActionResult> GetCourseById([FromRoute] int id)
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id);

                return course is not null ? Ok(new Response(true, "Data consumed successfully", "200", "OK", _mapper.Map<CourseResponse>(course)))
                                          : NotFound(new Response(false, "Item Not Found in Database", "404", "Not Found", null));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("courses")]
        public async Task<IActionResult> AddCourse([FromBody] CourseRequest courseRequest)
        {
            try
            {

                var course = _mapper.Map<Course>(courseRequest);
                var isInserted = await _courseService.AddCourseAsync(course);

                return isInserted ? Ok(new Response(true, "Insert Item Successful", "200", "OK", courseRequest))
                                  : BadRequest(new Response(false, "Something wrong with the requested object", "400", "BadRequest", courseRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("courses")]
        public async Task<IActionResult> UpdateCourse(Course courseRequest)
        {
            try
            {
               

                var isUpdate = await _courseService.UpdateCourseAsync(courseRequest);

                return isUpdate ? Ok(new Response(true, "Update item Successful", "200", "OK", courseRequest))
                                : BadRequest(new Response(false, "Item Not Found", "200", "OK", courseRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("courses/{id:int}")]
        public async Task<IActionResult> DeleteCourseAsync([FromRoute] int id)
        {
            var isDelete = await _courseService.DeleteCourseAsync(id);

            return isDelete ? Ok(new Response(true, "Delete item Successful", "200", "OK", id))
                            : NotFound(new Response(false, "Item Not Found", "404", "Not Found", id));
        }
    }
}
