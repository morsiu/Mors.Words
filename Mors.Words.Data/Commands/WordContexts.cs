using System;
using System.Runtime.Serialization;

namespace Mors.Words.Data.Commands
{
    [Flags]
    [DataContract(Name = "WordContexts", Namespace = "words/commands")]
    public enum WordContexts
    {
        [EnumMember]
        None = 0,

        [EnumMember]
        Meaning = 1,

        [EnumMember]
        Pronunciation = 2,
    }
}
