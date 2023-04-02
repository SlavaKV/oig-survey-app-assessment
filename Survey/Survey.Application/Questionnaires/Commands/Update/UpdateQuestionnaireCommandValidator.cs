using FluentValidation;

namespace Survey.Application.Questionnaires.Commands.Create
{
    public class UpdateQuestionnaireCommandValidator : AbstractValidator<UpdateQuestionnaireCommand>
    {
        public UpdateQuestionnaireCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty().MaximumLength(500);
        }
    }
}
