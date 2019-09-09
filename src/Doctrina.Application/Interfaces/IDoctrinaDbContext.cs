﻿using Doctrina.Domain.Entities;
using Doctrina.Domain.Entities.Documents;
using Doctrina.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Doctrina.Application.Interfaces
{
    public interface IDoctrinaDbContext
    {
        DbSet<VerbEntity> Verbs { get; set; }

        DbSet<ActivityEntity> Activities { get; set; }

        DbSet<AgentEntity> Agents { get; set; }

        DbSet<StatementEntity> Statements { get; set; }

        DbSet<SubStatementEntity> SubStatements { get; set; }

        //DbSet<ContextEntity> StatementContexts { get; set; }

        //DbSet<ContextActivitiesEntity> ContextActivities { get; set; }

        DbSet<AgentProfileEntity> AgentProfiles { get; set; }

        DbSet<ActivityProfileEntity> ActivityProfiles { get; set; }

        DbSet<ActivityStateEntity> ActivityStates { get; set; }
        DbSet<DoctrinaUser> Users { get; set; }
        DbSet<DoctrinaRole> Roles { get; set; }

        //DbSet<AttachmentEntity> Attachments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
