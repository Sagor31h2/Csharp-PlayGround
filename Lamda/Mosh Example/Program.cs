using System;

namespace Mosh_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var book=new BookRepository().GetBooks();

            var search = book.FindAll(book => book.Price <=10);

            foreach(var item in search)
            {
                Console.WriteLine(item.Title+" "+ item.Price);
            }
            


        }
    }
}
