using System.Runtime.Serialization;

namespace Mors.Words.Data.Events
{
    [DataContract(Name ="WordHiddenEvent", Namespace ="words/events")]
    public sealed class WordHiddenEvent
    {
        public WordHiddenEvent(string word, WordContext context)
        {
            Context = context;
            Word = word;
        }

        [DataMember]
        public WordContext Context { get; set; }

        [DataMember]
        public string Word { get; set; }
    }
}
