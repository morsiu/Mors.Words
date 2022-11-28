using System.Runtime.Serialization;

namespace Mors.Words.Data.Queries
{
    [DataContract(Name = "TrackedWord", Namespace = "words/queries")]
    public sealed class TrackedWord
    {
        public TrackedWord(WordContext context, int count, bool hidden, string word)
        {
            Context = context;
            Count = count;
            Hidden = hidden;
            Word = word;
        }

        [DataMember]
        public WordContext Context { get; }

        [DataMember]
        public int Count { get; }

        [DataMember]
        public bool Hidden { get; }

        [DataMember]
        public string Word { get; }
    }
}
