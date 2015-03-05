using System;
using System.Collections.Generic;
using Mors.Words.CommandHandlers;
using Mors.Words.Data.Commands;
using Mors.Words.Data.Events;
using Mors.Words.Test.Infrastructure;
using Xunit;

namespace Mors.Words.Test
{
    public class AddPolishGermanTranslationTest
    {
        [Fact]
        public void ItIsPossibleToAddTranslation()
        {
            var command = new AddPolishGermanTranslationCommand("krzesło", "der Stuhl");
            var handler = new AddPolishGermanTranslationCommandHandler();
            var events = new EventRecorder();

            handler.Execute(command, events.Record, () => 1);

            events.AssertRecordedOneEvent<PolishGermanTranslationAddedEvent>(
                e =>
                {
                    Assert.Equal("krzesło", e.PolishWord);
                    Assert.Equal("der Stuhl", e.GermanWord);
                    Assert.Equal(1, e.TranslationId);
                });
        }

        [Theory]
        [MemberData("IncorrectWords")]
        public void ItIsNotPossibleToAddTranslationWithIncorrectPolishWord(string polishWord)
        {
            var command = new AddPolishGermanTranslationCommand(polishWord, "der Stuhl");
            var handler = new AddPolishGermanTranslationCommandHandler();
            var events = new EventRecorder();

            Assert.Throws<Exception>(() =>
            {
                handler.Execute(command, events.Record, () => 1);
            });
            events.AssertAllEvents(e => Assert.IsNotType<PolishGermanTranslationAddedEvent>(e));
        }

        [Theory]
        [MemberData("IncorrectWords")]
        public void ItIsNotPossibleToAddTranslationWithIncorrectGermanWord(string germanWord)
        {
            var command = new AddPolishGermanTranslationCommand("krzesło", germanWord);
            var handler = new AddPolishGermanTranslationCommandHandler();
            var events = new EventRecorder();

            Assert.Throws<Exception>(() =>
            {
                handler.Execute(command, events.Record, () => 1);
            });
            events.AssertAllEvents(e => Assert.IsNotType<PolishGermanTranslationAddedEvent>(e));
        }

        public static IEnumerable<IEnumerable<string>> IncorrectWords =
            new[]
            { 
                new[] { default(string) },
                new[] { "" },
                new[] { " " },
                new[] { "	" }
            };
    }
}
