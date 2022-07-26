using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Domain.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public decimal Value { get; set; }
    }
}
