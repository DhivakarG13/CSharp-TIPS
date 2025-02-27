namespace Task6
{
    public record Book(string? Title, string? Author, string? ISBN)
    {
        public void DisplayBook()
        {
            var (Title, Author, ISBN) = this;
            Console.WriteLine($"{Title} {Author} {ISBN}");
        }

        public void DisplayBookWithRecord()
        {
            Console.WriteLine(this);
        }
    }
}