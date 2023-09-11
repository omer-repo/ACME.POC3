using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace ACME.POC3.Invoice.Dtos;

[Serializable]
public class InvoiceGetListInput : PagedAndSortedResultRequestDto
{
    public string Scenario { get; set; }

    public string EInvoicePostCode { get; set; }

    public string TesisatNo { get; set; }

    public string SalesType { get; set; }

    public Nullable<int> SalesTypeId { get; set; }

    public string SendingType { get; set; }

    public string WebUrl { get; set; }

    public DateTime? SendingDate { get; set; }

    public string ShippingPartyName { get; set; }

    public string ShippingVKN { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string PaymentTypeCode { get; set; }

    public string InvoiceType { get; set; }

    public string InvoiceNumber { get; set; }

    public string DocumentTrackNumber { get; set; }

    public string TCKN_VN { get; set; }

    public string TaxOffice { get; set; }

    public int? TaxOfficeId { get; set; }

    public string Country { get; set; }

    public Guid? CountryId { get; set; }

    public string City { get; set; }

    public int? CityId { get; set; }

    public string Town { get; set; }

    public int? TownId { get; set; }

    public string BuildingName { get; set; }

    public string BuildingNumber { get; set; }

    public string DoorNumber { get; set; }

    public string PostCode { get; set; }

    public string StreetName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public string WebAddress { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public DateTime? SendDate { get; set; }

    public int? TemplateId { get; set; }

    public string TemplateCode { get; set; }

    public string OrderNumber { get; set; }

    public DateTime? OrderDate { get; set; }

    public string DispatchNumber { get; set; }

    public DateTime? DispatchDate { get; set; }

    public string ErpInvoiceNumber { get; set; }

    public string Note1 { get; set; }

    public double? SubTotal { get; set; }

    public double? _DiscountTotal { get; set; }

    public double? DiscountTotal { get; set; }

    public double? _TotalWithDiscount { get; set; }

    public double? TotalWithDiscount { get; set; }

    public double? _VatAmount { get; set; }

    public double? VatAmount { get; set; }

    public double? _TotalWithVat { get; set; }

    public double? TotalWithVat { get; set; }

    public double? _TotalWithholding { get; set; }

    public double? TotalWithholding { get; set; }

    public double? _TotalAmount { get; set; }

    public double? TotalAmount { get; set; }

    public double? SubTotalTL { get; set; }

    public double? DiscountTotalTL { get; set; }

    public double? TotalWithDiscountTL { get; set; }

    public double? VatAmountTL { get; set; }

    public double? TotalWithVatTL { get; set; }

    public double? TotalWithholdingTL { get; set; }

    public double? TotalAmountTL { get; set; }

    public double? ReturnInvoiceNumber { get; set; }

    public int? ReturnInvoiceId { get; set; }

    public int? CreatedBy { get; set; }

    public Guid? CurrencyId { get; set; }

    public string CurrencyCode { get; set; }

    public string Title { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public double? _CurrencyRate { get; set; }

    public double? CurrencyRate { get; set; }

    public string SerialNumber { get; set; }

    public string DrawInvoiceNumber { get; set; }

    public string EnvelopeNumber { get; set; }

    public Guid? DrawEttn { get; set; }

    public Guid? Ettn { get; set; }

    public int? StatusId { get; set; }

    public string StatusCode { get; set; }

    public string StatusDescription { get; set; }

    public string ServiceResult { get; set; }

    public string ServiceResultDescription { get; set; }

    public int? EnvelopeId { get; set; }

    public string TCKN_VN_Sender { get; set; }

    public string ReceiverPostBoxName { get; set; }

    public string SenderPostBoxName { get; set; }

    public string ProfileId { get; set; }

    public string UblText { get; set; }

    public double? ChargeTotalAmount { get; set; }

    public DateTime? PaymentDueDate { get; set; }

    public DateTime? GIBDate { get; set; }

    public bool? isEInvoice { get; set; }

    public bool? isOutgoing { get; set; }

    public Guid? MasterClientId { get; set; }

    public bool? isDraft { get; set; }

    public bool? isCancelled { get; set; }

    public string cancelNote { get; set; }

    public DateTime? cancelDate { get; set; }

    public bool? isAccepted { get; set; }

    public DateTime? acceptDate { get; set; }

    public bool? isRejected { get; set; }

    public string rejectNote { get; set; }

    public DateTime? rejectDate { get; set; }

    public string DirectionText { get; set; }

    public DateTime? IntegrationDate { get; set; }

    public int? SourceId { get; set; }

    public int? SourceRefId { get; set; }

    public string SourceRefGuid { get; set; }

    public double? Vat0Matrah { get; set; }

    public double? Vat1Matrah { get; set; }

    public double? Vat8Matrah { get; set; }

    public double? Vat10Matrah { get; set; }

    public double? Vat18Matrah { get; set; }

    public double? Vat20Matrah { get; set; }

    public double? Vat26Matrah { get; set; }

    public double? Vat0Amount { get; set; }

    public double? Vat1Amount { get; set; }

    public double? Vat8Amount { get; set; }

    public double? Vat10Amount { get; set; }

    public double? Vat18Amount { get; set; }

    public double? Vat20Amount { get; set; }

    public double? Vat26Amount { get; set; }

    public string Iban { get; set; }

    public string SGKAccountingCost { get; set; }

    public string SGKMukellefKodu { get; set; }

    public string SGKMukellefAdi { get; set; }

    public string SGKDosyaNo { get; set; }

    public DateTime? SGKDonemStartDate { get; set; }

    public DateTime? SGKDonemEndDate { get; set; }

    public int? ProjectId { get; set; }

    public Guid? BuyerClientId { get; set; }

    public string BuyerCustomerIdOrTaxNumber { get; set; }

    public string BuyerTitle { get; set; }

    public string BuyerAddress { get; set; }

    public string BuyerCity { get; set; }

    public string BuyerTown { get; set; }

    public string BuyerCountry { get; set; }

    public string BuyerEmail { get; set; }

    public string PaymentMeansCode { get; set; }

    public string PaymentMeansDescription { get; set; }

    public string PaymentMeansIBAN { get; set; }

    public string PaymentMeansCurrencyCode { get; set; }

    public string ExportDeliveryCode { get; set; }

    public string ExportTransportModeCode { get; set; }

    public double? ExportFreightAmount { get; set; }

    public double? ExportInsuranceAmount { get; set; }

    public string ExportShipmentNumber { get; set; }

    public string ExportShipmentCountryCode { get; set; }

    public string ExportShipmentCountryName { get; set; }

    public string ExportShipmentCityName { get; set; }

    public string ExportShipmentTownName { get; set; }

    public string ExportShipmentStreetName { get; set; }

    public string ExportShipmentBuildingName { get; set; }

    public string ExportShipmentBuildingNumber { get; set; }

    public string ExportShipmentPostalCode { get; set; }

    public Guid? TransactionId { get; set; }

    public bool? isAffectStock { get; set; }
}