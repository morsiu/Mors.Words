using System;
using System.Collections.Generic;
using Xunit;

namespace Mors.Words.Test.Infrastructure
{
    internal sealed class EventRecorder
    {
        private readonly List<object> _events = new List<object>();

        public void Record(object @event)
        {
            _events.Add(@event);
        }

        public void AssertRecordedOneEvent<TEvent>(Action<TEvent> eventContentsAssert)
        {
            Assert.Equal(1, _events.Count);
            var @event = _events[0];
            Assert.NotNull(@event);
            Assert.Equal(typeof(TEvent), @event.GetType());
            eventContentsAssert((TEvent)@event);
        }

        public void AssertAllEvents(Action<object> eventContentsAssert)
        {
            foreach (var @event in _events)
            {
                eventContentsAssert(@event);
            }
        }
    }
}
