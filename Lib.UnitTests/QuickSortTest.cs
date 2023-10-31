namespace Lib.UnitTests
{
    public class QuickSortTest
    {
        [Fact]
        public void QuickSortSorted()
        {
            // arrange
            int[] arr = [9, 2, 30, 4, 420, 42];

            // act
            arr.QuickSort();

            Assert.Equal([2, 4, 9, 30, 42, 420], arr);
        }
    }
}
