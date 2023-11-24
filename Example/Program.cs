namespace Example
{
    class Program
    {
        private static void Main(string[] args)
        {
            Library.List list = new Library.List();
            list.Add(1);
            list.Insert(0, 2);
            list.Add(3);           
            list.Remove(1);           
            list.RemoveAt(0);           
            list.Contains(3);           
            list.IndexOf(3);
            list.ToArray();
            list.Reverse();
            
            Console.ReadLine();
        }
    }
}