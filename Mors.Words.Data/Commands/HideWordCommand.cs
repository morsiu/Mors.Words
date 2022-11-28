using System.Runtime.Serialization;

namespace Mors.Words.Data.Commands
{
    [DataContract(Name = "HideWordCommand", Namespace = "words/commands")]
    public sealed class HideWordCommand
    {
        [DataMember]
        public string Word { get; set; }

        [DataMember]
        public WordContext Context { get; set; }
    }
}
