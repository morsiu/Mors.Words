using System.Runtime.Serialization;

namespace Mors.Words.Data.Commands
{
    [DataContract(Name = "WordContext", Namespace = "words/commands")]
    public enum WordContext
    {
        [EnumMember]
        Meaning = 0,

        [EnumMember]
        Pronunciation = 1,
    }
}
