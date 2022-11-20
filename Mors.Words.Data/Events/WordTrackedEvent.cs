using System.Runtime.Serialization;

namespace Mors.Words.Data.Events
{
    [DataContract(Name ="WordTrackedEvent", Namespace ="words/events")]
    public sealed class WordTrackedEvent
    {
        public WordTrackedEvent(string word, WordContext context)
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
