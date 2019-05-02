using System;
using System.Collections.Generic;
using System.Linq;
using EFMYSQL;
using EntityExtensions;

namespace DAL
{
    public class BooksService : IBooksService, IServiceSupportExten
    {
        public int GetBooksCount()
        {
            using (EFMYSQL.MyDbContext _context = new EFMYSQL.MyDbContext())
            {
                var count = _context.T_Books.Count();
                return count;
            }
        }

        public List<T_Books> GetBooksList()
        {
            using (EFMYSQL.MyDbContext _context = new EFMYSQL.MyDbContext())
            {
                var result = _context.T_Books.ToList();
                return result;
            }
        }
    }
}
