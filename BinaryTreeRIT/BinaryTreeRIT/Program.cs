public class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
    }
}

public class BinaryTree
{
    public Node Root;

    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node(value);
            return;
        }

        InsertRecursive(Root, value);
    }

    private void InsertRecursive(Node node, int value)
    {
        if (value < node.Value)
        {
            if (node.Left == null)
            {
                node.Left = new Node(value);
            }
            else
            {
                InsertRecursive(node.Left, value);
            }
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = new Node(value);
            }
            else
            {
                InsertRecursive(node.Right, value);
            }
        }
    }
    private void PrintTree(Node node, int level)
    {
        if (node == null)
            return;

        // выводим правый дочерний узел
        PrintTree(node.Right, level + 1);

        for (int i = 0; i < level; i++)
            Console.Write("    ");

        // выводим значение узла
        Console.WriteLine(node.Value);

        // выводим левый дочерний узел
        PrintTree(node.Left, level + 1);
    }

    // метод для печати бинарного дерева
    public void PrintTree()
    {
        PrintTree(Root, 0);
    }
    public void DepthFirstSearch()
    {
        DepthFirstSearchRecursive(Root);
    }

    private void DepthFirstSearchRecursive(Node node)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine(node.Value);

        DepthFirstSearchRecursive(node.Left);
        DepthFirstSearchRecursive(node.Right);
    }

    public void BreadthFirstSearch()
    {
        if (Root == null)
        {
            return;
        }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            Console.WriteLine(current.Value);

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }
            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        tree.Insert(10);
        tree.Insert(7); 
        tree.Insert(4);
        tree.Insert(20);
        tree.Insert(11);
        tree.PrintTree();   


    }
}