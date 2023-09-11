using ACME.POC3.Invoice.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace ACME.POC3.Invoice
{
    public class myInvoiceOutboxService
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

                    eInvoice.invoice.TCKN_VN = eInvoice.invoice.TCKN_VN.Trim();
                    eInvoice.invoice.Title = eInvoice.invoice.Title.Trim();


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
                            BuildingName = eInvoice.invoice.BuildingName,
                            TCKN_VN = eInvoice.invoice.TCKN_VN,
                            Name = eInvoice.invoice.Name,
                            BuildingNumber = eInvoice.invoice.BuildingNumber,
                            City = eInvoice.invoice.City,
                            CityId = eInvoice.invoice.CityId,
                            Country = eInvoice.invoice.Country,
                            DoorNumber = eInvoice.invoice.DoorNumber,
                            Email = eInvoice.invoice.Email,
                            Fax = eInvoice.invoice.Fax,
                            Phone = eInvoice.invoice.Phone,
                            PostCode = eInvoice.invoice.PostCode,
                            StreetName = eInvoice.invoice.StreetName,
                            Surname = eInvoice.invoice.Surname,
                            TaxOffice = eInvoice.invoice.TaxOffice,
                            TaxOfficeId = eInvoice.invoice.TaxOfficeId,
                            Title = eInvoice.invoice.Title,
                            Town = eInvoice.invoice.Town,
                            TownId = eInvoice.invoice.TownId,
                            WebAddress = eInvoice.invoice.WebAddress,

                            SourceId = eInvoice.invoice.SourceId,
                            SourceCode = eInvoice.MasterClientERPCode,
                            SourceRefGuid = eInvoice.MasterClientERPReference
                        };
                        await _masterClientRepository.InsertAsync(masterClient);
                    }
                    else
                    {
                        masterClient.BuildingName = eInvoice.invoice.BuildingName;

                        masterClient.BuildingNumber = eInvoice.invoice.BuildingNumber;
                        masterClient.City = eInvoice.invoice.City;
                        masterClient.CityId = eInvoice.invoice.CityId;
                        masterClient.Country = eInvoice.invoice.Country;
                        masterClient.DoorNumber = eInvoice.invoice.DoorNumber;
                        masterClient.Email = eInvoice.invoice.Email;
                        masterClient.Fax = eInvoice.invoice.Fax;
                        masterClient.Phone = eInvoice.invoice.Phone;
                        masterClient.PostCode = eInvoice.invoice.PostCode;
                        masterClient.StreetName = eInvoice.invoice.StreetName;
                        masterClient.TaxOffice = eInvoice.invoice.TaxOffice;
                        masterClient.TaxOfficeId = eInvoice.invoice.TaxOfficeId;
                        masterClient.Title = eInvoice.invoice.Title;
                        masterClient.Town = eInvoice.invoice.Town;
                        masterClient.TownId = eInvoice.invoice.TownId;
                        masterClient.WebAddress = eInvoice.invoice.WebAddress;

                        await _masterClientRepository.UpdateAsync(masterClient);
                    }
                    #endregion

                    #region Invoice
                    bool isNewInvoice = true;

                    if ((eInvoice.invoice.Id != Guid.Empty))
                    {
                        isNewInvoice = false;
                        invoice = await _invoiceRepository.GetAsync(eInvoice.invoice.Id);
                    }
                    else
                    {
                        isNewInvoice = true;
                        invoice = await _invoiceRepository.FirstOrDefaultAsync(x => x.DrawEttn == eInvoice.invoice.DrawEttn);
                    }


                    if (invoice == null)
                    {
                        isNewInvoice = true;

                    }
                    else
                    {
                        isNewInvoice = false;
                    }

                    if (isNewInvoice)
                    {
                        invoice = _objectMapper.Map<InvoiceDto, Invoice>(eInvoice.invoice);
                    }
                    else
                    {
                        _objectMapper.Map<InvoiceDto, Invoice>(eInvoice.invoice, invoice);
                    }


                    if (isNewInvoice)
                    {
                        invoice.MasterClientId = masterClient.Id;

                        invoice.isDraft = true;
                    }
                    invoice.isCancelled = false;
                    invoice.isOutgoing = eInvoice.invoice.isOutgoing;
                    invoice.isEInvoice = eInvoice.invoice.isEInvoice;
                    invoice.ProfileId = eInvoice.invoice.Scenario;
                    invoice.ReceiverPostBoxName = eInvoice.invoice.EInvoicePostCode;
                    invoice.Scenario = eInvoice.invoice.Scenario;
                    invoice.EInvoicePostCode = eInvoice.invoice.EInvoicePostCode;


                    if (isNewInvoice)
                    {
                        await _invoiceRepository.InsertAsync(invoice);
                    }
                    else
                    {
                        await _invoiceRepository.UpdateAsync(invoice);
                    }



                    eInvoice.invoice = _objectMapper.Map<Invoice, InvoiceDto>(invoice);
                    eInvoice.invoice.MasterClientId = masterClient.Id;
                    #endregion

                    #region Invoice Lines
                    decimal SubTotal = 0;
                    decimal TotalWithDiscount = 0;
                    decimal TotalWithVat = 0;
                    decimal VatAmount = 0;



                    SubTotal = Math.Round(SubTotal, 2);
                    TotalWithDiscount = Math.Round(TotalWithDiscount, 2);
                    TotalWithVat = Math.Round(TotalWithVat, 2);
                    VatAmount = Math.Round(VatAmount, 2);


                    var newInvoiceLineList = new List<Guid>();
                    int LineId = 1;
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
