namespace Library
{
    public class Node
    {
        public int Key;
        public Node Left { get; set; }
        public Node Right { get; set; }
        public override string ToString()
        {
            return Key.ToString();
        }
        public Node(int value)
        {
            Key = value;
            Left = Right = null;
        }
    }

    public struct BinaryTree
    {
        public Node Root { get; private set; }
        public int Count { get; private set; }

        public void Add(int value)
        {
            Root = Add(Root, value);
        }

        private Node Add(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
                Count++;
                return root;
            }

            if (value < root.Key)
            {
                root.Left = Add(root.Left, value);
            }
            else if (value > root.Key)
            {
                root.Right = Add(root.Right, value);
            }

            return root;
        }

        public bool Contains(int value)
        {
            return Contains(Root, value);
        }

        private bool Contains(Node root, int value)
        {
            if (root == null || root.Key == value)
            {
                return root != null;
            }

            if (value < root.Key)
            {
                return Contains(root.Left, value);
            }
            else
            {
                return Contains(root.Right, value);
            }
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public int[] ToArray()
        {
            int[] result = new int[Count];
            int index = 0;

            void InorderToArray(Node node)
            {
                if (node != null)
                {
                    InorderToArray(node.Left);
                    result[index++] = node.Key;
                    InorderToArray(node.Right);
                }
            }

            InorderToArray(Root);
            return result;
        }
    }
}
