using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFMYSQL
{
    public class PersonConfig : WGEntityTypeConfig<T_Books>
    {
        public override void Map(EntityTypeBuilder<T_Books> builder)
        {
            builder.ToTable("books");
        }
    }

    public class PersontConfig : WGEntityTypeConfig<T_Author>
    {
        public override void Map(EntityTypeBuilder<T_Author> builder)
        {
            builder.ToTable("author");
        }
    }
}
