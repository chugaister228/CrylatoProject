﻿using Comments.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Comments.DAL.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.ID)
                .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.CommentTheme)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(c => c.CommentText)
                   .HasMaxLength(500)
                   .IsRequired(true);

            builder.Property(c => c.CommentPostDate)
                .IsRequired(true)
                .HasDefaultValue(DateTime.Now);

            builder.HasOne(c => c.Feedback)
                .WithMany(f => f.Comments)
                .HasForeignKey(c => c.CommentFeedbackId);
        }
    }
}
