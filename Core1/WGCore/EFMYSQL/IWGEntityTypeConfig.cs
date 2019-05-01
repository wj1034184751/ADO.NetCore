using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFMYSQL
{
    public interface IEntityTypeConfiguration
    {
        void Map(ModelBuilder builder);
    }

    public interface IEntityTypeConfiguration<T> : IEntityTypeConfiguration where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}
