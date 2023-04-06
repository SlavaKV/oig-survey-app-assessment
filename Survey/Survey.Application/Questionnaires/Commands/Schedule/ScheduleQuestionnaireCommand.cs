using Microsoft.EntityFrameworkCore;

namespace Survey.Application.Questionnaires.Commands.Schedule
{
    public class ScheduleQuestionnaireCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class ScheduleQuestionnaireCommandHandler : IRequestHandler<ScheduleQuestionnaireCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public ScheduleQuestionnaireCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(ScheduleQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Questionnaires.FirstOrDefaultAsync(q => q.Id == request.Id);

            if (entity == null)
            {
                // TODO: NotFoundException
                throw new Exception($"Cannot find entity {nameof(Questionnaire)} with Id={request.Id}");
            }

            if (entity.IsScheduled(_currentUserService.User))
            {
                entity.Schedule(_currentUserService.User);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
