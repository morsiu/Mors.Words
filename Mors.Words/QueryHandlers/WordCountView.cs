using System;
using System.Collections.Generic;
using System.Linq;
using Mors.Words.Data.Events;
using Mors.Words.Data.Queries;

namespace Mors.Words.QueryHandlers
{
    internal sealed class WordCountView
    {
        private readonly Dictionary<(string Word, WordContext Context), int> _counts = new();

        public void Execute(WordTrackedEvent @event)
        {
            var context = ToWordContext(@event.Context);
            var newCount = _counts.TryGetValue((@event.Word, context), out var count)
                ? count + 1
                : 1;
            _counts[(@event.Word, context)] = newCount;

            static WordContext ToWordContext(Data.Events.WordContext x)
            {
                return x switch
                {
                    Data.Events.WordContext.Meaning => WordContext.Meaning,
                    Data.Events.WordContext.Pronunciation => WordContext.Pronunciation,
                    _ => throw new ArgumentOutOfRangeException(nameof(x), x, null),
                };
            }
        }

        public IEnumerable<TrackedWord> Execute(TrackedWordsQuery _)
        {
            return _counts.Select(x => new TrackedWord(ToWordContext(x.Key.Context), x.Value, x.Key.Word));

            static Data.Queries.WordContext ToWordContext(WordContext x)
            {
                return x switch
                {
                    WordContext.Meaning => Data.Queries.WordContext.Meaning,
                    WordContext.Pronunciation => Data.Queries.WordContext.Pronunciation,
                    _ => throw new ArgumentOutOfRangeException(nameof(x), x, null),
                };
            }
        }
    }
}
