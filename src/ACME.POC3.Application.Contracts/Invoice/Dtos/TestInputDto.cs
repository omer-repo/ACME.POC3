using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.POC3.Invoice.Dtos
{
    public class TestInputDto
    {
        public int Number { get; set; }
        public int? NumberOptional { get; set; }
        public string Name { get; set; }
    }
}
