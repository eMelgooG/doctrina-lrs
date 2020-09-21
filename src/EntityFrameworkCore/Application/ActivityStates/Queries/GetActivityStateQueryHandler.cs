﻿using AutoMapper;
using Doctrina.Domain.Entities.Documents;
using Doctrina.ExperienceApi.Data.Documents;
using Doctrina.Persistence.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Doctrina.Application.ActivityStates.Queries
{
    public class GetActivityStateQueryHandler : IRequestHandler<GetActivityStateQuery, ActivityStateDocument>
    {
        private readonly IDoctrinaDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetActivityStateQueryHandler(IDoctrinaDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ActivityStateDocument> Handle(GetActivityStateQuery request, CancellationToken cancellationToken)
        {
            string activityHash = request.ActivityId.ComputeHash();

            var query = _context.ActivityStates
                .AsNoTracking()
                .Where(x => x.StateId == request.StateId)
                .Where(x => x.Activity.Hash == activityHash)
                .Where(x => x.Agent.AgentId == request.IFI);

            if (request.RegistrationId.HasValue)
            {
                query.Where(x => x.Registration == request.RegistrationId);
            }

            ActivityStateEntity state = await query.SingleOrDefaultAsync(cancellationToken);

            return _mapper.Map<ActivityStateDocument>(state);
        }
    }
}
