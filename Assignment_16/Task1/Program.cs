namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            notifier.OnAction += ConsoleWriter;
            notifier.OnAction += ConsoleWriter;
            notifier.NotifyUser("Hello World");
            Console.ReadLine();
        }

        public static void ConsoleWriter(string message)
        {
            Console.WriteLine(message);
        }

    }

    public delegate void Notify(string message);

    public class Notifier
    {
        public event Notify OnAction;

        public void NotifyUser(string message)
        {
            OnAction?.Invoke(message);
        }
    }   
}
