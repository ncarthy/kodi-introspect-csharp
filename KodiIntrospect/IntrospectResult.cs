using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KodiIntrospect
{
    public class IntrospectResult
    {
        public string description { get; set; }
        public string id { get; set; }
        public Dictionary<string, Method> methods { get; set; }
        public Dictionary<string, IntrospectType> types { get; set; }
        public Dictionary<string, Notification> notifications { get; set; }
        public string version { get; set; }
    }
}
