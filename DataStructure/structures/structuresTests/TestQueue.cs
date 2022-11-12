using structures;
using NUnit.Framework;

namespace structuresTests
{
    [TestFixture]
    public class TestQueue
    {
        public void IsArrayEqualQueue(int[] arr, structures.Queue<int> queue)
        {
            Assert.AreEqual(arr.Length, queue.Count());

            for (int i = 0; i < queue.Count(); i++)
            {
                Assert.AreEqual(arr[i], queue.Pop());
            }
        }

        [Test]
        public void TestDefaultInit()
        {
            structures.Queue<int> queue = new structures.Queue<int>();

            Assert.AreEqual(0, queue.Count());
        }

        [Test]
        public void TestCopyInit()
        {
            int[] test = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            structures.Queue<int> queue = new structures.Queue<int>(test);

            IsArrayEqualQueue(test, queue);
        }

        [Test]
        public void TestPush()
        {
            int[] test = new[] {0, 1, 2, 3};
            structures.Queue<int> queue = new structures.Queue<int>();

            queue.Push(0);
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);

            IsArrayEqualQueue(test, queue);
        }

        [Test]
        public void TestPop()
        {
            int[] test = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            structures.Queue<int> queue = new structures.Queue<int>(test);
            
            for (int i = 0; i < queue.Count(); i++)
            {
                Assert.AreEqual(test[i], queue.Pop());
            }
        }
    }
}