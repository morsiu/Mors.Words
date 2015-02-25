namespace Mors.Words.Data.Commands
{
    public sealed class AddPolishGermanTranslationCommand
    {
        public AddPolishGermanTranslationCommand(
            string polishWord,
            string germanWord)
        {
            PolishWord = polishWord;
            GermanWord = germanWord;
        }

        public string GermanWord { get; private set; }

        public string PolishWord { get; private set; }
    }
}
