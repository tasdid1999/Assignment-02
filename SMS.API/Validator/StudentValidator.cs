using FluentValidation;
using SMS.ClientEntity.Request.Student;

namespace SMS.API.Validator
{
    public class StudentValidator : AbstractValidator<StudentRequest>
    {

        public StudentValidator()
        {
            RuleFor(student => student.FirstName)
                                        .CommonNameValidation();

            RuleFor(student => student.LastName)
                                       .CommonNameValidation();

            RuleFor(student => student.FatherName)
                                       .CommonNameValidation();

            RuleFor(student => student.MotherName)
                                       .CommonNameValidation();

            RuleFor(student => student.Address)
                                       .CommonNameValidation();

            RuleFor(student => student.DateOfBirth).NotNull();
        }
    }
}
