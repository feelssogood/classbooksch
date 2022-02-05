using FluentValidation;
using classbook.models.Requests;

namespace classbook.Validators
{
    public class StudentRequestValidator :  AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty();
            RuleFor(s => s.year).NotEmpty().InclusiveBetween(1, 999);
        }
    }
}
