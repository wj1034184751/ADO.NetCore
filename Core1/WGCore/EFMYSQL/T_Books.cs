using System;
using System.Collections.Generic;
using System.Text;

namespace EFMYSQL
{
    public class T_Books
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long AuthorId { get; set; }

        public T_Author Author { get; set; }
    }
}
