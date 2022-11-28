using System;
using Mors.Words.Data.Commands;
using Mors.Words.Data.Events;

namespace Mors.Words.CommandHandlers
{
    internal sealed class HideWordCommandHandler
    {
        public void Execute(HideWordCommand command, EventPublisher eventPublisher)
        {
            if (string.IsNullOrWhiteSpace(command.Word))
            {
                throw new Exception("Word should not be empty");
            }
            var context =
                command.Context switch
                {
                    Data.Commands.WordContext.Meaning => Data.Events.WordContext.Meaning,
                    Data.Commands.WordContext.Pronunciation => Data.Events.WordContext.Pronunciation,
                    _ => throw new Exception("Unsupported word context")
                };
            var @event = new WordHiddenEvent(command.Word, context);
            eventPublisher(@event);
        }
    }
}
