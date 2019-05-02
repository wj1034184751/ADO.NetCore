using EFMYSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IBooksService
    {
        int GetBooksCount();

        List<T_Books> GetBooksList();
    }
}
