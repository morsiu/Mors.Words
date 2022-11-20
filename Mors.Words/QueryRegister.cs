using System;

namespace Mors.Words
{
    public delegate void QueryRegister(Type queryType, Func<object, object> queryHandler);
}
