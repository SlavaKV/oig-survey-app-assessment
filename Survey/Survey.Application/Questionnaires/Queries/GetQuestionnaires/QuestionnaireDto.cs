namespace Survey.Application.Questionnaires.Queries.GetQuestionnaires
{
    public class QuestionnaireDto : IMapFrom<Questionnaire>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string StatusName { get; set; }
        public bool IsClosable { get; set; }
        public bool IsScheduled { get; set; }
        public bool IsUpdatable { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Questionnaire, QuestionnaireDto>()
                .ForMember(d => d.StatusName, opt => opt.MapFrom(s => s.Status.ToString()));
        }
    }
}
