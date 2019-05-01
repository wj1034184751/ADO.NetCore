using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFMYSQL
{
    public  static class ModelBuilderExtentcs
    {
        private static IEnumerable<Type> GetMappingTypes(this Assembly assembly,Type mappingInterface)
        {
            return assembly.GetTypes().Where(x => !x.GetTypeInfo().IsAbstract && x.GetInterfaces().
            Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
        }

        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder,Assembly assembly)
        {
            var mappingTypes = assembly.GetTypes()
               .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(WGEntityTypeConfig<>));
            //var mappingTypes = assembly.GetMappingTypes(typeof(WGEntityTypeConfig<>));
            foreach (var config in mappingTypes.Select(Activator.CreateInstance).Cast<IEntityTypeConfiguration>())
            {
                config.Map(modelBuilder);
            }
        }
    }
}
