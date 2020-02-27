using Conter.Services.Agents.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conter.Services.Agents.Core.Events
{
    public class AgentStartedBreak : IDomainEvent
    {
        public Agent Agent { get; }

        public AgentStartedBreak(Agent agent)
        {
            Agent = agent;
        }
    }
}
