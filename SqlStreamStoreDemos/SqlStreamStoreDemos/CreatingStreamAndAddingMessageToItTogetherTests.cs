using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SqlStreamStore;
using SqlStreamStore.Streams;

namespace SqlStreamStoreDemos
{
    public class CreatingStreamAndAddingMessageToItTogetherTests
    {
        [TestCase(ExpectedVersion.Any, 2)]
        [TestCase(ExpectedVersion.NoStream, 3)]
        public async Task CreatingStreamAndAddingMessage(int expectedVersion, int numberOfMessages)
        {
            var streamId = "newStreamId1";
            var streamStore = new InMemoryStreamStore();
            var newStreamMessages = new List<NewStreamMessage>();
            for (int i = 0; i < numberOfMessages; i++) newStreamMessages.Add(new NewStreamMessage(Guid.NewGuid(), "type1", "message1", "meta1"));

            var result = await streamStore.AppendToStream(new StreamId(streamId), expectedVersion,
                newStreamMessages.ToArray(), CancellationToken.None);
            Assert.AreEqual(numberOfMessages - 1, result.CurrentPosition);
            Assert.AreEqual(numberOfMessages - 1, result.CurrentVersion);
        }


        [TestCase(ExpectedVersion.EmptyStream)]
        [TestCase(-30)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void CreatingStreamAndAddingMessageSpecifyingWrongVersion(int expectedVersion)
        {
            var streamId = "newStreamId1";
            var streamStore = new InMemoryStreamStore();
            var newStreamMessages = new List<NewStreamMessage>();
            for (int i = 0; i < 1; i++) newStreamMessages.Add(new NewStreamMessage(Guid.NewGuid(), "type1", "message1", "meta1"));

            Assert.ThrowsAsync<WrongExpectedVersionException>(async () =>
            {
                await streamStore.AppendToStream(new StreamId(streamId), expectedVersion,
                    newStreamMessages.ToArray(), CancellationToken.None);
            });
        }
    }
}