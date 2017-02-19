using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KodiIntrospect
{
    public class IntrospectResponse
    {
        public int id { get; set; }
        public string jsonrpc { get; set; }
        public IntrospectResult result { get; set; }
    }

}
