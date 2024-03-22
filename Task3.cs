public class Task3
{
    public static int ValueSum(Node node)
    {
        if (node == null)
        {
            return 0;
        }
        return node.value + ValueSum(node.left) + ValueSum(node.right);
    }

    public static int LocateDeepestLevel(Node node)
    {
        if (node == null)
        {
            return 0;
        }
        int leftDepth = LocateDeepestLevel(node.left);
        int rightDepth = LocateDeepestLevel(node.right);

        return Math.Max(leftDepth, rightDepth) + 1;
    }

    public static int NodeCount(Node node)
    {
        if (node == null)
            return 0;

        return 1 + NodeCount(node.left) + NodeCount(node.right);
    }
}

public class Node
{
    public int value { get; set; }
    public required Node left { get; set; }
    public required Node right { get; set; }
}   