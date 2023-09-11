using System;
using System.Linq;
using System.Threading.Tasks;
using ACME.POC3.Permissions;
using ACME.POC3.Invoice.Dtos;
using Volo.Abp.Application.Services;

namespace ACME.POC3.Invoice;


public class InvoiceLineAppService : CrudAppService<InvoiceLine, InvoiceLineDto, Guid, InvoiceLineGetListInput, CreateUpdateInvoiceLineDto, CreateUpdateInvoiceLineDto>,
    IInvoiceLineAppService
{
    protected override string GetPolicyName { get; set; } = POC3Permissions.InvoiceLine.Default;
    protected override string GetListPolicyName { get; set; } = POC3Permissions.InvoiceLine.Default;
    protected override string CreatePolicyName { get; set; } = POC3Permissions.InvoiceLine.Create;
    protected override string UpdatePolicyName { get; set; } = POC3Permissions.InvoiceLine.Update;
    protected override string DeletePolicyName { get; set; } = POC3Permissions.InvoiceLine.Delete;

    private readonly IInvoiceLineRepository _repository;

    public InvoiceLineAppService(IInvoiceLineRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<InvoiceLine>> CreateFilteredQueryAsync(InvoiceLineGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.InvoiceId != null, x => x.InvoiceId == input.InvoiceId)
            .WhereIf(input.ProductId != null, x => x.ProductId == input.ProductId)
            .WhereIf(!input.ProductName.IsNullOrWhiteSpace(), x => x.ProductName.Contains(input.ProductName))
            .WhereIf(input.Quantity != null, x => x.Quantity == input.Quantity)
            .WhereIf(!input.Unit.IsNullOrWhiteSpace(), x => x.Unit.Contains(input.Unit))
            .WhereIf(input.UnitId != null, x => x.UnitId == input.UnitId)
            .WhereIf(input.Price != null, x => x.Price == input.Price)
            .WhereIf(input.DiscountRate != null, x => x.DiscountRate == input.DiscountRate)
            .WhereIf(input.DiscountAmount != null, x => x.DiscountAmount == input.DiscountAmount)
            .WhereIf(input.SubTotal != null, x => x.SubTotal == input.SubTotal)
            .WhereIf(input.TotalWithDiscount != null, x => x.TotalWithDiscount == input.TotalWithDiscount)
            .WhereIf(input.VatRate != null, x => x.VatRate == input.VatRate)
            .WhereIf(input.VatAmount != null, x => x.VatAmount == input.VatAmount)
            .WhereIf(input.TotalWithVat != null, x => x.TotalWithVat == input.TotalWithVat)
            .WhereIf(!input.TaxExcludingReason.IsNullOrWhiteSpace(), x => x.TaxExcludingReason.Contains(input.TaxExcludingReason))
            .WhereIf(!input.TaxExcludingReasonCode.IsNullOrWhiteSpace(), x => x.TaxExcludingReasonCode.Contains(input.TaxExcludingReasonCode))
            .WhereIf(input.TaxExcludingReasonId != null, x => x.TaxExcludingReasonId == input.TaxExcludingReasonId)
            .WhereIf(!input.UnitCode.IsNullOrWhiteSpace(), x => x.UnitCode.Contains(input.UnitCode))
            .WhereIf(!input.LineID.IsNullOrWhiteSpace(), x => x.LineID.Contains(input.LineID))
            .WhereIf(!input.ProductCode.IsNullOrWhiteSpace(), x => x.ProductCode.Contains(input.ProductCode))
            .WhereIf(input.MasterClientId != null, x => x.MasterClientId == input.MasterClientId)
            .WhereIf(!input.WithholdingTaxCode.IsNullOrWhiteSpace(), x => x.WithholdingTaxCode.Contains(input.WithholdingTaxCode))
            .WhereIf(input.WithholdingTaxRate != null, x => x.WithholdingTaxRate == input.WithholdingTaxRate)
            .WhereIf(input.WithholdingTaxAmount != null, x => x.WithholdingTaxAmount == input.WithholdingTaxAmount)
            .WhereIf(input.TotalAmount != null, x => x.TotalAmount == input.TotalAmount)
            .WhereIf(!input.ExportDeliveryCode.IsNullOrWhiteSpace(), x => x.ExportDeliveryCode.Contains(input.ExportDeliveryCode))
            .WhereIf(!input.ExportTransportModeCode.IsNullOrWhiteSpace(), x => x.ExportTransportModeCode.Contains(input.ExportTransportModeCode))
            .WhereIf(!input.ExportPackageNumber.IsNullOrWhiteSpace(), x => x.ExportPackageNumber.Contains(input.ExportPackageNumber))
            .WhereIf(!input.ExportPackageType.IsNullOrWhiteSpace(), x => x.ExportPackageType.Contains(input.ExportPackageType))
            .WhereIf(input.ExportPackageQuantity != null, x => x.ExportPackageQuantity == input.ExportPackageQuantity)
            .WhereIf(!input.ExportPackageBrand.IsNullOrWhiteSpace(), x => x.ExportPackageBrand.Contains(input.ExportPackageBrand))
            .WhereIf(!input.ExportCustomsCode.IsNullOrWhiteSpace(), x => x.ExportCustomsCode.Contains(input.ExportCustomsCode))
            .WhereIf(!input.ExportShipmentNumber.IsNullOrWhiteSpace(), x => x.ExportShipmentNumber.Contains(input.ExportShipmentNumber))
            .WhereIf(input.ExportShipmentGrossWeight != null, x => x.ExportShipmentGrossWeight == input.ExportShipmentGrossWeight)
            .WhereIf(input.ExportShipmentNetWeight != null, x => x.ExportShipmentNetWeight == input.ExportShipmentNetWeight)
            .WhereIf(!input.ExportShipmentOriginCountryCode.IsNullOrWhiteSpace(), x => x.ExportShipmentOriginCountryCode.Contains(input.ExportShipmentOriginCountryCode))
            .WhereIf(!input.ExportShipmentCountryCode.IsNullOrWhiteSpace(), x => x.ExportShipmentCountryCode.Contains(input.ExportShipmentCountryCode))
            .WhereIf(!input.ExportShipmentCountryName.IsNullOrWhiteSpace(), x => x.ExportShipmentCountryName.Contains(input.ExportShipmentCountryName))
            .WhereIf(!input.ExportShipmentCityName.IsNullOrWhiteSpace(), x => x.ExportShipmentCityName.Contains(input.ExportShipmentCityName))
            .WhereIf(!input.ExportShipmentTownName.IsNullOrWhiteSpace(), x => x.ExportShipmentTownName.Contains(input.ExportShipmentTownName))
            .WhereIf(!input.ExportShipmentStreetName.IsNullOrWhiteSpace(), x => x.ExportShipmentStreetName.Contains(input.ExportShipmentStreetName))
            .WhereIf(!input.ExportShipmentBuildingName.IsNullOrWhiteSpace(), x => x.ExportShipmentBuildingName.Contains(input.ExportShipmentBuildingName))
            .WhereIf(!input.ExportShipmentBuildingNumber.IsNullOrWhiteSpace(), x => x.ExportShipmentBuildingNumber.Contains(input.ExportShipmentBuildingNumber))
            .WhereIf(!input.ExportShipmentPostalCode.IsNullOrWhiteSpace(), x => x.ExportShipmentPostalCode.Contains(input.ExportShipmentPostalCode))
            .WhereIf(input.ProductTransactionId != null, x => x.ProductTransactionId == input.ProductTransactionId)
            ;
    }
}
