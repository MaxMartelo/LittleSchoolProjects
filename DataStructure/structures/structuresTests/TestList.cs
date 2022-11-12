using structures;
using NUnit.Framework;

namespace structuresTests
{
    [TestFixture]
    public class TestList
    {
        
        public void IsArrayEqualList(int[] arr, structures.List<int> list)
        {
            Assert.AreEqual(arr.Length, list.Count());

            for (int i = 0; i < list.Count(); i++)
            {
                Assert.AreEqual(arr[i], list.Get(i));
            }
        }
        
        
        [Test]
        public void TestDefaultInit()
        {
            structures.List<int> list = new structures.List<int>();
            
            Assert.AreEqual(0, list.Count());
        }
        
        
        [Test]
        public void TestCopyInit()
        {
            int[] test = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            structures.List<int> list = new structures.List<int>(test);

            IsArrayEqualList(test, list);
        }
        
        
        [Test]
        public void AddingFirst()
        {
            // Arrange
            int[] arrayTmp = new[] { 0, 1, 2 };
            int[] finalArray = new[] { 5, 0, 1, 2 };
            
            structures.List<int> list = new structures.List<int>(arrayTmp);
            
            // ACT
            list.AddFirst(5);

            // ASSERT
            IsArrayEqualList(finalArray, list);
        }

        
        [Test]
        public void AddingLast()
        {
            // Arrange
            int[] arrayTmp = new[] { 0, 1, 2 };
            int[] finalArray = new[] { 0, 1, 2, 5 };
            
            structures.List<int> list = new structures.List<int>(arrayTmp);
            
            // ACT
            list.AddLast(5);

            // ASSERT
            IsArrayEqualList(finalArray, list);
        }
        
        [Test]
        public void Adding()
        {
            // Arrange
            int[] arrayTmp = new[] { 0, 1, 2 };
            int[] finalArray = new[] { 0, 1, 5, 2 };
            
            structures.List<int> list = new structures.List<int>(arrayTmp);
            
            // ACT
            list.Add(2, 5);

            // ASSERT
            IsArrayEqualList(finalArray, list);
        }
        
        
        [Test]
        public void RmFirst()
        {
            // Arrange
            int[] arrayTmp = new[] { 0, 1, 2 };
            int[] finalArray = new[] { 1, 2 };
            
            structures.List<int> list = new structures.List<int>(arrayTmp);
            
            // ACT
            list.RemoveFirst();

            // ASSERT
            IsArrayEqualList(finalArray, list);
        }
        
        
        [Test]
        public void RmLast()
        {
            // Arrange
            int[] arrayTmp = new[] { 0, 1, 2 };
            int[] finalArray = new[] { 0, 1 };
            
            structures.List<int> list = new structures.List<int>(arrayTmp);
            
            // ACT
            list.RemoveLast();

            // ASSERT
            IsArrayEqualList(finalArray, list);
        }
        
        [Test]
        public void Removing()
        {
            // Arrange
            int[] arrayTmp = new[] { 0, 5, 1, 2 };
            int[] finalArray = new[] { 0, 1, 2 };
            
            structures.List<int> list = new structures.List<int>(arrayTmp);
            
            // ACT
            list.Remove(1);

            // ASSERT
            IsArrayEqualList(finalArray, list);
        }
        
        
        [Test]
        public void Getting()
        {
            // Arrange
            int[] arrayTmp = new[] { 0, 1, 2 };
            int[] finalArray = new[] { 0, 1, 2 };
            
            structures.List<int> list = new structures.List<int>(arrayTmp);
            
            // ACT
            int el = list.Get(2);

            // ASSERT
            Assert.AreEqual(2, el);
        }
    }
}

