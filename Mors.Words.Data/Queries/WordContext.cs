using System.Runtime.Serialization;

namespace Mors.Words.Data.Queries
{
    [DataContract(Name = "WordContext", Namespace = "words/queries")]
    public enum WordContext
    {
        [EnumMember]
        Meaning,

        [EnumMember]
        Pronunciation,
    }
}
