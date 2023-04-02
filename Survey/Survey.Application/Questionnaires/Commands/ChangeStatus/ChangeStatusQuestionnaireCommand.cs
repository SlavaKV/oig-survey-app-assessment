using Microsoft.EntityFrameworkCore;

namespace Survey.Application.Questionnaires.Commands.Create
{
    public class ChangeStatusQuestionnaireCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class ChangeStatusQuestionnaireCommandHandler : IRequestHandler<ChangeStatusQuestionnaireCommand>
    {
        private readonly IApplicationDbContext _context;

        public ChangeStatusQuestionnaireCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangeStatusQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Questionnaires.Include(q => q.Status).FirstOrDefaultAsync(q => q.Id == request.Id);

            if (entity == null)
            {
                // TODO: NotFoundException
                throw new Exception(nameof(Questionnaire));
            }

            entity.ChangeStatus();

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
