using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ACME.POC3.Invoice
{
    public partial class MasterClient: FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public int? SourceId { get; set; }
        public int? SourceRefId { get; set; }
        public string SourceRefGuid { get; set; }
        public string TCKN_VN { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TaxOffice { get; set; }
        public int? TaxOfficeId { get; set; }
        public string Country { get; set; }
        public Guid CountryId { get; set; }
        public string City { get; set; }
        public int? CityId { get; set; }
        public Guid PriceListId { get; set; }
        public Guid CategoryId { get; set; }
        public string Town { get; set; }
        public int? TownId { get; set; }
        public int? ExchangeRateCalculation { get; set; } 
        public string BuildingName { get; set; }
        public string BuildingNumber { get; set; }
        public string DoorNumber { get; set; }
        public string PostCode { get; set; }
        public string StreetName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WebAddress { get; set; }
        public string Address { get; set; }
        public string SourceCode { get; set; }
        public System.DateTime? SourceLastUpdate { get; set; }
        public Guid? TenantId { get; set; }

        public double TotalCredit { get; set; }
        public double TotalDebit { get; set; }
        public double TotalBalance { get; set; }
        public double TotalCreditLimit { get; set; }
        public double TotalDebitLimit { get; set; }
        public double TotalBalanceLimit { get; set; }
        public double TotalCreditLimitUsed { get; set; }
        public double TotalDebitLimitUsed { get; set; }
        public double TotalBalanceLimitUsed { get; set; }
        public double TotalCreditLimitLeft { get; set; }
        public double TotalDebitLimitLeft { get; set; }
        public double TotalBalanceLimitLeft { get; set; }
        public double TotalCreditLimitLeftPercent { get; set; }
        public double TotalDebitLimitLeftPercent { get; set; }
        public double TotalBalanceLimitLeftPercent { get; set; }

        protected MasterClient()
        {
        }

        public MasterClient(
            Guid id
        ) : base(id)
        {
         
        }

    public MasterClient(
        Guid id,
        int? sourceId,
        int? sourceRefId,
        string sourceRefGuid,
        string tCKN_VN,
        string title,
        string title2,
        string name,
        string surname,
        string taxOffice,
        int? taxOfficeId,
        string country,
        Guid countryId,
        string city,
        int? cityId,
        Guid priceListId,
        Guid categoryId,
        string town,
        int? townId,
        int? exchangeRateCalculation,
        string buildingName,
        string buildingNumber,
        string doorNumber,
        string postCode,
        string streetName,
        string email,
        string phone,
        string fax,
        string webAddress,
        string address,
        string sourceCode,
        System.DateTime? sourceLastUpdate,
        Guid? tenantId,
        double totalCredit,
        double totalDebit,
        double totalBalance,
        double totalCreditLimit,
        double totalDebitLimit,
        double totalBalanceLimit,
        double totalCreditLimitUsed,
        double totalDebitLimitUsed,
        double totalBalanceLimitUsed,
        double totalCreditLimitLeft,
        double totalDebitLimitLeft,
        double totalBalanceLimitLeft,
        double totalCreditLimitLeftPercent,
        double totalDebitLimitLeftPercent,
        double totalBalanceLimitLeftPercent
    ) : base(id)
    {
        SourceId = sourceId;
        SourceRefId = sourceRefId;
        SourceRefGuid = sourceRefGuid;
        TCKN_VN = tCKN_VN;
        Title = title;
        Title2 = title2;
        Name = name;
        Surname = surname;
        TaxOffice = taxOffice;
        TaxOfficeId = taxOfficeId;
        Country = country;
        CountryId = countryId;
        City = city;
        CityId = cityId;
        PriceListId = priceListId;
        CategoryId = categoryId;
        Town = town;
        TownId = townId;
        ExchangeRateCalculation = exchangeRateCalculation;
        BuildingName = buildingName;
        BuildingNumber = buildingNumber;
        DoorNumber = doorNumber;
        PostCode = postCode;
        StreetName = streetName;
        Email = email;
        Phone = phone;
        Fax = fax;
        WebAddress = webAddress;
        Address = address;
        SourceCode = sourceCode;
        SourceLastUpdate = sourceLastUpdate;
        TenantId = tenantId;
        TotalCredit = totalCredit;
        TotalDebit = totalDebit;
        TotalBalance = totalBalance;
        TotalCreditLimit = totalCreditLimit;
        TotalDebitLimit = totalDebitLimit;
        TotalBalanceLimit = totalBalanceLimit;
        TotalCreditLimitUsed = totalCreditLimitUsed;
        TotalDebitLimitUsed = totalDebitLimitUsed;
        TotalBalanceLimitUsed = totalBalanceLimitUsed;
        TotalCreditLimitLeft = totalCreditLimitLeft;
        TotalDebitLimitLeft = totalDebitLimitLeft;
        TotalBalanceLimitLeft = totalBalanceLimitLeft;
        TotalCreditLimitLeftPercent = totalCreditLimitLeftPercent;
        TotalDebitLimitLeftPercent = totalDebitLimitLeftPercent;
        TotalBalanceLimitLeftPercent = totalBalanceLimitLeftPercent;
    }
    }
}
