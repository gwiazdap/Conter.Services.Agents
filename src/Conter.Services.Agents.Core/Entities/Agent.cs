using Conter.Services.Agents.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Conter.Services.Agents.Core.Entities
{
    public class Agent : AggregateRoot
    {
        private ISet<Language> _languages = new HashSet<Language>();

        public string Email { get; private set; }
        public string FullName { get; private set; }
        public State State { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public IEnumerable<Language> Languages
        {
            get => _languages;
            set => _languages = new HashSet<Language>(value);
        }

        public Agent(Guid id, string email, string fullName, State state, DateTime createdAt, IEnumerable<Language> languages)
        {
            Id = id;
            Email = email;
            FullName = fullName;
            State = state;
            CreatedAt = createdAt;
            Languages = languages ?? Enumerable.Empty<Language>();
        }

        public void SetOffline()
        {
            if (State == State.Offline)
            {
                return;
            }

            State = State.Offline;
            AddEvent(new AgentLeftSystem(this));
        }

        public void SetIdle()
        {
            if (State == State.Idle)
            {
                return;
            }

            State = State.Idle;
            AddEvent(new AgentBecameIdle(this));
        }

        public void SetAttending()
        {
            if (State == State.Attending)
            {
                return;
            }

            State = State.Attending;
            AddEvent(new AgentStartedAttending(this));
        }

        public void SetOnBreak()
        {
            if (State == State.OnBreak)
            {
                return;
            }

            State = State.OnBreak;
            AddEvent(new AgentStartedBreak(this));
        }

        public void AddLanguage(Language language)
        {
            _languages.Add(language);
            AddEvent(new AgentMasteredLanguage(this, language));
        }
    }
}
