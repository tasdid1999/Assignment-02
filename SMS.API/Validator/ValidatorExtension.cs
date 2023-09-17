using FluentValidation;

namespace SMS.API.Validator
{
    public static class ValidatorExtension
    {
       
            public static IRuleBuilderOptions<T, string> CommonNameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
            {
                return ruleBuilder
                                   .NotEmpty()
                                   .WithMessage("Field is required")
                                   .NotNull()
                                   .WithMessage("Field is required")
                                   .MinimumLength(3)
                                   .WithMessage("Minimum length should be 3")
                                   .MaximumLength(100)
                                   .WithMessage("Maximum length should be 100");
            }
        
    }
}
