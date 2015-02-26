namespace Mors.Words.Data.Events
{
    public sealed class PolishGermanTranslationAddedEvent
    {
        public PolishGermanTranslationAddedEvent(string polishWord, string germanWord)
        {
            PolishWord = polishWord;
            GermanWord = germanWord;
        }

        public string GermanWord { get; private set; }

        public string PolishWord { get; private set; }
    }
}
