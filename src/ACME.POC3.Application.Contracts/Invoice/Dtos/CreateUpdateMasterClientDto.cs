using System;

namespace ACME.POC3.Invoice.Dtos;

[Serializable]
public class CreateUpdateMasterClientDto
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
}