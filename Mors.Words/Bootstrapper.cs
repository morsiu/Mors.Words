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
            var hideWordCommandHandler = new HideWordCommandHandler();
            commandRegister(
                typeof(HideWordCommand),
                (x, eventPublisher, _) => hideWordCommandHandler.Execute((HideWordCommand)x, eventPublisher));
        }

        public void BootstrapQueries(QueryRegister queryRegister, EventRegister eventRegister)
        {
            var wordCountView = new WordView();
            eventRegister(typeof(WordTrackedEvent), x => wordCountView.Execute((WordTrackedEvent)x));
            eventRegister(typeof(WordHiddenEvent), x => wordCountView.Execute((WordHiddenEvent)x));
            queryRegister(typeof(TrackedWordsQuery), x => wordCountView.Execute((TrackedWordsQuery)x));
        }
    }
}
