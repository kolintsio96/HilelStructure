namespace Interface
{
    public interface INode
    {
        int Key { get; }
        
        INode Left { get; set; }
        
        INode Right { get; set; }

        string ToString();
    }
    public interface IBinaryTree : ICollection
    {
        INode Root { get; }

        void Add(int data);
    }

}
