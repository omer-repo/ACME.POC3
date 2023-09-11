using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ACME.POC3.Invoice
{
    public  class InvoiceLine: FullAuditedAggregateRoot<Guid>, IMultiTenant
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
        public Guid? TenantId { get; set; }

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
        public string ExportCustomsCode { get; set; } //GTIP
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

        protected InvoiceLine()
        {
        }

        public InvoiceLine(
            Guid id
        ) : base(id)
        {
           
        }

    public InvoiceLine(
        Guid id,
        Guid invoiceId,
        Guid? productId,
        string productName,
        double quantity,
        string unit,
        int unitId,
        double price,
        double discountRate,
        double discountAmount,
        double subTotal,
        double totalWithDiscount,
        double vatRate,
        double vatAmount,
        double totalWithVat,
        string taxExcludingReason,
        string taxExcludingReasonCode,
        int taxExcludingReasonId,
        string unitCode,
        string lineID,
        string productCode,
        Guid masterClientId,
        Guid? tenantId,
        string withholdingTaxCode,
        double withholdingTaxRate,
        double withholdingTaxAmount,
        double totalAmount,
        string exportDeliveryCode,
        string exportTransportModeCode,
        string exportPackageNumber,
        string exportPackageType,
        double exportPackageQuantity,
        string exportPackageBrand,
        string exportCustomsCode,
        string exportShipmentNumber,
        double exportShipmentGrossWeight,
        double exportShipmentNetWeight,
        string exportShipmentOriginCountryCode,
        string exportShipmentCountryCode,
        string exportShipmentCountryName,
        string exportShipmentCityName,
        string exportShipmentTownName,
        string exportShipmentStreetName,
        string exportShipmentBuildingName,
        string exportShipmentBuildingNumber,
        string exportShipmentPostalCode,
        Guid? productTransactionId
    ) : base(id)
    {
        InvoiceId = invoiceId;
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        Unit = unit;
        UnitId = unitId;
        Price = price;
        DiscountRate = discountRate;
        DiscountAmount = discountAmount;
        SubTotal = subTotal;
        TotalWithDiscount = totalWithDiscount;
        VatRate = vatRate;
        VatAmount = vatAmount;
        TotalWithVat = totalWithVat;
        TaxExcludingReason = taxExcludingReason;
        TaxExcludingReasonCode = taxExcludingReasonCode;
        TaxExcludingReasonId = taxExcludingReasonId;
        UnitCode = unitCode;
        LineID = lineID;
        ProductCode = productCode;
        MasterClientId = masterClientId;
        TenantId = tenantId;
        WithholdingTaxCode = withholdingTaxCode;
        WithholdingTaxRate = withholdingTaxRate;
        WithholdingTaxAmount = withholdingTaxAmount;
        TotalAmount = totalAmount;
        ExportDeliveryCode = exportDeliveryCode;
        ExportTransportModeCode = exportTransportModeCode;
        ExportPackageNumber = exportPackageNumber;
        ExportPackageType = exportPackageType;
        ExportPackageQuantity = exportPackageQuantity;
        ExportPackageBrand = exportPackageBrand;
        ExportCustomsCode = exportCustomsCode;
        ExportShipmentNumber = exportShipmentNumber;
        ExportShipmentGrossWeight = exportShipmentGrossWeight;
        ExportShipmentNetWeight = exportShipmentNetWeight;
        ExportShipmentOriginCountryCode = exportShipmentOriginCountryCode;
        ExportShipmentCountryCode = exportShipmentCountryCode;
        ExportShipmentCountryName = exportShipmentCountryName;
        ExportShipmentCityName = exportShipmentCityName;
        ExportShipmentTownName = exportShipmentTownName;
        ExportShipmentStreetName = exportShipmentStreetName;
        ExportShipmentBuildingName = exportShipmentBuildingName;
        ExportShipmentBuildingNumber = exportShipmentBuildingNumber;
        ExportShipmentPostalCode = exportShipmentPostalCode;
        ProductTransactionId = productTransactionId;
    }
    }
}
