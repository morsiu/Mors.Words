using Mors.Words.CommandHandlers;
using Mors.Words.Data.Commands;

namespace Mors.Words
{
    public sealed class Bootstrapper
    {
        public void BootstrapCommands(CommandRegister commandRegister)
        {
            var commandHandler = new AddPolishGermanTranslationCommandHandler();
            commandRegister(
                typeof(AddPolishGermanTranslationCommand),
                (command, eventPublisher, idFactory) => commandHandler.Execute((AddPolishGermanTranslationCommand)command, eventPublisher, idFactory));
        }
    }
}
