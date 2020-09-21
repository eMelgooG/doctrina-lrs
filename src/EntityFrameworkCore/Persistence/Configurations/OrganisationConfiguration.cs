﻿using Doctrina.Domain.Entities;
using Doctrina.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Doctrina.Persistence.Configurations
{
    public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder.HasKey(org => org.OrganisationId);

            builder.Property(org => org.OrganisationId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(org => org.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();

            builder.Property(org => org.CreatedAt)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(org => org.Name)
                .HasMaxLength(Constants.MAX_NAME_LENGTH)
                .IsRequired();

            builder.HasMany(org => org.People)
                .WithOne(person => person.Organisation)
                .HasForeignKey(person => person.OrganisationId)
                .IsRequired();

            builder.Property(org => org.Settings)
                .HasConversion<string>(
                org => JsonConvert.SerializeObject(org),
                s => JsonConvert.DeserializeObject<OrganisationSettings>(s)
            );
        }
    }
}
