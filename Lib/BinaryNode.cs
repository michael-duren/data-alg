namespace Lib
{
    public class BinaryNode<T>
    {
        public BinaryNode(T value, BinaryNode<T> left, BinaryNode<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public T Value { get; set; }
        public BinaryNode<T> Left { get; set; } = null!;
        public BinaryNode<T> Right { get; set; } = null!;
    }
}
