using System;

namespace Mors.Words
{
    public delegate void CommandRegister(Type commandType, Action<object, EventPublisher, IdFactory> commandHandler);
}
