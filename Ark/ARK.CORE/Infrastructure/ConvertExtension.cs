using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ARK.CORE.Infrastructure
{
    public static class ConvertExtension
    {
        public static T Convert<T>(this object myobj)
        {
            Type objecttype = myobj.GetType(); // class ın type ını al
            Type target = typeof(T); // hedef class type ını al
            var x = Activator.CreateInstance(target, false); // hedef class yeni instance oluştur

            var d = from source in target.GetMembers().ToList() // hedef class ın propertylerini al 
                    where source.MemberType == MemberTypes.Property
                    select source;

            List<MemberInfo> members = d.Where(memberinfo => d.Select(c => c.Name) // gelen class ile hedef class ın üyelerini eşleştir
               .ToList().Contains(memberinfo.Name)).ToList();

            PropertyInfo propertyinfo;
            foreach (var memberinfo in members) // value setle
            {                
                propertyinfo = typeof(T).GetProperty(memberinfo.Name);

                object asd = myobj.GetType().GetProperty(memberinfo.Name);
                if (asd == null)
                    continue;
                object value = myobj.GetType().GetProperty(memberinfo.Name).GetValue(myobj, null);                
                propertyinfo.SetValue(x, value, null);
            }
            return (T)x;
        }
    }
}
