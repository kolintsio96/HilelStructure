using Interface;
namespace Library
{
    public class Node : INode
    {
        public int Key { get; }
        public INode Left { get; set; }
        public INode Right { get; set; }
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

    public class BinaryTree : IBinaryTree
    {
        public INode? Root { get; private set; }
        public int Count { get; private set; }

        public void Add(int value)
        {
            Root = Add(Root, value);
        }

        private INode Add(INode? root, int value)
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

        public bool Contains(object value)
        {
            return Contains(Root, value);
        }

        private bool Contains(INode? root, object value)
        {
            if (root == null || root.Key == (int)value)
            {
                return root != null;
            }

            if ((int)value < root.Key)
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

        public object[] ToArray()
        {
            object[] result = new object[Count];
            int index = 0;

            void InorderToArray(INode node)
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
