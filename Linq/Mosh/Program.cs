using Mosh;

var books = new BookRepository().GetBooks();

var lowPrice = new List<Book>();
foreach (var book in books)
{

    if (book.Price < 20)
        lowPrice.Add(book);
}

foreach (var book in lowPrice)
{
    Console.WriteLine(book.Price);
}