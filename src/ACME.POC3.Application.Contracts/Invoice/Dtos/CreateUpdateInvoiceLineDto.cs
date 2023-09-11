using System;

namespace ACME.POC3.Invoice.Dtos;

[Serializable]
public class CreateUpdateInvoiceLineDto
{
    public Guid InvoiceId { get; set; }

    public Guid? ProductId { get; set; }

    public string ProductName { get; set; }

    public double Quantity { get; set; }

    public string Unit { get; set; }

    public int UnitId { get; set; }

    public double Price { get; set; }

    public double DiscountRate { get; set; }

    public double DiscountAmount { get; set; }

    public double SubTotal { get; set; }

    public double TotalWithDiscount { get; set; }

    public double VatRate { get; set; }

    public double VatAmount { get; set; }

    public double TotalWithVat { get; set; }

    public string TaxExcludingReason { get; set; }

    public string TaxExcludingReasonCode { get; set; }

    public int TaxExcludingReasonId { get; set; }

    public string UnitCode { get; set; }

    public string LineID { get; set; }

    public string ProductCode { get; set; }

    public Guid MasterClientId { get; set; }

    public string WithholdingTaxCode { get; set; }

    public double WithholdingTaxRate { get; set; }

    public double WithholdingTaxAmount { get; set; }

    public double TotalAmount { get; set; }

    public string ExportDeliveryCode { get; set; }

    public string ExportTransportModeCode { get; set; }

    public string ExportPackageNumber { get; set; }

    public string ExportPackageType { get; set; }

    public double ExportPackageQuantity { get; set; }

    public string ExportPackageBrand { get; set; }

    public string ExportCustomsCode { get; set; }

    public string ExportShipmentNumber { get; set; }

    public double ExportShipmentGrossWeight { get; set; }

    public double ExportShipmentNetWeight { get; set; }

    public string ExportShipmentOriginCountryCode { get; set; }

    public string ExportShipmentCountryCode { get; set; }

    public string ExportShipmentCountryName { get; set; }

    public string ExportShipmentCityName { get; set; }

    public string ExportShipmentTownName { get; set; }

    public string ExportShipmentStreetName { get; set; }

    public string ExportShipmentBuildingName { get; set; }

    public string ExportShipmentBuildingNumber { get; set; }

    public string ExportShipmentPostalCode { get; set; }

    public Guid? ProductTransactionId { get; set; }
}