namespace Mosh
{
    internal class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book(){Title=" amr book" , Price=3},
                new Book(){Title=" amr book" , Price=5},
                new Book(){Title="aaaaa" , Price=10},
                new Book(){Title=" bbbb" , Price=15},
                new Book(){Title="ccccc " , Price=20},
                new Book(){Title=" ddddd" , Price=25},
            };
        }
    }
}
