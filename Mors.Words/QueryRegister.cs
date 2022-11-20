using System;

namespace Mors.Words
{
    public delegate void QueryRegister(Type queryType, Action<object> queryHandler);
}
