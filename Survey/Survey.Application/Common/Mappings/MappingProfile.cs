using Survey.Application.Questionnaires.Queries.GetQuestionnaires;

namespace Survey.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // TODO: 2) Scan AL  Assembly instead
            ApplyMappingForType(typeof(QuestionnaireDto));
        }

        private void ApplyMappingForType(Type type)
        {
            // TODO: 1) Support default interface implementation
            var instance = Activator.CreateInstance(type);
            var mappingMethodName = nameof(IMapFrom<object>.Mapping);
            var methodInfo = type.GetMethod(mappingMethodName);

            if (methodInfo != null)
            {
                methodInfo.Invoke(instance, new object[] { this });
            }
        }
    }
}
