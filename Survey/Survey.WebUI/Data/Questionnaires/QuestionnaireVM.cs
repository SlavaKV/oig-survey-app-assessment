using FluentValidation;

namespace Survey.WebUI.Data.Questionnaires
{
    public class QuestionnaireViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; } = DateTime.Now; // Here should be validation error by default
        public DateTime EndDateTime { get; set; } = DateTime.Now.AddDays(1);
        public string StatusName { get; set; }
        public bool IsClosable { get; set; }
        public bool IsScheduled { get; set; }
        public bool IsUpdatable { get; set; } = true; // Updatable if creating
    }

    public class QuestionnaireViewModelValidator: AbstractValidator<QuestionnaireViewModel>
    {
        public QuestionnaireViewModelValidator()
        {
            RuleFor(q => q.Name).NotEmpty().MaximumLength(500);

            RuleFor(q => q.StartDateTime).Must(d => d > DateTime.Now)
                .WithMessage("A questionnaire can only be scheduled for a future date/time");

            RuleFor(q => q.EndDateTime).Must((model, field) => model.StartDateTime.AddHours(1) <= field)
                .WithMessage("The end date and time are at least one hour after the beginning date and time");
        }
    }
}
