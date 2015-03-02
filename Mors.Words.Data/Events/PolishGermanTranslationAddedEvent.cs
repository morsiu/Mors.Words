using System.Runtime.Serialization;

namespace Mors.Words.Data.Events
{
    [DataContract]
    public sealed class PolishGermanTranslationAddedEvent
    {
        public PolishGermanTranslationAddedEvent(string polishWord, string germanWord)
        {
            PolishWord = polishWord;
            GermanWord = germanWord;
        }

        [DataMember]
        public string GermanWord { get; private set; }

        [DataMember]
        public string PolishWord { get; private set; }
    }
}
