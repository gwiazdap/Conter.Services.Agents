using Conter.Services.Agents.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conter.Services.Agents.Core.Events
{
    public class AgentLeftSystem : IDomainEvent
    {
        public Agent Agent { get; }

        public AgentLeftSystem(Agent agent)
        {
            Agent = agent;
        }
    }
}
