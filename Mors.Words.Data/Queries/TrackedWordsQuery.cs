using System.Runtime.Serialization;

namespace Mors.Words.Data.Queries
{
    [DataContract(Name = "TrackedWordsQuery", Namespace = "words/queries")]
    public sealed class TrackedWordsQuery : IQuery<TrackedWord>
    {
    }
}
