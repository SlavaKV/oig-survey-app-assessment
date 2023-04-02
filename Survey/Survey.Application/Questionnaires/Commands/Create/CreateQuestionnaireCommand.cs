namespace Survey.Application.Questionnaires.Commands.Create
{
    public class CreateQuestionnaireCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }

    public class CreateQuestionnaireCommandHandler : IRequestHandler<CreateQuestionnaireCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateQuestionnaireCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            var entity = Questionnaire.Create();

            entity.Name = request.Name;
            entity.StartDateTime = request.StartDateTime;
            entity.EndDateTime = request.EndDateTime;
            entity.UserId = _currentUserService.UserId;

            await _context.Questionnaires.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
