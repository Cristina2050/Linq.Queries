namespace Linq.Queryes
{
    internal static class Print
    {
        internal static void ListBooks(IEnumerable<Book> books, string title)
        {
            PrintTittle(title);
            Console.WriteLine(Structure, Columns);

            foreach (var book in books)
            {
                Console.WriteLine(Structure, book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
            }
        }

        internal static void ListGroupBooks(IEnumerable<IGrouping<int, Book>> listaLibros, string title)
        {
            PrintTittle(title);

            foreach (var grupo in listaLibros)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nGRUPO: {grupo.Key}");
                Console.ResetColor();
                Console.WriteLine(Structure, Columns);

                foreach (var book in grupo)
                {
                    Console.WriteLine(Structure, book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
                }
            }
        }

        internal static void BooksDictionary(ILookup<char, Book> listaLibros, char letter, string title)
        {
            PrintTittle(title);
            Console.WriteLine(Structure, Columns);

            foreach (var grupo in listaLibros[letter])
            {
                Console.WriteLine(Structure, grupo.Title, grupo.PageCount, grupo.PublishedDate.ToShortDateString());
            }
        }

        internal static void Line(string title, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(title, args);
            Console.ResetColor();
        }

        static void PrintTittle(string title)
        {
            int windowWidth = Console.WindowWidth;
            int textLength = title.Length;
            int spaces = (windowWidth - textLength) / 2;
            Console.SetCursorPosition(spaces, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        internal static string Structure => "  |  {0,-60} | {1,9} | {2,15}  |\n";
        internal static string[] Columns => new[] { "Titulo", "Paginas", "Fecha publicación" };
    }
}
