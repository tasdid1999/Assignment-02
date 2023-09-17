using FluentValidation;
using SMS.ClientEntity.Request.Teacher;

namespace SMS.API.Validator
{
    public class TeacherValidatior : AbstractValidator<TeacherRequest>
    {
        public TeacherValidatior()
        {
            RuleFor(teacher => teacher.FirstName).CommonNameValidation();

            RuleFor(teacher => teacher.LastName).CommonNameValidation();

            RuleFor(teacher => teacher.Designation).CommonNameValidation();

            RuleFor(teacher => teacher.Email).EmailAddress();

            RuleFor(teacher => teacher.PhoneNumber).MinimumLength(11)
                                                   .WithMessage("Minimum length must be 11 digit")
                                                   .MaximumLength(11)
                                                   .WithMessage("Maximum length must be 11 digit")
                                                   .NotEmpty()
                                                   .NotNull();

        }
    }
}
