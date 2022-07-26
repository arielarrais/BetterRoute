using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Application.Dtos
{
    public class RouteDto
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public decimal Value { get; set; }
    }
}
