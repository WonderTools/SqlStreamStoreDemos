using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SqlStreamStore;
using SqlStreamStore.Streams;

namespace SqlStreamStoreDemos
{
    public class CreatingStreamTest
    {
        [TestCase(ExpectedVersion.Any, -1)]
        [TestCase(ExpectedVersion.NoStream, -1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(10, 10)]
        public async Task CreatingANewStreamTest(int expectedVersion, int currentVersionForOpenedStream)
        {
            var streamId = "newStreamId1";
            var streamStore = new InMemoryStreamStore();
            var result = await streamStore.AppendToStream(new StreamId(streamId), expectedVersion, new NewStreamMessage[0],
                CancellationToken.None);
            Assert.AreEqual(-1, result.CurrentPosition);
            Assert.AreEqual(currentVersionForOpenedStream, result.CurrentVersion);
        }


        [TestCase(ExpectedVersion.EmptyStream)]
        [TestCase(-4)]
        [TestCase(-30)]
        public void CreatingANonExistingStreamWithVersionAsEmptyStreamThrowsException(int expectedVersion)
        {
            var streamId = "newStreamId1";
            var streamStore = new InMemoryStreamStore();
            Assert.ThrowsAsync< WrongExpectedVersionException> (async () =>
            {
                var result = await streamStore.AppendToStream(new StreamId(streamId), expectedVersion, new NewStreamMessage[0],
                    CancellationToken.None);
            });
        }
    }
}