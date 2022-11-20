using System;

namespace Mors.Words
{
    public delegate void EventRegister(Type eventType, Action<object> eventHandler);
}
