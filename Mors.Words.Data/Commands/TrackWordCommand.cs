using System.Runtime.Serialization;

namespace Mors.Words.Data.Commands
{
    [DataContract(Name ="TrackWordCommand", Namespace = "words/commands")]
    public sealed class TrackWordCommand
    {
        [DataMember]
        public string Word { get; set; }

        [DataMember]
        public WordContexts Contexts { get; set; }
    }
}
