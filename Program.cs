
using Linq.Queryes;

var query = new LinqQueries();
var books = new List<Book>();
var book = new Book();

// ALL_BOOKS
books = query.AllBooks().ToList();
Print.ListBooks(books, Titles.ALL_BOOKS);

// BOOKS_PUBLISHED_AFTER_2000
books = query.BooksGreater2000Year().ToList();
Print.ListBooks(books, Titles.BOOKS_PUBLISHED_AFTER_2000);

// BOOKS_MORE_THAN_200_PAGES
books = query.BooksGreaterThanPages().ToList();
Print.ListBooks(books, Titles.BOOKS_MORE_THAN_200_PAGES);

// PHTYON_BOOKS
books = query.PythonBooks().ToList();
Print.ListBooks(books, Titles.PHTYON_BOOKS);

// JAVA_BOOKS
books = query.BooksJavaOrderByTitle().ToList();
Print.ListBooks(books, Titles.JAVA_BOOKS_ORDER_BY);

// ORDER_DESCENDING
books = query.BooksOrderByDescending().ToList();
Print.ListBooks(books, Titles.BOOKS_ORDER_DESCENDING_BY);

// FIRST_THREE_BOOKS
books = query.TakeBooks().ToList();
Print.ListBooks(books, Titles.FIRST_THREE_BOOKS);

// FIRST_THREE_JAVA_BOOKS
books = query.SameTakeBooks().ToList();
Print.ListBooks(books, Titles.FIRST_THREE_JAVA_BOOKS);

// THIRD_AND_FOURTH_BOOK_MORE_400_PAGES
books = query.SkipBooks().ToList();
Print.ListBooks(books, Titles.THIRD_AND_FOURTH_BOOK_MORE_400_PAGES);

// FIRST_THREE_BOOKS_SELECT
books = query.SelectThirdBooks().ToList();
Print.ListBooks(books, Titles.FIRST_THREE_BOOKS_SELECT);

// BOOKS_GROUPED_BY_YAER
Print.ListGroupBooks(query.GroupByBooks(), Titles.BOOKS_GROUPED_BY_YAER);

// BOOKS_GROUPED_BY_FIRST_LETTER
Print.BooksDictionary(query.GroupByBooksByLetter(), 'E', Titles.BOOKS_GROUPED_BY_FIRST_LETTER);

// EXIST_BOOKS_WITH_STATUS_NOT_NULL
Console.WriteLine("\n");
bool booksWithStatus = query.BooksWithStatusDiferentNull();
Print.Line(Titles.EXIST_BOOKS_WITH_STATUS_NOT_NULL, booksWithStatus);

// SOME_BOOK_PUBLISHED_2005
bool anyBooksPiblishedIn2005 = query.AnyBooksPiblishedIn2005();
Print.Line(Titles.SOME_BOOK_PUBLISHED_2005, anyBooksPiblishedIn2005);

// TOTAL_BOOKS_BETWEEN_200_500_PAGES
var totalBooks = query.CountBooks();
Print.Line(Titles.TOTAL_BOOKS_BETWEEN_200_500_PAGES, totalBooks);

// MINOR_PUBLISHED_BOOK_DATE
Print.Line(Titles.MINOR_PUBLISHED_BOOK_DATE, query.MinDateBooks());

// BOOK_WITH_MAX_NUMBER_PAGES
Print.Line(Titles.BOOK_WITH_MAX_NUMBER_PAGES, query.MaxDateBooks());

// BOOK_WITH_MIN_NUMBER_PAGES
book = query.MinDateBook();
Print.Line(Titles.BOOK_WITH_MIN_NUMBER_PAGES, book.Title, book.PublishedDate);

// BOOK_WITH_MAX_NUMBER_PAGES_OBJ
book = query.MaxDateBook();
Print.Line(Titles.BOOK_WITH_MAX_NUMBER_PAGES_OBJ, book.Title, book.PublishedDate.ToShortDateString());

// SUM_TOTAL_PAGES_BOOK
var totalPages = query.SumBookPages();
Print.Line(Titles.SUM_TOTAL_PAGES_BOOK, totalPages);

// BOOKS_PUBLISHED_AFTER_2015
Print.Line(Titles.BOOKS_PUBLISHED_AFTER_2015, query.AggregateBook());

// AVERAGE_CHARACTERS_TITLES_BOOKS
Print.Line(Titles.AVERAGE_CHARACTERS_TITLES_BOOKS, query.AggregateBook());




