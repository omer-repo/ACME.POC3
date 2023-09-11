using System;
using System.Linq;
using System.Threading.Tasks;
using ACME.POC3.Permissions;
using ACME.POC3.Invoice.Dtos;
using Volo.Abp.Application.Services;
namespace ACME.POC3.Invoice;


public class InvoiceAppService : CrudAppService<Invoice, InvoiceDto, Guid, InvoiceGetListInput, CreateUpdateInvoiceDto, CreateUpdateInvoiceDto>,
    IInvoiceAppService
{
    protected override string GetPolicyName { get; set; } = POC3Permissions.Invoice.Default;
    protected override string GetListPolicyName { get; set; } = POC3Permissions.Invoice.Default;
    protected override string CreatePolicyName { get; set; } = POC3Permissions.Invoice.Create;
    protected override string UpdatePolicyName { get; set; } = POC3Permissions.Invoice.Update;
    protected override string DeletePolicyName { get; set; } = POC3Permissions.Invoice.Delete;

    private readonly IInvoiceRepository _repository;
    private readonly myInvoiceOutboxService myInvoiceOutboxService;

    public InvoiceAppService(IInvoiceRepository repository, myInvoiceOutboxService myInvoiceOutboxService) : base(repository)
    {
        _repository = repository;
        this.myInvoiceOutboxService = myInvoiceOutboxService;
    }

    protected override async Task<IQueryable<Invoice>> CreateFilteredQueryAsync(InvoiceGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Scenario.IsNullOrWhiteSpace(), x => x.Scenario.Contains(input.Scenario))
            .WhereIf(!input.EInvoicePostCode.IsNullOrWhiteSpace(), x => x.EInvoicePostCode.Contains(input.EInvoicePostCode))
            .WhereIf(!input.TesisatNo.IsNullOrWhiteSpace(), x => x.TesisatNo.Contains(input.TesisatNo))
            .WhereIf(!input.SalesType.IsNullOrWhiteSpace(), x => x.SalesType.Contains(input.SalesType))
            .WhereIf(input.SalesTypeId != null, x => x.SalesTypeId == input.SalesTypeId)
            .WhereIf(!input.SendingType.IsNullOrWhiteSpace(), x => x.SendingType.Contains(input.SendingType))
            .WhereIf(!input.WebUrl.IsNullOrWhiteSpace(), x => x.WebUrl.Contains(input.WebUrl))
            .WhereIf(input.SendingDate != null, x => x.SendingDate == input.SendingDate)
            .WhereIf(!input.ShippingPartyName.IsNullOrWhiteSpace(), x => x.ShippingPartyName.Contains(input.ShippingPartyName))
            .WhereIf(!input.ShippingVKN.IsNullOrWhiteSpace(), x => x.ShippingVKN.Contains(input.ShippingVKN))
            .WhereIf(input.PaymentDate != null, x => x.PaymentDate == input.PaymentDate)
            .WhereIf(!input.PaymentTypeCode.IsNullOrWhiteSpace(), x => x.PaymentTypeCode.Contains(input.PaymentTypeCode))
            .WhereIf(!input.InvoiceType.IsNullOrWhiteSpace(), x => x.InvoiceType.Contains(input.InvoiceType))
            .WhereIf(!input.InvoiceNumber.IsNullOrWhiteSpace(), x => x.InvoiceNumber.Contains(input.InvoiceNumber))
            .WhereIf(!input.DocumentTrackNumber.IsNullOrWhiteSpace(), x => x.DocumentTrackNumber.Contains(input.DocumentTrackNumber))
            .WhereIf(!input.TCKN_VN.IsNullOrWhiteSpace(), x => x.TCKN_VN.Contains(input.TCKN_VN))
            .WhereIf(!input.TaxOffice.IsNullOrWhiteSpace(), x => x.TaxOffice.Contains(input.TaxOffice))
            .WhereIf(input.TaxOfficeId != null, x => x.TaxOfficeId == input.TaxOfficeId)
            .WhereIf(!input.Country.IsNullOrWhiteSpace(), x => x.Country.Contains(input.Country))
            .WhereIf(input.CountryId != null, x => x.CountryId == input.CountryId)
            .WhereIf(!input.City.IsNullOrWhiteSpace(), x => x.City.Contains(input.City))
            .WhereIf(input.CityId != null, x => x.CityId == input.CityId)
            .WhereIf(!input.Town.IsNullOrWhiteSpace(), x => x.Town.Contains(input.Town))
            .WhereIf(input.TownId != null, x => x.TownId == input.TownId)
            .WhereIf(!input.BuildingName.IsNullOrWhiteSpace(), x => x.BuildingName.Contains(input.BuildingName))
            .WhereIf(!input.BuildingNumber.IsNullOrWhiteSpace(), x => x.BuildingNumber.Contains(input.BuildingNumber))
            .WhereIf(!input.DoorNumber.IsNullOrWhiteSpace(), x => x.DoorNumber.Contains(input.DoorNumber))
            .WhereIf(!input.PostCode.IsNullOrWhiteSpace(), x => x.PostCode.Contains(input.PostCode))
            .WhereIf(!input.StreetName.IsNullOrWhiteSpace(), x => x.StreetName.Contains(input.StreetName))
            .WhereIf(!input.Email.IsNullOrWhiteSpace(), x => x.Email.Contains(input.Email))
            .WhereIf(!input.Phone.IsNullOrWhiteSpace(), x => x.Phone.Contains(input.Phone))
            .WhereIf(!input.Fax.IsNullOrWhiteSpace(), x => x.Fax.Contains(input.Fax))
            .WhereIf(!input.WebAddress.IsNullOrWhiteSpace(), x => x.WebAddress.Contains(input.WebAddress))
            .WhereIf(input.InvoiceDate != null, x => x.InvoiceDate == input.InvoiceDate)
            .WhereIf(input.SendDate != null, x => x.SendDate == input.SendDate)
            .WhereIf(input.TemplateId != null, x => x.TemplateId == input.TemplateId)
            .WhereIf(!input.TemplateCode.IsNullOrWhiteSpace(), x => x.TemplateCode.Contains(input.TemplateCode))
            .WhereIf(!input.OrderNumber.IsNullOrWhiteSpace(), x => x.OrderNumber.Contains(input.OrderNumber))
            .WhereIf(input.OrderDate != null, x => x.OrderDate == input.OrderDate)
            .WhereIf(!input.DispatchNumber.IsNullOrWhiteSpace(), x => x.DispatchNumber.Contains(input.DispatchNumber))
            .WhereIf(input.DispatchDate != null, x => x.DispatchDate == input.DispatchDate)
            .WhereIf(!input.ErpInvoiceNumber.IsNullOrWhiteSpace(), x => x.ErpInvoiceNumber.Contains(input.ErpInvoiceNumber))
            .WhereIf(!input.Note1.IsNullOrWhiteSpace(), x => x.Note1.Contains(input.Note1))
            .WhereIf(input.SubTotal != null, x => x.SubTotal == input.SubTotal)
            .WhereIf(input.DiscountTotal != null, x => x.DiscountTotal == input.DiscountTotal)
            .WhereIf(input.TotalWithDiscount != null, x => x.TotalWithDiscount == input.TotalWithDiscount)
            .WhereIf(input.VatAmount != null, x => x.VatAmount == input.VatAmount)
            .WhereIf(input.TotalWithVat != null, x => x.TotalWithVat == input.TotalWithVat)
            .WhereIf(input.TotalWithholding != null, x => x.TotalWithholding == input.TotalWithholding)
            .WhereIf(input.TotalAmount != null, x => x.TotalAmount == input.TotalAmount)
            .WhereIf(input.SubTotalTL != null, x => x.SubTotalTL == input.SubTotalTL)
            .WhereIf(input.DiscountTotalTL != null, x => x.DiscountTotalTL == input.DiscountTotalTL)
            .WhereIf(input.TotalWithDiscountTL != null, x => x.TotalWithDiscountTL == input.TotalWithDiscountTL)
            .WhereIf(input.VatAmountTL != null, x => x.VatAmountTL == input.VatAmountTL)
            .WhereIf(input.TotalWithVatTL != null, x => x.TotalWithVatTL == input.TotalWithVatTL)
            .WhereIf(input.TotalWithholdingTL != null, x => x.TotalWithholdingTL == input.TotalWithholdingTL)
            .WhereIf(input.TotalAmountTL != null, x => x.TotalAmountTL == input.TotalAmountTL)
            .WhereIf(input.ReturnInvoiceNumber != null, x => x.ReturnInvoiceNumber == input.ReturnInvoiceNumber)
            .WhereIf(input.ReturnInvoiceId != null, x => x.ReturnInvoiceId == input.ReturnInvoiceId)
            .WhereIf(input.CreatedBy != null, x => x.CreatedBy == input.CreatedBy)
            .WhereIf(input.CurrencyId != null, x => x.CurrencyId == input.CurrencyId)
            .WhereIf(!input.CurrencyCode.IsNullOrWhiteSpace(), x => x.CurrencyCode.Contains(input.CurrencyCode))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Title))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.Surname.IsNullOrWhiteSpace(), x => x.Surname.Contains(input.Surname))
            .WhereIf(input.CurrencyRate != null, x => x.CurrencyRate == input.CurrencyRate)
            .WhereIf(!input.SerialNumber.IsNullOrWhiteSpace(), x => x.SerialNumber.Contains(input.SerialNumber))
            .WhereIf(!input.DrawInvoiceNumber.IsNullOrWhiteSpace(), x => x.DrawInvoiceNumber.Contains(input.DrawInvoiceNumber))
            .WhereIf(!input.EnvelopeNumber.IsNullOrWhiteSpace(), x => x.EnvelopeNumber.Contains(input.EnvelopeNumber))
            .WhereIf(input.DrawEttn != null, x => x.DrawEttn == input.DrawEttn)
            .WhereIf(input.Ettn != null, x => x.Ettn == input.Ettn)
            .WhereIf(input.StatusId != null, x => x.StatusId == input.StatusId)
            .WhereIf(!input.StatusCode.IsNullOrWhiteSpace(), x => x.StatusCode.Contains(input.StatusCode))
            .WhereIf(!input.StatusDescription.IsNullOrWhiteSpace(), x => x.StatusDescription.Contains(input.StatusDescription))
            .WhereIf(!input.ServiceResult.IsNullOrWhiteSpace(), x => x.ServiceResult.Contains(input.ServiceResult))
            .WhereIf(!input.ServiceResultDescription.IsNullOrWhiteSpace(), x => x.ServiceResultDescription.Contains(input.ServiceResultDescription))
            .WhereIf(input.EnvelopeId != null, x => x.EnvelopeId == input.EnvelopeId)
            .WhereIf(!input.TCKN_VN_Sender.IsNullOrWhiteSpace(), x => x.TCKN_VN_Sender.Contains(input.TCKN_VN_Sender))
            .WhereIf(!input.ReceiverPostBoxName.IsNullOrWhiteSpace(), x => x.ReceiverPostBoxName.Contains(input.ReceiverPostBoxName))
            .WhereIf(!input.SenderPostBoxName.IsNullOrWhiteSpace(), x => x.SenderPostBoxName.Contains(input.SenderPostBoxName))
            .WhereIf(!input.ProfileId.IsNullOrWhiteSpace(), x => x.ProfileId.Contains(input.ProfileId))
            .WhereIf(!input.UblText.IsNullOrWhiteSpace(), x => x.UblText.Contains(input.UblText))
            .WhereIf(input.ChargeTotalAmount != null, x => x.ChargeTotalAmount == input.ChargeTotalAmount)
            .WhereIf(input.PaymentDueDate != null, x => x.PaymentDueDate == input.PaymentDueDate)
            .WhereIf(input.GIBDate != null, x => x.GIBDate == input.GIBDate)
            .WhereIf(input.isEInvoice != null, x => x.isEInvoice == input.isEInvoice)
            .WhereIf(input.isOutgoing != null, x => x.isOutgoing == input.isOutgoing)
            .WhereIf(input.MasterClientId != null, x => x.MasterClientId == input.MasterClientId)
            .WhereIf(input.isDraft != null, x => x.isDraft == input.isDraft)
            .WhereIf(input.isCancelled != null, x => x.isCancelled == input.isCancelled)
            .WhereIf(!input.cancelNote.IsNullOrWhiteSpace(), x => x.cancelNote.Contains(input.cancelNote))
            .WhereIf(input.cancelDate != null, x => x.cancelDate == input.cancelDate)
            .WhereIf(input.isAccepted != null, x => x.isAccepted == input.isAccepted)
            .WhereIf(input.acceptDate != null, x => x.acceptDate == input.acceptDate)
            .WhereIf(input.isRejected != null, x => x.isRejected == input.isRejected)
            .WhereIf(!input.rejectNote.IsNullOrWhiteSpace(), x => x.rejectNote.Contains(input.rejectNote))
            .WhereIf(input.rejectDate != null, x => x.rejectDate == input.rejectDate)
            .WhereIf(!input.DirectionText.IsNullOrWhiteSpace(), x => x.DirectionText.Contains(input.DirectionText))
            .WhereIf(input.IntegrationDate != null, x => x.IntegrationDate == input.IntegrationDate)
            .WhereIf(input.SourceId != null, x => x.SourceId == input.SourceId)
            .WhereIf(input.SourceRefId != null, x => x.SourceRefId == input.SourceRefId)
            .WhereIf(!input.SourceRefGuid.IsNullOrWhiteSpace(), x => x.SourceRefGuid.Contains(input.SourceRefGuid))
            .WhereIf(input.Vat0Matrah != null, x => x.Vat0Matrah == input.Vat0Matrah)
            .WhereIf(input.Vat1Matrah != null, x => x.Vat1Matrah == input.Vat1Matrah)
            .WhereIf(input.Vat8Matrah != null, x => x.Vat8Matrah == input.Vat8Matrah)
            .WhereIf(input.Vat10Matrah != null, x => x.Vat10Matrah == input.Vat10Matrah)
            .WhereIf(input.Vat18Matrah != null, x => x.Vat18Matrah == input.Vat18Matrah)
            .WhereIf(input.Vat20Matrah != null, x => x.Vat20Matrah == input.Vat20Matrah)
            .WhereIf(input.Vat26Matrah != null, x => x.Vat26Matrah == input.Vat26Matrah)
            .WhereIf(input.Vat0Amount != null, x => x.Vat0Amount == input.Vat0Amount)
            .WhereIf(input.Vat1Amount != null, x => x.Vat1Amount == input.Vat1Amount)
            .WhereIf(input.Vat8Amount != null, x => x.Vat8Amount == input.Vat8Amount)
            .WhereIf(input.Vat10Amount != null, x => x.Vat10Amount == input.Vat10Amount)
            .WhereIf(input.Vat18Amount != null, x => x.Vat18Amount == input.Vat18Amount)
            .WhereIf(input.Vat20Amount != null, x => x.Vat20Amount == input.Vat20Amount)
            .WhereIf(input.Vat26Amount != null, x => x.Vat26Amount == input.Vat26Amount)
            .WhereIf(!input.Iban.IsNullOrWhiteSpace(), x => x.Iban.Contains(input.Iban))
            .WhereIf(!input.SGKAccountingCost.IsNullOrWhiteSpace(), x => x.SGKAccountingCost.Contains(input.SGKAccountingCost))
            .WhereIf(!input.SGKMukellefKodu.IsNullOrWhiteSpace(), x => x.SGKMukellefKodu.Contains(input.SGKMukellefKodu))
            .WhereIf(!input.SGKMukellefAdi.IsNullOrWhiteSpace(), x => x.SGKMukellefAdi.Contains(input.SGKMukellefAdi))
            .WhereIf(!input.SGKDosyaNo.IsNullOrWhiteSpace(), x => x.SGKDosyaNo.Contains(input.SGKDosyaNo))
            .WhereIf(input.SGKDonemStartDate != null, x => x.SGKDonemStartDate == input.SGKDonemStartDate)
            .WhereIf(input.SGKDonemEndDate != null, x => x.SGKDonemEndDate == input.SGKDonemEndDate)
            .WhereIf(input.ProjectId != null, x => x.ProjectId == input.ProjectId)
            .WhereIf(input.BuyerClientId != null, x => x.BuyerClientId == input.BuyerClientId)
            .WhereIf(!input.BuyerCustomerIdOrTaxNumber.IsNullOrWhiteSpace(), x => x.BuyerCustomerIdOrTaxNumber.Contains(input.BuyerCustomerIdOrTaxNumber))
            .WhereIf(!input.BuyerTitle.IsNullOrWhiteSpace(), x => x.BuyerTitle.Contains(input.BuyerTitle))
            .WhereIf(!input.BuyerAddress.IsNullOrWhiteSpace(), x => x.BuyerAddress.Contains(input.BuyerAddress))
            .WhereIf(!input.BuyerCity.IsNullOrWhiteSpace(), x => x.BuyerCity.Contains(input.BuyerCity))
            .WhereIf(!input.BuyerTown.IsNullOrWhiteSpace(), x => x.BuyerTown.Contains(input.BuyerTown))
            .WhereIf(!input.BuyerCountry.IsNullOrWhiteSpace(), x => x.BuyerCountry.Contains(input.BuyerCountry))
            .WhereIf(!input.BuyerEmail.IsNullOrWhiteSpace(), x => x.BuyerEmail.Contains(input.BuyerEmail))
            .WhereIf(!input.PaymentMeansCode.IsNullOrWhiteSpace(), x => x.PaymentMeansCode.Contains(input.PaymentMeansCode))
            .WhereIf(!input.PaymentMeansDescription.IsNullOrWhiteSpace(), x => x.PaymentMeansDescription.Contains(input.PaymentMeansDescription))
            .WhereIf(!input.PaymentMeansIBAN.IsNullOrWhiteSpace(), x => x.PaymentMeansIBAN.Contains(input.PaymentMeansIBAN))
            .WhereIf(!input.PaymentMeansCurrencyCode.IsNullOrWhiteSpace(), x => x.PaymentMeansCurrencyCode.Contains(input.PaymentMeansCurrencyCode))
            .WhereIf(!input.ExportDeliveryCode.IsNullOrWhiteSpace(), x => x.ExportDeliveryCode.Contains(input.ExportDeliveryCode))
            .WhereIf(!input.ExportTransportModeCode.IsNullOrWhiteSpace(), x => x.ExportTransportModeCode.Contains(input.ExportTransportModeCode))
            .WhereIf(input.ExportFreightAmount != null, x => x.ExportFreightAmount == input.ExportFreightAmount)
            .WhereIf(input.ExportInsuranceAmount != null, x => x.ExportInsuranceAmount == input.ExportInsuranceAmount)
            .WhereIf(!input.ExportShipmentNumber.IsNullOrWhiteSpace(), x => x.ExportShipmentNumber.Contains(input.ExportShipmentNumber))
            .WhereIf(!input.ExportShipmentCountryCode.IsNullOrWhiteSpace(), x => x.ExportShipmentCountryCode.Contains(input.ExportShipmentCountryCode))
            .WhereIf(!input.ExportShipmentCountryName.IsNullOrWhiteSpace(), x => x.ExportShipmentCountryName.Contains(input.ExportShipmentCountryName))
            .WhereIf(!input.ExportShipmentCityName.IsNullOrWhiteSpace(), x => x.ExportShipmentCityName.Contains(input.ExportShipmentCityName))
            .WhereIf(!input.ExportShipmentTownName.IsNullOrWhiteSpace(), x => x.ExportShipmentTownName.Contains(input.ExportShipmentTownName))
            .WhereIf(!input.ExportShipmentStreetName.IsNullOrWhiteSpace(), x => x.ExportShipmentStreetName.Contains(input.ExportShipmentStreetName))
            .WhereIf(!input.ExportShipmentBuildingName.IsNullOrWhiteSpace(), x => x.ExportShipmentBuildingName.Contains(input.ExportShipmentBuildingName))
            .WhereIf(!input.ExportShipmentBuildingNumber.IsNullOrWhiteSpace(), x => x.ExportShipmentBuildingNumber.Contains(input.ExportShipmentBuildingNumber))
            .WhereIf(!input.ExportShipmentPostalCode.IsNullOrWhiteSpace(), x => x.ExportShipmentPostalCode.Contains(input.ExportShipmentPostalCode))
            .WhereIf(input.TransactionId != null, x => x.TransactionId == input.TransactionId)
            .WhereIf(input.isAffectStock != null, x => x.isAffectStock == input.isAffectStock)
            ;
    }

    public async Task<InvoiceResult<string>> sendInvoiceFromLingaERP(GeneralInvoiceDto dto_Invoice)
    {
        var invoiceResult = await saveGeneralInvoiceAsync(dto_Invoice);
        if (invoiceResult.HttpStatusCode != System.Net.HttpStatusCode.OK)
        {
            return invoiceResult;
        }
        else
        {
            return new InvoiceResult<string>()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                message = "OK",
                ETTN = invoiceResult.ETTN.ToString(),
                value = invoiceResult.value
            };
        }
    }

    public async Task<InvoiceResult<string>> saveGeneralInvoiceAsync(GeneralInvoiceDto Invoice)
    {
        var result = await myInvoiceOutboxService.saveGeneralInvoiceToDb(Invoice);
        if (result.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            return new InvoiceResult<string>()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                message = "Invoice is saved",
            };
        }
        else
        {
            return new InvoiceResult<string>()
            {
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest,
                message = result.message
            };
        }
    }
}
