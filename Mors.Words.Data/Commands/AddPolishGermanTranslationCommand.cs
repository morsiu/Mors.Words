using System.Runtime.Serialization;

namespace Mors.Words.Data.Commands
{
    [DataContract]
    public sealed class AddPolishGermanTranslationCommand
    {
        public AddPolishGermanTranslationCommand(
            string polishWord,
            string germanWord)
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
