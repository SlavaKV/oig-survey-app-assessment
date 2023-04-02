using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Entities;

namespace Survey.Infrastructure.Persistence.Configurations
{
    public class QuestionnaireStatusConfiguration : IEntityTypeConfiguration<QuestionnaireStatus>
    {
        public void Configure(EntityTypeBuilder<QuestionnaireStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.Property(t => t.Name).IsRequired();
        }
    }
}
