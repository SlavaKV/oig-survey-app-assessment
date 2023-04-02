namespace Survey.Application.Questionnaires.Queries.GetQuestionnaires
{
    public class QuestionnaireDto : IMapFrom<Questionnaire>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string StatusName { get; set; }
        public string NextStatusName { get; set; }
        public bool IsUpdatable { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Questionnaire, QuestionnaireDto>()
                .ForMember(d => d.NextStatusName, opt => opt.MapFrom(s => s.NextStatusName))
                .ForMember(d => d.StatusName, opt => opt.MapFrom(s => s.Status.Name));
        }
    }
}
