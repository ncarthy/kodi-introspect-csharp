using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KodiIntrospect
{
    /// <summary>
    /// All the methods in a namespace, organised by method name
    /// </summary>
    public class Group<T>
    {
        private SortedList<string, T> methods_sorted_by_name = new SortedList<string,T>();

        public string NameSpace { get; set; }

        public void Add(string method_name, T m)
        {
            methods_sorted_by_name.Add(method_name, m);
        }

        public IList<string> Items
        {
            get { return methods_sorted_by_name.Keys.ToList(); }
        }

        public T this[string method_name]
        {
            get
            {
                return methods_sorted_by_name[method_name];
            }
            set
            {
                methods_sorted_by_name[method_name] = value;
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in methods_sorted_by_name)
            {
                sb.AppendLine(string.Format("==== {0}.{1} ====", this.NameSpace, item.Key));
                sb.Append(item.Value.ToString());
            }

            return sb.ToString();
        }
    }
}
