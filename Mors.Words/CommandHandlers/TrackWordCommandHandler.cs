using System;
using System.Collections.Generic;
using System.Linq;
using Mors.Words.Data.Commands;
using Mors.Words.Data.Events;

namespace Mors.Words.CommandHandlers
{
    internal sealed class TrackWordCommandHandler
    {
        public void Execute(TrackWordCommand command, EventPublisher eventPublisher)
        {
            if (string.IsNullOrWhiteSpace(command.Word))
            {
                throw new Exception("Word should not be empty");
            }
            if (command.Contexts
                is not (WordContexts.Meaning
                    or WordContexts.Pronunciation
                    or (WordContexts.Meaning | WordContexts.Pronunciation)))
            {
                throw new Exception("Unsupported word contexts");
            }
            var contexts = ToWordContext(command.Contexts).ToList();
            if (!contexts.Any())
            {
                throw new Exception("At least one word context should be selected");
            }
            foreach (var context in contexts)
            {
                var @event = new WordTrackedEvent(command.Word, context);
                eventPublisher(@event);
            }
        }

        public IEnumerable<WordContext> ToWordContext(WordContexts x)
        {
            if ((x & WordContexts.Meaning) == WordContexts.Meaning)
            {
                yield return WordContext.Meaning;
            }
            if ((x & WordContexts.Pronunciation) == WordContexts.Pronunciation)
            {
                yield return WordContext.Pronunciation;
            }
        }
    }
}
