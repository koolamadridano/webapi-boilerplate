using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_boilerplate.Models
{
    public class Country
    {
        // Primary Key
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
