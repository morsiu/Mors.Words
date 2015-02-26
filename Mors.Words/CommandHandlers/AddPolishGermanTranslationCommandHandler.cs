using System;
using Mors.Words.Data.Commands;
using Mors.Words.Data.Events;

namespace Mors.Words.CommandHandlers
{
    internal sealed class AddPolishGermanTranslationCommandHandler
    {
        public void Execute(AddPolishGermanTranslationCommand command, EventPublisher eventPublisher)
        {
            if (string.IsNullOrWhiteSpace(command.PolishWord)) throw new Exception();
            if (string.IsNullOrWhiteSpace(command.GermanWord)) throw new Exception();
            eventPublisher(new PolishGermanTranslationAddedEvent(command.PolishWord, command.GermanWord));
        }
    }
}
