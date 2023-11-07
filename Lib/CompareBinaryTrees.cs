namespace Lib
{
    public class CompareBinaryTrees
    {
        // a and b are the beginning of the two trees we are comparing
        public static bool Compare(BinaryNode<int?> a, BinaryNode<int?> b)
        {
            // structure check
            if (a is null && b is null) // check to see if structurely they are both null in the same place
                return true;

            // structure check
            if (a is null || b is null) // if just one is null they are not the same structurally return false
                return false;

            // value check
            if (a.Value != b.Value) // if a value is not the same return false
                return false;

            return Compare(a.Left, b.Left) && Compare(a.Right, b.Right); // recurse
        }
    }
}
