using Microsoft.EntityFrameworkCore;

namespace Survey.Application.Questionnaires.Queries.GetQuestionnaires
{
    public class GetQuestionnairesQuery : IRequest<QuestionnaireListDto>
    {
        public string Search { get; set; } = string.Empty;
        public QuestionnaireListOrder OrderIndex { get; set; }
    }

    public class GetQuestionnairesQueryHandler : IRequestHandler<GetQuestionnairesQuery, QuestionnaireListDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetQuestionnairesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QuestionnaireListDto> Handle(GetQuestionnairesQuery request, CancellationToken cancellationToken)
        {
            var result = new QuestionnaireListDto();

            result.OrderItems.Add(new ListOrderItem { Id = (int)QuestionnaireListOrder.None, Title = "" });
            result.OrderItems.Add(new ListOrderItem { Id = (int)QuestionnaireListOrder.StartAsc, Title = "Start" });
            result.OrderItems.Add(new ListOrderItem { Id = (int)QuestionnaireListOrder.StartDesc, Title = "Start DESC" });
            result.OrderItems.Add(new ListOrderItem { Id = (int)QuestionnaireListOrder.EndAsc, Title = "End" });
            result.OrderItems.Add(new ListOrderItem { Id = (int)QuestionnaireListOrder.EndDesc, Title = "End DESC" });

            IQueryable<Questionnaire> query = _context.Questionnaires.Include(q => q.Status);

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(q => q.Name.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase));
            }

            switch (request.OrderIndex)
            {
                case QuestionnaireListOrder.StartAsc: query = query.OrderBy(q => q.StartDateTime); break;
                case QuestionnaireListOrder.StartDesc: query = query.OrderByDescending(q => q.StartDateTime); break;
                case QuestionnaireListOrder.EndAsc: query = query.OrderBy(q => q.EndDateTime); break;
                case QuestionnaireListOrder.EndDesc: query = query.OrderByDescending(q => q.EndDateTime); break;
            }

            result.Questionnaires = await query
                .ProjectTo<QuestionnaireDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }
    }
}
