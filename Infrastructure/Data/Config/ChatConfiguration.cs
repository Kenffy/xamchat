using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Sender).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Receiver).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Message).IsRequired();
        }
    }
}