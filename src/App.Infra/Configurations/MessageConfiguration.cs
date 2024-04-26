using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("MESSAGE");

        
            builder.Property(p => p.Id)
                    .HasColumnName("ID");

            builder.Property(p => p.Body)
                    .IsRequired()
                    .HasColumnName("BODY");

            builder.Property(p => p.InsertedDate)
                    .IsRequired()
                    .HasColumnName("DT_INSERTED");

            builder.Property(p => p.UpdatedDate)
                    .IsRequired()
                    .HasColumnName("DT_UPDATED");
        }
    }
}