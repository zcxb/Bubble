﻿using LilySimple.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LilySimple.EntityTypeConfigurations
{
    public class PermissionEntityTypeConfiguration :
        EntityTypeConfigurationBase<Permission>,
        IEntityTypeConfiguration<Permission>
    {
        public new void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder.ToTable("permission");

            builder.Property(m => m.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(m => m.Code)
                .HasColumnName("code")
                .HasMaxLength(255);

            builder.Property(m => m.Path)
                .HasColumnName("path")
                .HasMaxLength(255);

            builder.Property(m => m.Type)
                .HasColumnName("type")
                .IsRequired();
        }
    }
}