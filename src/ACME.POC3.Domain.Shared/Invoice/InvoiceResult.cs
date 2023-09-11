using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ACME.POC3.Invoice
{
    public class InvoiceResult<T>
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string message { get; set; }
        public string ETTN { get; set; }
        public string xmldata { get; set; }
        public T value { get; set; }
    }
}
