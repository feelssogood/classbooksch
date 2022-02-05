using FluentValidation;
using classbook.models.Requests;

namespace classbook.Validators
{
    public class TeacherRequestValidator : AbstractValidator<TeacherRequest>
    {
        public TeacherRequestValidator()
        {
            RuleFor(t => t.Name).NotNull().NotEmpty();

        }
    }
}
