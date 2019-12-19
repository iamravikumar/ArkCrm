using System;
using System.Collections.Generic;
using System.Linq;

namespace ARK.CORE.Common
{
    public class TypeHelper
    {
        public static IEnumerable<Type> GetInstancesOfImplementingTypesOnly<T>()
        {
            var type = typeof(T);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            return types;
        }
    }
}
