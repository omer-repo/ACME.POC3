using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ACME.POC3.Invoice
{
    public partial class Invoice : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public string? Scenario { get; set; }
        public string? EInvoicePostCode { get; set; } 
        public string? TesisatNo { get; set; }
        public string? SalesType { get; set; }
        public Nullable<int> SalesTypeId { get; set; }
        public string? SendingType { get; set; }
        public string? WebUrl { get; set; }
        public DateTime? SendingDate { get; set; }
        public string? ShippingPartyName { get; set; }
        public string? ShippingVKN { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentTypeCode { get; set; }
        public string? InvoiceType { get; set; } 
        public string? InvoiceNumber { get; set; }
        public string? DocumentTrackNumber { get; set; } 
        public string? TCKN_VN { get; set; }
        public string? TaxOffice { get; set; }
        public int TaxOfficeId { get; set; }
        public string? Country { get; set; }
		public Guid CountryId { get; set; }
		public string? City { get; set; }
        public int CityId { get; set; }
        public string? Town { get; set; }
        public int TownId { get; set; }
        public string? BuildingName { get; set; }
        public string? BuildingNumber { get; set; }
        public string? DoorNumber { get; set; }
        public string? PostCode { get; set; }
        public string? StreetName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? WebAddress { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? SendDate { get; set; }
        public int TemplateId { get; set; }
        public string? TemplateCode { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? DispatchNumber { get; set; }
        public DateTime? DispatchDate { get; set; }
        public string? ErpInvoiceNumber { get; set; }
        public string? Note1 { get; set; }
        //public double SubTotal { get; set; }
        private double _SubTotal;
        public double SubTotal
        {
            get { return _SubTotal; }
            set
            {
                // Set B to some new value
                _SubTotal = value;

                // Assign C
                //SubTotalTL = SubTotal * CurrencyRate;
                UpdateTL();
            }
        }
        private double _DiscountTotal { get; set; }
        public double DiscountTotal
        {
            get { return _DiscountTotal; }
            set
            {
                // Set B to some new value
                _DiscountTotal = value;

                // Assign C
                UpdateTL();
            }
        }
        private double _TotalWithDiscount { get; set; }
        public double TotalWithDiscount
        {
            get { return _TotalWithDiscount; }
            set
            {
                // Set B to some new value
                _TotalWithDiscount = value;

                // Assign C
                UpdateTL();
            }
        }
        private double _VatAmount { get; set; }
        public double VatAmount
        {
            get { return _VatAmount; }
            set
            {
                // Set B to some new value
                _VatAmount = value;

                // Assign C
                UpdateTL();
            }
        }
        private double _TotalWithVat { get; set; }
        public double TotalWithVat
        {
            get { return _TotalWithVat; }
            set
            {
                // Set B to some new value
                _TotalWithVat = value;

                // Assign C
                UpdateTL();
            }
        }
        private double _TotalWithholding { get; set; }
        public double TotalWithholding
        {
            get { return _TotalWithholding; }
            set
            {
                // Set B to some new value
                _TotalWithholding = value;

                // Assign C
                UpdateTL();
            }
        }
        private double _TotalAmount { get; set; }
        public double TotalAmount
        {
            get { return _TotalAmount; }
            set
            {
                // Set B to some new value
                _TotalAmount = value;

                // Assign C
                UpdateTL();
            }
        }

        //TL tutarlar
        public double SubTotalTL { get; set; }
        public double DiscountTotalTL { get; set; }
        public double TotalWithDiscountTL { get; set; }
        public double VatAmountTL { get; set; }
        public double TotalWithVatTL { get; set; }
        public double TotalWithholdingTL { get; set; }
        public double TotalAmountTL { get; set; }

        public double ReturnInvoiceNumber { get; set; }
        public int ReturnInvoiceId { get; set; }
        public int CreatedBy { get; set; }
        public Guid CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        //public double CurrencyRate { get; set; }
        private double _CurrencyRate { get; set; }
        
        public double CurrencyRate
        {
            get { return _CurrencyRate; }
            set
            {
                // Set B to some new value
                _CurrencyRate = value;

                // Assign C
                UpdateTL();
            }
        }
        public string? SerialNumber { get; set; }
        public string? DrawInvoiceNumber { get; set; }
        public string? EnvelopeNumber { get; set; }
        public Guid? DrawEttn { get; set; }
        public Guid? Ettn { get; set; }
        public int StatusId { get; set; }
        public string? StatusCode { get; set; }
        public string? StatusDescription { get; set; }
        public string? ServiceResult { get; set; }
        public string? ServiceResultDescription { get; set; }
        public int EnvelopeId { get; set; }
        public string? TCKN_VN_Sender { get; set; }
        public string? ReceiverPostBoxName { get; set; }
        public string? SenderPostBoxName { get; set; }
        public string? ProfileId { get; set; }
        public string? UblText { get; set; }
        public double ChargeTotalAmount { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public DateTime? GIBDate { get; set; }
        
        public bool isEInvoice { get; set; }
        public bool isOutgoing { get; set; }
        public Guid MasterClientId { get; set; }
        
        public bool isDraft { get; set; }
        public bool isCancelled { get; set; }
        public string? cancelNote { get; set; }
        public DateTime? cancelDate { get; set; }
        public bool isAccepted { get; set; }
        public DateTime? acceptDate { get; set; }
        public bool isRejected { get; set; }
        public string? rejectNote { get; set; }
        public DateTime? rejectDate { get; set; }
        public string? DirectionText { get; set; }
        public DateTime? IntegrationDate { get; set; }
        public int SourceId { get; set; }
        public int SourceRefId { get; set; }
        public string? SourceRefGuid { get; set; }
        public double Vat0Matrah { get; set; }
        public double Vat1Matrah { get; set; }
        public double Vat8Matrah { get; set; }
        public double Vat10Matrah { get; set; }
        public double Vat18Matrah { get; set; }
        public double Vat20Matrah { get; set; }
        public double Vat26Matrah { get; set; }
        public double Vat0Amount { get; set; }
        public double Vat1Amount { get; set; }
        public double Vat8Amount { get; set; }
        public double Vat10Amount { get; set; }
        public double Vat18Amount { get; set; }
        public double Vat20Amount { get; set; }
        public double Vat26Amount { get; set; }
        public string? Iban { get; set; }
       
        public string? SGKAccountingCost { get; set; }
        public string? SGKMukellefKodu { get; set; }
        public string? SGKMukellefAdi { get; set; }
        public string? SGKDosyaNo { get; set; }
        public DateTime? SGKDonemStartDate { get; set; }
        public DateTime? SGKDonemEndDate { get; set; }
        public Guid? TenantId { get; set; }
        public int ProjectId { get; set; }
        public Guid? BuyerClientId { get; set; }
        public string? BuyerCustomerIdOrTaxNumber { get; set; }
        public string? BuyerTitle { get; set; }
        public string? BuyerAddress { get; set; }
        public string? BuyerCity { get; set; }
        public string? BuyerTown { get; set; }
        public string? BuyerCountry { get; set; }
        public string? BuyerEmail { get; set; }
        public string? PaymentMeansCode { get; set; }
        public string? PaymentMeansDescription { get; set; }
        public string? PaymentMeansIBAN { get; set; }
        public string? PaymentMeansCurrencyCode { get; set; }

        //public Guid? PaymentMeansCurrencyId { get; set; }
        public string? ExportDeliveryCode { get; set; }
        public string? ExportTransportModeCode { get; set; }
        public double ExportFreightAmount { get; set; }
        public double ExportInsuranceAmount { get; set; }
        public string? ExportShipmentNumber { get; set; }
        public string? ExportShipmentCountryCode { get; set; }
        public string? ExportShipmentCountryName { get; set; }
        public string? ExportShipmentCityName { get; set; }
        public string? ExportShipmentTownName { get; set; }
        public string? ExportShipmentStreetName{ get; set; }
        public string? ExportShipmentBuildingName { get; set; }
        public string? ExportShipmentBuildingNumber { get; set; }
        public string? ExportShipmentPostalCode { get; set; }
        public Guid? TransactionId { get; set; }
        public bool isAffectStock { get; set; }

        protected Invoice()
        {
        }

        private void UpdateTL()
        {
            SubTotalTL = SubTotal * CurrencyRate;
            DiscountTotalTL = DiscountTotal * CurrencyRate;
            TotalWithDiscountTL = TotalWithDiscount * CurrencyRate;
            VatAmountTL = VatAmount * CurrencyRate;
            TotalWithVatTL = TotalWithVat * CurrencyRate;
            TotalWithholdingTL = TotalWithholding * CurrencyRate;
            TotalAmountTL = TotalAmount * CurrencyRate;
        }

        public Invoice(
            Guid id
        ) : base(id)
        {
            
        }

    public Invoice(
        Guid id,
        string? scenario,
        string? eInvoicePostCode,
        string? tesisatNo,
        string? salesType,
        Nullable<int> salesTypeId,
        string? sendingType,
        string? webUrl,
        DateTime? sendingDate,
        string? shippingPartyName,
        string? shippingVKN,
        DateTime? paymentDate,
        string? paymentTypeCode,
        string? invoiceType,
        string? invoiceNumber,
        string? documentTrackNumber,
        string? tCKN_VN,
        string? taxOffice,
        int taxOfficeId,
        string? country,
        Guid countryId,
        string? city,
        int cityId,
        string? town,
        int townId,
        string? buildingName,
        string? buildingNumber,
        string? doorNumber,
        string? postCode,
        string? streetName,
        string? email,
        string? phone,
        string? fax,
        string? webAddress,
        DateTime invoiceDate,
        DateTime? sendDate,
        int templateId,
        string? templateCode,
        string? orderNumber,
        DateTime? orderDate,
        string? dispatchNumber,
        DateTime? dispatchDate,
        string? erpInvoiceNumber,
        string? note1,
        double subTotal,
        double _DiscountTotal,
        double discountTotal,
        double _TotalWithDiscount,
        double totalWithDiscount,
        double _VatAmount,
        double vatAmount,
        double _TotalWithVat,
        double totalWithVat,
        double _TotalWithholding,
        double totalWithholding,
        double _TotalAmount,
        double totalAmount,
        double subTotalTL,
        double discountTotalTL,
        double totalWithDiscountTL,
        double vatAmountTL,
        double totalWithVatTL,
        double totalWithholdingTL,
        double totalAmountTL,
        double returnInvoiceNumber,
        int returnInvoiceId,
        int createdBy,
        Guid currencyId,
        string? currencyCode,
        string? title,
        string? name,
        string? surname,
        double _CurrencyRate,
        double currencyRate,
        string? serialNumber,
        string? drawInvoiceNumber,
        string? envelopeNumber,
        Guid? drawEttn,
        Guid? ettn,
        int statusId,
        string? statusCode,
        string? statusDescription,
        string? serviceResult,
        string? serviceResultDescription,
        int envelopeId,
        string? tCKN_VN_Sender,
        string? receiverPostBoxName,
        string? senderPostBoxName,
        string? profileId,
        string? ublText,
        double chargeTotalAmount,
        DateTime? paymentDueDate,
        DateTime? gIBDate,
        bool isEInvoice,
        bool isOutgoing,
        Guid masterClientId,
        bool isDraft,
        bool isCancelled,
        string? cancelNote,
        DateTime? cancelDate,
        bool isAccepted,
        DateTime? acceptDate,
        bool isRejected,
        string? rejectNote,
        DateTime? rejectDate,
        string? directionText,
        DateTime? integrationDate,
        int sourceId,
        int sourceRefId,
        string? sourceRefGuid,
        double vat0Matrah,
        double vat1Matrah,
        double vat8Matrah,
        double vat10Matrah,
        double vat18Matrah,
        double vat20Matrah,
        double vat26Matrah,
        double vat0Amount,
        double vat1Amount,
        double vat8Amount,
        double vat10Amount,
        double vat18Amount,
        double vat20Amount,
        double vat26Amount,
        string? iban,
        string? sGKAccountingCost,
        string? sGKMukellefKodu,
        string? sGKMukellefAdi,
        string? sGKDosyaNo,
        DateTime? sGKDonemStartDate,
        DateTime? sGKDonemEndDate,
        Guid? tenantId,
        int projectId,
        Guid? buyerClientId,
        string? buyerCustomerIdOrTaxNumber,
        string? buyerTitle,
        string? buyerAddress,
        string? buyerCity,
        string? buyerTown,
        string? buyerCountry,
        string? buyerEmail,
        string? paymentMeansCode,
        string? paymentMeansDescription,
        string? paymentMeansIBAN,
        string? paymentMeansCurrencyCode,
        string? exportDeliveryCode,
        string? exportTransportModeCode,
        double exportFreightAmount,
        double exportInsuranceAmount,
        string? exportShipmentNumber,
        string? exportShipmentCountryCode,
        string? exportShipmentCountryName,
        string? exportShipmentCityName,
        string? exportShipmentTownName,
        string? exportShipmentStreetName,
        string? exportShipmentBuildingName,
        string? exportShipmentBuildingNumber,
        string? exportShipmentPostalCode,
        Guid? transactionId,
        bool isAffectStock
    ) : base(id)
    {
        Scenario = scenario;
        EInvoicePostCode = eInvoicePostCode;
        TesisatNo = tesisatNo;
        SalesType = salesType;
        SalesTypeId = salesTypeId;
        SendingType = sendingType;
        WebUrl = webUrl;
        SendingDate = sendingDate;
        ShippingPartyName = shippingPartyName;
        ShippingVKN = shippingVKN;
        PaymentDate = paymentDate;
        PaymentTypeCode = paymentTypeCode;
        InvoiceType = invoiceType;
        InvoiceNumber = invoiceNumber;
        DocumentTrackNumber = documentTrackNumber;
        TCKN_VN = tCKN_VN;
        TaxOffice = taxOffice;
        TaxOfficeId = taxOfficeId;
        Country = country;
        CountryId = countryId;
        City = city;
        CityId = cityId;
        Town = town;
        TownId = townId;
        BuildingName = buildingName;
        BuildingNumber = buildingNumber;
        DoorNumber = doorNumber;
        PostCode = postCode;
        StreetName = streetName;
        Email = email;
        Phone = phone;
        Fax = fax;
        WebAddress = webAddress;
        InvoiceDate = invoiceDate;
        SendDate = sendDate;
        TemplateId = templateId;
        TemplateCode = templateCode;
        OrderNumber = orderNumber;
        OrderDate = orderDate;
        DispatchNumber = dispatchNumber;
        DispatchDate = dispatchDate;
        ErpInvoiceNumber = erpInvoiceNumber;
        Note1 = note1;
        SubTotal = subTotal;
        _DiscountTotal = _DiscountTotal;
        DiscountTotal = discountTotal;
        _TotalWithDiscount = _TotalWithDiscount;
        TotalWithDiscount = totalWithDiscount;
        _VatAmount = _VatAmount;
        VatAmount = vatAmount;
        _TotalWithVat = _TotalWithVat;
        TotalWithVat = totalWithVat;
        _TotalWithholding = _TotalWithholding;
        TotalWithholding = totalWithholding;
        _TotalAmount = _TotalAmount;
        TotalAmount = totalAmount;
        SubTotalTL = subTotalTL;
        DiscountTotalTL = discountTotalTL;
        TotalWithDiscountTL = totalWithDiscountTL;
        VatAmountTL = vatAmountTL;
        TotalWithVatTL = totalWithVatTL;
        TotalWithholdingTL = totalWithholdingTL;
        TotalAmountTL = totalAmountTL;
        ReturnInvoiceNumber = returnInvoiceNumber;
        ReturnInvoiceId = returnInvoiceId;
        CreatedBy = createdBy;
        CurrencyId = currencyId;
        CurrencyCode = currencyCode;
        Title = title;
        Name = name;
        Surname = surname;
        _CurrencyRate = _CurrencyRate;
        CurrencyRate = currencyRate;
        SerialNumber = serialNumber;
        DrawInvoiceNumber = drawInvoiceNumber;
        EnvelopeNumber = envelopeNumber;
        DrawEttn = drawEttn;
        Ettn = ettn;
        StatusId = statusId;
        StatusCode = statusCode;
        StatusDescription = statusDescription;
        ServiceResult = serviceResult;
        ServiceResultDescription = serviceResultDescription;
        EnvelopeId = envelopeId;
        TCKN_VN_Sender = tCKN_VN_Sender;
        ReceiverPostBoxName = receiverPostBoxName;
        SenderPostBoxName = senderPostBoxName;
        ProfileId = profileId;
        UblText = ublText;
        ChargeTotalAmount = chargeTotalAmount;
        PaymentDueDate = paymentDueDate;
        GIBDate = gIBDate;
        isEInvoice = isEInvoice;
        isOutgoing = isOutgoing;
        MasterClientId = masterClientId;
        isDraft = isDraft;
        isCancelled = isCancelled;
        cancelNote = cancelNote;
        cancelDate = cancelDate;
        isAccepted = isAccepted;
        acceptDate = acceptDate;
        isRejected = isRejected;
        rejectNote = rejectNote;
        rejectDate = rejectDate;
        DirectionText = directionText;
        IntegrationDate = integrationDate;
        SourceId = sourceId;
        SourceRefId = sourceRefId;
        SourceRefGuid = sourceRefGuid;
        Vat0Matrah = vat0Matrah;
        Vat1Matrah = vat1Matrah;
        Vat8Matrah = vat8Matrah;
        Vat10Matrah = vat10Matrah;
        Vat18Matrah = vat18Matrah;
        Vat20Matrah = vat20Matrah;
        Vat26Matrah = vat26Matrah;
        Vat0Amount = vat0Amount;
        Vat1Amount = vat1Amount;
        Vat8Amount = vat8Amount;
        Vat10Amount = vat10Amount;
        Vat18Amount = vat18Amount;
        Vat20Amount = vat20Amount;
        Vat26Amount = vat26Amount;
        Iban = iban;
        SGKAccountingCost = sGKAccountingCost;
        SGKMukellefKodu = sGKMukellefKodu;
        SGKMukellefAdi = sGKMukellefAdi;
        SGKDosyaNo = sGKDosyaNo;
        SGKDonemStartDate = sGKDonemStartDate;
        SGKDonemEndDate = sGKDonemEndDate;
        TenantId = tenantId;
        ProjectId = projectId;
        BuyerClientId = buyerClientId;
        BuyerCustomerIdOrTaxNumber = buyerCustomerIdOrTaxNumber;
        BuyerTitle = buyerTitle;
        BuyerAddress = buyerAddress;
        BuyerCity = buyerCity;
        BuyerTown = buyerTown;
        BuyerCountry = buyerCountry;
        BuyerEmail = buyerEmail;
        PaymentMeansCode = paymentMeansCode;
        PaymentMeansDescription = paymentMeansDescription;
        PaymentMeansIBAN = paymentMeansIBAN;
        PaymentMeansCurrencyCode = paymentMeansCurrencyCode;
        ExportDeliveryCode = exportDeliveryCode;
        ExportTransportModeCode = exportTransportModeCode;
        ExportFreightAmount = exportFreightAmount;
        ExportInsuranceAmount = exportInsuranceAmount;
        ExportShipmentNumber = exportShipmentNumber;
        ExportShipmentCountryCode = exportShipmentCountryCode;
        ExportShipmentCountryName = exportShipmentCountryName;
        ExportShipmentCityName = exportShipmentCityName;
        ExportShipmentTownName = exportShipmentTownName;
        ExportShipmentStreetName = exportShipmentStreetName;
        ExportShipmentBuildingName = exportShipmentBuildingName;
        ExportShipmentBuildingNumber = exportShipmentBuildingNumber;
        ExportShipmentPostalCode = exportShipmentPostalCode;
        TransactionId = transactionId;
        isAffectStock = isAffectStock;
    }
    }
}
