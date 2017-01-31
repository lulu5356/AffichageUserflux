using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfficgaheUserflux
{
    public class jsonHelper
    {
        public string toJson(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public Object toString(string data)
        {
            return JsonConvert.DeserializeObject<Object>(data);
        }
    }
}
