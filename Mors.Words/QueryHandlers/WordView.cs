using System;
using System.Collections.Generic;
using System.Linq;
using Mors.Words.Data.Events;
using Mors.Words.Data.Queries;

namespace Mors.Words.QueryHandlers
{
    internal sealed class WordView
    {
        private readonly Dictionary<(string Word, WordContext Context), (int Count, bool Hidden)> _words = new();

        public void Execute(WordHiddenEvent @event)
        {
            var context = ToWordContext(@event.Context);
            var key = (@event.Word, context);
            if (_words.TryGetValue(key, out var word) && !word.Hidden)
            {
                _words[key] = (word.Count, Hidden: true);
            }
        }

        public void Execute(WordTrackedEvent @event)
        {
            var context = ToWordContext(@event.Context);
            var newCount = _words.TryGetValue((@event.Word, context), out var word)
                ? (word.Count + 1, word.Hidden)
                : (1, false);
            _words[(@event.Word, context)] = newCount;

        }

        public IEnumerable<TrackedWord> Execute(TrackedWordsQuery _)
        {
            return _words.Select(x => new TrackedWord(ToWordContext(x.Key.Context), x.Value.Count, x.Value.Hidden, x.Key.Word));

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

        private static WordContext ToWordContext(Data.Events.WordContext x)
        {
            return x switch
            {
                Data.Events.WordContext.Meaning => WordContext.Meaning,
                Data.Events.WordContext.Pronunciation => WordContext.Pronunciation,
                _ => throw new ArgumentOutOfRangeException(nameof(x), x, null),
            };
        }
    }
}
