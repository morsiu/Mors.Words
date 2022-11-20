using Mors.Words.CommandHandlers;
using Mors.Words.Data.Commands;
using Mors.Words.Data.Events;
using Mors.Words.Data.Queries;
using Mors.Words.QueryHandlers;

namespace Mors.Words
{
    public sealed class Bootstrapper
    {
        public void BootstrapCommands(CommandRegister commandRegister)
        {
            var addPolishGermantTranslationCommandHander = new AddPolishGermanTranslationCommandHandler();
            commandRegister(
                typeof(AddPolishGermanTranslationCommand),
                (command, eventPublisher, idFactory) =>
                addPolishGermantTranslationCommandHander.Execute(
                    (AddPolishGermanTranslationCommand)command,
                    eventPublisher,
                    idFactory));
            var trackWordCommandHandler = new TrackWordCommandHandler();
            commandRegister(
                typeof(TrackWordCommand),
                (x, eventPublisher, _) => trackWordCommandHandler.Execute((TrackWordCommand)x, eventPublisher));
        }

        public void BootstrapQueries(QueryRegister queryRegister, EventRegister eventRegister)
        {
            var wordCountView = new WordCountView();
            eventRegister(typeof(WordTrackedEvent), x => wordCountView.Execute((WordTrackedEvent)x));
            queryRegister(typeof(TrackedWordsQuery), x => wordCountView.Execute((TrackedWordsQuery)x));
        }
    }
}
