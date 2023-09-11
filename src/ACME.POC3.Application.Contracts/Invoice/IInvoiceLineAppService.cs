using System;
using ACME.POC3.Invoice.Dtos;
using Volo.Abp.Application.Services;

namespace ACME.POC3.Invoice;

public interface IInvoiceLineAppService :
    ICrudAppService< 
        InvoiceLineDto, 
        Guid, 
        InvoiceLineGetListInput,
        CreateUpdateInvoiceLineDto,
        CreateUpdateInvoiceLineDto>
{

}