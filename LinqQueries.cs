
using System.Text.Json;

public class LinqQueries
{
    private readonly List<Book> booksCollection = new();

    public LinqQueries()
    {
        using (StreamReader reader = new("Resources/books.json"))
        {
            var json = reader.ReadToEnd();

            var caseSensitive = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            booksCollection = JsonSerializer.Deserialize<List<Book>>(json, caseSensitive) ?? new List<Book>();

        }
    }

    public IEnumerable<Book> AllBooks()
    {
        return booksCollection;
    }

    #region Operadores Básicos

    #region Where

    // EX1:  Libros que fueron publicados después del 2000
    public IEnumerable<Book> BooksGreater2000Year()
    {
        // Usando método de extensión
        return booksCollection.Where(w => w.PublishedDate.Year > 2000);
    }

    public IEnumerable<Book> BooksGreaterThan2000QE()
    {
        // Usando query expresion
        return from book in booksCollection
               where book.PublishedDate.Year > 2000
               select book;
    }

    // EX2:  Libros que tengan mas de 250 páginas y su título contenga action
    public IEnumerable<Book> BooksGreaterThanPages()
    {
        // Usando query expresion
        return from book in booksCollection
               where book.PageCount > 250 && book.Title.Contains("in Action")
               select book;
    }

    #endregion

    #region All - Any

    // All: Una o mas condiciones se cumplan en todos los elementos de la colección
    // All: Una o mas condiciones se cumplan en un solo elemento de la colección

    // EX1: Exite libros que tengan estado diferente de vacío
    public bool BooksWithStatusDiferentNull()
    {
        return booksCollection?.All(w => !string.IsNullOrEmpty(w.Status)) ?? false;
    }

    // EX2: Algún libro que fue publicado en 2005
    public bool AnyBooksPiblishedIn2005()
    {
        return booksCollection?.Any(w => w.PublishedDate.Year == 2005) ?? false;
    }

    #endregion

    #region Contains 

    // Contains: Si un elemento existe dentro de la colección en base a un criterio

    // EX1: Libros que pertenezcan a la categoría de python
    public IEnumerable<Book> PythonBooks()
    {
        return booksCollection?.Where(w => w.Categories.Contains("Python")) ?? new List<Book>();
    }

    #endregion

    #region OrderBy -  OrderByDescending

    // OrderBy: Ordena de forma ascendente 
    // OrderByDescending: Ordena de forma descendente  

    // EX1: Libros que pertenezcan a la categoría de java y ordenar por nombre
    public IEnumerable<Book> BooksJavaOrderByTitle()
    {
        return booksCollection?.Where(w => w.Title.Contains("Java"))?.OrderBy(o => o.Title);
    }

    // EX2: Libros que tengan mas de 450 páginas y ordenar por número de página
    public IEnumerable<Book> BooksOrderByDescending()
    {
        return booksCollection?.Where(w => w.PageCount > 450).OrderByDescending(o => o.PageCount);
    }

    #endregion

    #region Take - Skip

    // Take: Toma la cantidad de elementos de una lista
    // Skip: Omitir cierta cantidad de registros

    // EX1: Seleccionar los tres primero Libros con la fecha de publicación mas reciente y categorizados en java
    public IEnumerable<Book> TakeBooks()
    {
        return booksCollection?
            .Where(w => w.Categories.Contains("Java"))
            .OrderByDescending(o => o.PublishedDate).ToList()
            .Take(3) ?? new List<Book>();
        // Take: Retorna los primeros elementos de la coleccíón
        // TakeLast: Retorna los últimos elementos de la coleccíón
        // TakeWhile: Funciona en base a una condición
    }

    public IEnumerable<Book> SameTakeBooks()
    {
        return booksCollection?
            .Where(w => w.Categories.Contains("Java"))
            .OrderBy(o => o.PublishedDate).ToList()
            .TakeLast(3) ?? new List<Book>();
        // Take: Retorna los primeros elementos de la coleccíón
        // TakeLast: Retorna los últimos elementos de la coleccíón
        // TakeWhile: Funciona en base a una condición
    }

    // EX1: Seleccionar el tercer y cuarto Libros que tengan mas de 400 páginas
    public IEnumerable<Book> SkipBooks()
    {
        return booksCollection?
            .Where(w => w.PageCount > 400)
            .Take(4)
            .Skip(2) ?? new List<Book>();

        // Skip: Omite los primeros elementos de la coleccíón
        // SkipLast: Omite los últimos elementos de la coleccíón
        // SkipWhile: Omite elementos en base a una condición
    }
    #endregion

    #region Seleccion dinamica de datos

    // Retorna los datos que necesitamos. Devuelve los datos necesarios y no toda la colección

    // EX1: Utilizando el operador SELECT seleccionar el título y número de página de los primeros 3 libros 
    // de la colección

    public IEnumerable<Book> SelectThirdBooks()
    {
        return booksCollection
            .Select(s => new Book() { Title = s.Title, PageCount = s.PageCount })
            .Take(3);
    }

    #endregion

    #endregion

    #region Operadores de Agregacion

    #region LongCount & Count

    // Count = Soporta 32bits
    // LongCount = Soporta 64bits
    // Retorna el total de elementos de la coleccion

    // EX1: Retornar el número de libros que tenga entre 200 y 500 paginas
    public int CountBooks()
    {
        return booksCollection
            .Count(s => s.PageCount >= 200 && s.PageCount <= 500);
    }

    #endregion

    #region Min & Max

    // Min = Encuentra el valor minimo de la coleccion
    // Max = Encuentra el valor maximo de la coleccion

    // EX1: Retorna la fecha menor de publicación de la lista de libros
    public DateTime MinDateBooks()
    {
        return booksCollection
            .Min(s => s.PublishedDate);
    }

    // EX2: Retorna el maximo de paginas que tiene un libro
    public int MaxDateBooks()
    {
        return booksCollection
            .Max(s => s.PageCount);
    }

    #endregion

    #region MinBy & MaxBy

    // Min = Encuentra el valor minimo de la coleccion. Retorna un tipo de dato complejo (Todo el objeto de la coleccion)
    // Max = Encuentra el valor maximo de la coleccion. Retorna un tipo de dato complejo (Todo el objeto de la coleccion)

    // EX1: Retorna libro que tenga la menor catidad de paginas y que las paginas sea mayor a cero.
    public Book? MinDateBook()
    {
        return booksCollection
            .Where(w => w.PageCount > 0)
            .MaxBy(s => s.PageCount);
    }

    // EX2: Retorna el libro de la fecha de publicacion mas reciente
    public Book? MaxDateBook()
    {
        return booksCollection
            .MaxBy(s => s.PublishedDate);
    }

    #endregion

    #region Sum & Aggregate

    // Sum = Realiza la operacion de suma.
    // Aggregate = Concatena o acumula valores

    // EX1: Sumar la cantidad de paginas de los libros que tengan entre 0 y 500 paginas
    public int SumBookPages()
    {
        return booksCollection
            .Where(w => w.PageCount <= 500)
            .Sum(s => s.PageCount);

    }

    // EX2: Retorna el titulo de los libros que tienen fecha de publicacion posterior al 2015
    public string AggregateBook()
    {
        return booksCollection
            .Where(w => w.PublishedDate.Year > 2015)
            .Aggregate("", (title, next) =>
            {
                if (title != string.Empty)
                    title += " - " + next.Title;
            
                else
                    title = next.Title;

                return title;
            });
    }

    #endregion

    #region Average

    // Average = Realiza el promedio de una propiedad numerica de la coleccion.

    // EX1: Retornar el promedio de caracteres que tiene los titulos de la coleccion
    public double AverageBookPages()
    {
        return booksCollection
            .Average(w => w.Title.Length);
    }

    #endregion

    #endregion

    #region Operadores de Agrupamiento

    #region GroupBy

    //  EX1: retorna los libros que fueron publicados a partir del 200 agrupados por año
    public IEnumerable<IGrouping<int, Book>> GroupByBooks()
    {
        return booksCollection
            .Where(w=> w.PublishedDate.Year >= 2000)
            .GroupBy(w => w.PublishedDate.Year);
    }

    #endregion

    #region LookUp

    //  EX1: retorna un diccionario que permita consultar los libros de acuerdo a la tra con la que
    // inicia el titulo del libro
    public ILookup<char, Book> GroupByBooksByLetter()
    {
        var groupingBooks = booksCollection
            .ToLookup(p=> p.Title[0], p=> p);

        return groupingBooks;
    }

    #endregion

    #region Join

    // JOIN: intersecar dos colecciones 

    //  EX1: Obtener una coleccion que tenga todos los libros con mas de 500 paginas y otra
    // que contenga los libros publicados despues del 2005. Retornar los libros que coincidan em 
    // ambas colecciones.
    public IEnumerable<Book> JoinBooks()
    {
        var booksWithMore500 = booksCollection.Where(w=> w.PageCount > 500);
        var booksPublish2005 = booksCollection.Where(w => w.PublishedDate.Year > 2005);

        var books = from book500 in booksWithMore500
                    join bookPublish2005 in booksPublish2005 on book500.Title equals bookPublish2005.Title
                    select book500;

        return books;
    }

    #endregion

    #endregion
}