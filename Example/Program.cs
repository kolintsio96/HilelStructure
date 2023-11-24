using Library;
namespace Example
{
    class Program
    {
        private static void Main(string[] args)
        {
            List list = new List();
            list.Add(1);
            list.Insert(0, 2);
            list.Add(3);           
            list.Remove(1);           
            list.RemoveAt(0);           
            list.Contains(3);           
            list.IndexOf(3);
            list.ToArray();
            list.Reverse();

            BinaryTree binaryTree = new BinaryTree();
            binaryTree.Add(100);
            binaryTree.Add(58);
            binaryTree.Add(2);
            binaryTree.Add(12);
            binaryTree.Add(33);
            binaryTree.Add(0);

            binaryTree.Contains(12);
            binaryTree.Contains(14);
            binaryTree.ToArray(); 

            Console.WriteLine(binaryTree.Count);
            Console.WriteLine(binaryTree.Root);

            Console.ReadLine();
        }
    }
}