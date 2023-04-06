using FluentValidation;

namespace Survey.Application.Questionnaires.Commands.Update
{
    public class UpdateQuestionnaireCommandValidator : AbstractValidator<UpdateQuestionnaireCommand>
    {
        public UpdateQuestionnaireCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty().MaximumLength(500);

            RuleFor(q => q.StartDateTime).Must(d => d > DateTime.Now)
                .WithMessage("A questionnaire can only be scheduled for a future date/time");

            RuleFor(q => q.EndDateTime).Must((model, field) => model.StartDateTime.AddHours(1) <= field)
                .WithMessage("The end date and time are at least one hour after the beginning date and time");
        }
    }
}
