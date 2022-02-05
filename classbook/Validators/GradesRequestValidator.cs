using FluentValidation;
using classbook.models.Requests;

namespace classbook.Validators
{
    public class GradesRequestValidator : AbstractValidator<GradesRequest>

    {
        public GradesRequestValidator()
        {
            RuleFor(g => g.Mark).InclusiveBetween(2, 6).NotEmpty();
        }
            }
}
