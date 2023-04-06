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
            var entity = await _context.Questionnaires.FirstOrDefaultAsync(q => q.Id == request.Id);

            if (entity is null)
            {
                // TODO: create Not Found Exception instead
                throw new Exception($"Cannot find entity {nameof(Questionnaire)} with Id={request.Id}");
            }

            var questionnaireDto = _mapper.Map<QuestionnaireDto>(entity);

            questionnaireDto.IsClosable = entity.IsClosable(_currentUserService.User);
            questionnaireDto.IsScheduled = entity.IsScheduled(_currentUserService.User);
            questionnaireDto.IsUpdatable = entity.IsUpdatable(_currentUserService.User);

            return questionnaireDto;
        }
    }
}
