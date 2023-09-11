﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACME.POC3.Invoice.Dtos
{
    public class GeneralInvoiceDto
    {
        //public int InvoiceId { get; set; }
        public string MasterClientERPReference { get; set; }
        public string MasterClientERPCode { get; set; }
        public string InvoiceERPReference { get; set; }
        public InvoiceDto invoice { get; set; }
        public List<InvoiceLineDto> invoiceLines { get; set; }
   
    }
}