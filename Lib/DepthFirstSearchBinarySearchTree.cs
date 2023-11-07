namespace Lib
{
    public class DepthFirstSearchBinarySearchTree
    {
        public bool DepthFirstSearch(BinaryNode<int> head, int needle)
        {
            return Search(head, needle);
        }

        private bool Search(BinaryNode<int> current, int needle)
        {
            if (current is null)
                return false;

            if (current.Value == needle)
                return true;

            if (current.Value < needle)
                return Search(current.Right, needle);

            return Search(current.Left, needle);
        }
    }
}
