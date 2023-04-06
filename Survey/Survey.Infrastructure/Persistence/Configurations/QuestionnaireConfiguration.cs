using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Entities;

namespace Survey.Infrastructure.Persistence.Configurations
{
    public class QuestionnaireConfiguration : IEntityTypeConfiguration<Questionnaire>
    {
        public void Configure(EntityTypeBuilder<Questionnaire> builder)
        {
            builder.Property(t => t.Name).IsRequired().HasMaxLength(500);
            builder.Property(t => t.StartDateTime).IsRequired();
            builder.Property(t => t.EndDateTime).IsRequired();
        }
    }
}
