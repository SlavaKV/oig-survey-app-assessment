using Survey.Application.Common.Interfaces;

namespace Survey.Application.Questionnaires.Commands.Create
{
    public class UpdateQuestionnaireCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }

    public class UpdateQuestionnaireCommandHandler : IRequestHandler<UpdateQuestionnaireCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateQuestionnaireCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(UpdateQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Questionnaires.FindAsync(request.Id);

            if (entity == null)
            {
                // TODO: NotFoundException
                throw new Exception(nameof(Questionnaire));
            }

            // Only Owner can update
            if (entity.UserId == _currentUserService.UserId)
            {
                entity.Name = request.Name;
                entity.StartDateTime = request.StartDateTime;
                entity.EndDateTime = request.EndDateTime;

                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
