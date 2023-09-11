using ACME.POC3.Invoice.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace ACME.POC3.Invoice
{
    public class myInvoiceOutboxService : ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IDataFilter _dataFilter;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IMasterClientRepository _masterClientRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IObjectMapper _objectMapper;
        private readonly IInvoiceLineRepository _invoiceLineRepository;
        public myInvoiceOutboxService(IGuidGenerator guidGenerator, IDataFilter dataFilter, IUnitOfWorkManager unitOfWorkManager, IMasterClientRepository masterClientRepository, IInvoiceRepository invoiceRepository, IObjectMapper objectMapper, IInvoiceLineRepository invoiceLineRepository)
        {
            _guidGenerator = guidGenerator;
            _dataFilter = dataFilter;
            _unitOfWorkManager = unitOfWorkManager;
            _masterClientRepository = masterClientRepository;
            _invoiceRepository = invoiceRepository;
            _objectMapper = objectMapper;
            _invoiceLineRepository = invoiceLineRepository;
        }

        [UnitOfWork]
        public virtual async Task<InvoiceResult<Invoice>> saveGeneralInvoiceToDb(GeneralInvoiceDto eInvoice)
        {
            var invoice = new Invoice(_guidGenerator.Create());
            InvoiceResult<Invoice> result = new InvoiceResult<Invoice>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                message = "",
                value = invoice
            };
            using (_dataFilter.Disable<IMultiTenant>())
            {
                using (var uow = _unitOfWorkManager.Begin(true, false))
                {
                    #region MasterClient
                    MasterClient masterClient;


                    if (eInvoice.invoice.MasterClientId != Guid.Empty)
                    {
                        masterClient = await _masterClientRepository.FirstOrDefaultAsync(x => x.Id == eInvoice.invoice.MasterClientId);
                    }
                    else if (!eInvoice.MasterClientERPCode.IsNullOrEmpty() && eInvoice.invoice.SourceId != 0)
                    {
                        masterClient = await _masterClientRepository.FirstOrDefaultAsync(x => x.SourceId == eInvoice.invoice.SourceId && x.SourceCode == eInvoice.MasterClientERPCode);
                    }
                    else
                    {
                        masterClient = await _masterClientRepository.FirstOrDefaultAsync(x => x.TCKN_VN == eInvoice.invoice.TCKN_VN);
                    }

                    if (masterClient == null)
                    {
                        masterClient = new MasterClient(_guidGenerator.Create())
                        {
                            Name = eInvoice.invoice.Name,
                            Surname = eInvoice.invoice.Surname,
                            Title = eInvoice.invoice.Title,

                        };
                        await _masterClientRepository.InsertAsync(masterClient);
                    }
                    else
                    {
                        masterClient.Title = eInvoice.invoice.Title;

                        await _masterClientRepository.UpdateAsync(masterClient);
                    }
                    #endregion

                    #region Invoice


                    await _invoiceRepository.InsertAsync(invoice);
                    eInvoice.invoice = _objectMapper.Map<Invoice, InvoiceDto>(invoice);
                    eInvoice.invoice.MasterClientId = masterClient.Id;
                    #endregion

                    #region Invoice Lines
                    
                    List<InvoiceLine> invoiceLineItems = new List<InvoiceLine>();
                    foreach (var item in eInvoice.invoiceLines)
                    {

                        item.MasterClientId = masterClient.Id;
                        item.InvoiceId = invoice.Id;
                        var lineItem = new InvoiceLine(Guid.NewGuid());

                        if (item.Id == Guid.Empty)
                        {
                            _objectMapper.Map<InvoiceLineDto, InvoiceLine>(item, lineItem);
                            var invoiceLine = await _invoiceLineRepository.InsertAsync(lineItem);
                        }
                        else
                        {
                            lineItem = await _invoiceLineRepository.GetAsync(item.Id);
                            _objectMapper.Map<InvoiceLineDto, InvoiceLine>(item, lineItem);
                            var invoiceLine = await _invoiceLineRepository.UpdateAsync(lineItem);
                        }
                    }

                    #endregion

                    result.value = invoice;
                    await uow.CompleteAsync();

                    //Important => I will use other services here, like background job managers. So, invoice have to be saved to db before these services.
                }
            }
            return result;
        }

    }
}
