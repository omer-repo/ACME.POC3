using System;
using ACME.POC3.Invoice.Dtos;
using Volo.Abp.Application.Services;

namespace ACME.POC3.Invoice;

public interface IMasterClientAppService :
    ICrudAppService< 
        MasterClientDto, 
        Guid, 
        MasterClientGetListInput,
        CreateUpdateMasterClientDto,
        CreateUpdateMasterClientDto>
{

}