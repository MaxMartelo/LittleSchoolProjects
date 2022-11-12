using NUnit.Framework;
using structures;

namespace structuresTests
{
    [TestFixture]
    public class TestStack
    {
        public void IsArrayEqualStack(int[] arr, structures.Stack<int> stack)
        {
            Assert.AreEqual(arr.Length, stack.Count());

            int j = stack.Count() - 1;
            for (int i = 0; i < stack.Count(); i++)
            {
                Assert.AreEqual(arr[j], stack.Pop());
                j--;
            }
        }

        [Test]
        public void TestDefaultInit()
        {
            structures.Stack<int> list = new structures.Stack<int>();

            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestCopyInit()
        {
            int[] test = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            structures.Stack<int> stack = new structures.Stack<int>(test);

            IsArrayEqualStack(test, stack);
        }

        [Test]
        public void TestPush()
        {
            int[] test = new[] {0, 1, 2, 3};
            structures.Stack<int> stack = new structures.Stack<int>();
            
            stack.Push( 0);
            stack.Push( 1);
            stack.Push( 2);
            stack.Push( 3);

            IsArrayEqualStack(test, stack);
        }

        [Test]
        public void TestPop()
        {
            int[] test = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            structures.Stack<int> stack = new structures.Stack<int>(test);
            int j = stack.Count() - 1;
            for (int i = 0; i < stack.Count(); i++)
            {
               Assert.AreEqual(test[j], stack.Pop());
               j--; // I have to add J because when I create my stack, the last element pushed in the 9 and not 0 which mean that 9 is my head and when I pop, I pop 9
            }
        }
    }
}