namespace Lib
{
    public static class BreathFirstSearch
    {
        public static bool Search(BinaryNode<int> head, int needle)
        {
            Queue<BinaryNode<int>> queue = new();
            queue.Enqueue(head);

            while (queue.Count > 0)
            {
                BinaryNode<int> node = queue.Dequeue();

                if (node is null)
                    continue;

                // search
                if (node.Value == needle)
                    return true;

                // keep traversing
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }

            // if we traverse the whole tree and don't find the needle, return false
            return false;
        }
    }
}
