using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_boilerplate.Models
{
    public class Hotel
    {
        // Primary Key
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }

        [ForeignKey(nameof(Country))]
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
