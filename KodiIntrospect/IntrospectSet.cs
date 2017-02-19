using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KodiIntrospect
{
    /// <summary>
    /// All the methods, organsied by namespace
    /// </summary>
    public class IntrospectSet<T>
    {
        private SortedList<string, Group<T>> methods_sorted_by_namespace = new SortedList<string, Group<T>>();

        public IntrospectSet (string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Add(string ns_name, Group<T> mg)
        {
            mg.NameSpace = ns_name;
            methods_sorted_by_namespace.Add(ns_name, mg);
        }

        public Group<T> this[string namespace_name]
        {
            get
            {
                return methods_sorted_by_namespace[namespace_name];
            }
            set
            {
                methods_sorted_by_namespace[namespace_name] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (methods_sorted_by_namespace != null && methods_sorted_by_namespace.Count > 0)
            {
                sb.AppendLine("== " + Name + " ==");

                foreach (var item in methods_sorted_by_namespace)
                {
                    if (item.Value != null && item.Value.Items.Count > 0)
                    {
                        sb.AppendLine(string.Format("=== {0} ===", item.Key));
                        sb.Append(item.Value.ToString()); 
                    }
                } 
            }

            return sb.ToString();
        }
    }
}
