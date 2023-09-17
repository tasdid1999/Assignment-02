using FluentValidation;
using SMS.ClientEntity.Request.Course;

namespace SMS.API.Validator
{
    public class CourseValidator : AbstractValidator<CourseRequest>
    {
        public CourseValidator()
        {
            RuleFor(course => course.CourseCode).CommonNameValidation();

            RuleFor(course => course.CourseName).CommonNameValidation();
        }
    }
}
