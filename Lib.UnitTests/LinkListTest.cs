namespace Lib.UnitTests
{
    public class LinkListTest
    {
        [Fact]
        public void LinkListRemove()
        {
            // arrange
          LinkList<int> list = new([1, 2, 3]);

            // act
          list.Remove(2);

          Assert.True(list.Contains(2));
        }
    }
}
