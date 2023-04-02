using Microsoft.EntityFrameworkCore;
using Survey.Application.Questionnaires.Queries.GetQuestionnaires;

namespace Survey.Application.Questionnaires.Queries.GetQuestionnaire
{
    public class GetQuestionnaireQuery : IRequest<QuestionnaireDto>
    {
        public int Id { get; set; }
    }

    public class GetQuestionnaireQueryHandler : IRequestHandler<GetQuestionnaireQuery, QuestionnaireDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetQuestionnaireQueryHandler(
            IApplicationDbContext context, 
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<QuestionnaireDto> Handle(GetQuestionnaireQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Questionnaires.Include(q => q.Status).FirstOrDefaultAsync(q => q.Id == request.Id);

            if (entity is null)
            {
                // TODO: create Not Found Exception instead
                throw new Exception(nameof(Questionnaire));
            }

            var questionnaire = _mapper.Map<QuestionnaireDto>(entity);
            questionnaire.IsUpdatable = entity.IsUpdatable(_currentUserService.UserId);

            return questionnaire;
        }
    }
}
