using System.Runtime.Serialization;

namespace Mors.Words.Data.Queries
{
    [DataContract(Name = "TrackedWord", Namespace = "words/queries")]
    public sealed class TrackedWord
    {
        public TrackedWord(WordContext context, int count, string word)
        {
            Context = context;
            Count = count;
            Word = word;
        }

        [DataMember]
        public WordContext Context { get; }

        [DataMember]
        public int Count { get; }

        [DataMember]
        public string Word { get; }
    }
}
