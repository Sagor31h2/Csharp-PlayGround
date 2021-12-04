using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosh_Example
{
    public class BookRepository
    {      
            public List<Books> GetBooks()
            {
                return new List<Books>
                {
                    new Books(){Title=" ssss" ,Price=10},
                    new Books(){Title=" aaaa" ,Price=7},
                    new Books(){Title=" ssss" ,Price=12}
                };
            }
        
    }

    public class Books
    {
        public string Title { get; set; }
        public int Price { get; set; }

    }
}
