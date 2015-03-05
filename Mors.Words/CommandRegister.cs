using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mors.Words
{
    public delegate void CommandRegister(Type commandType, Action<object, EventPublisher, IdFactory> commandHandler);
}
