using NUnit.Framework;
using SqlStreamStore;

namespace SqlStreamStoreDemos
{
    public class CreatingInMemoryStreamStoreTest
    {
        [Test]
        public void Test()
        {
            var streamStore = new InMemoryStreamStore();
            
        }
    }
}