using Conter.Services.Agents.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conter.Services.Agents.Core.Events
{
    public class AgentMasteredLanguage : IDomainEvent
    {
        public Agent Agent { get; }
        public Language Language { get; }

        public AgentMasteredLanguage(Agent agent, Language language)
        {
            Agent = agent;
            Language = language;
        }
    }
}
