using System.Runtime.Serialization;

namespace Mors.Words.Data.Events
{
    [DataContract]
    public sealed class PolishGermanTranslationAddedEvent
    {
        public PolishGermanTranslationAddedEvent(object translationId, string polishWord, string germanWord)
        {
            TranslationId = translationId;
            PolishWord = polishWord;
            GermanWord = germanWord;
        }

        [DataMember]
        public object TranslationId { get; private set; }

        [DataMember]
        public string GermanWord { get; private set; }

        [DataMember]
        public string PolishWord { get; private set; }
    }
}
