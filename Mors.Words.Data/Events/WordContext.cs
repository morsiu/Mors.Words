using System.Runtime.Serialization;

namespace Mors.Words.Data.Events
{
    [DataContract(Name = "WordContext", Namespace = "words/events")]
    public enum WordContext
    {
        [EnumMember]
        Meaning,

        [EnumMember]
        Pronunciation,
    }
}
