using Mosh;

var books = new BookRepository().GetBooks();

//var lowPrice= books.Where(x => x.Price < 15).OrderByDescending(x=>x.Price);

//var lowPrice = new List<Book>();
//foreach (var book in books)
//{

//    if (book.Price < 20)
//        lowPrice.Add(book);
//}

var book = books.Where(x=>x.Price>20);

foreach (var bookItem in book)
{
    Console.WriteLine(bookItem.Title);
}
