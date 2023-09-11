using ACME.POC3.Invoice;
using ACME.POC3.Invoice.Dtos;
using AutoMapper;

namespace ACME.POC3;

public class POC3ApplicationAutoMapperProfile : Profile
{
    public POC3ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Invoice.Invoice, InvoiceDto>();
        CreateMap<CreateUpdateInvoiceDto, Invoice.Invoice>(MemberList.Source);
        CreateMap<InvoiceLine, InvoiceLineDto>();
        CreateMap<CreateUpdateInvoiceLineDto, InvoiceLine>(MemberList.Source);
        CreateMap<MasterClient, MasterClientDto>();
        CreateMap<CreateUpdateMasterClientDto, MasterClient>(MemberList.Source);
    }
}
