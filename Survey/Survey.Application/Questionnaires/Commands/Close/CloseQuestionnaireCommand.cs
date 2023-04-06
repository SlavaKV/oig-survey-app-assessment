using Microsoft.EntityFrameworkCore;

namespace Survey.Application.Questionnaires.Commands.Close
{
    public class CloseQuestionnaireCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class CloseQuestionnaireCommandHandler : IRequestHandler<CloseQuestionnaireCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CloseQuestionnaireCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(CloseQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Questionnaires.FirstOrDefaultAsync(q => q.Id == request.Id);

            if (entity == null)
            {
                // TODO: NotFoundException
                throw new Exception($"Cannot find entity {nameof(Questionnaire)} with Id={request.Id}");
            }

            if (entity.IsClosable(_currentUserService.User))
            {
                entity.Close(_currentUserService.User);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
