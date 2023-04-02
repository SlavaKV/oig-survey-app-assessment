using FluentValidation;

namespace Survey.Application.Questionnaires.Commands.Create
{
    public class CreateQuestionnaireCommandValidator : AbstractValidator<CreateQuestionnaireCommand>
    {
        public CreateQuestionnaireCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty().MaximumLength(500);
        }
    }
}
