using System;
using System.Linq;
using System.Threading.Tasks;
using ACME.POC3.Permissions;
using ACME.POC3.Invoice.Dtos;
using Volo.Abp.Application.Services;

namespace ACME.POC3.Invoice;


public class MasterClientAppService : CrudAppService<MasterClient, MasterClientDto, Guid, MasterClientGetListInput, CreateUpdateMasterClientDto, CreateUpdateMasterClientDto>,
    IMasterClientAppService
{
    protected override string GetPolicyName { get; set; } = POC3Permissions.MasterClient.Default;
    protected override string GetListPolicyName { get; set; } = POC3Permissions.MasterClient.Default;
    protected override string CreatePolicyName { get; set; } = POC3Permissions.MasterClient.Create;
    protected override string UpdatePolicyName { get; set; } = POC3Permissions.MasterClient.Update;
    protected override string DeletePolicyName { get; set; } = POC3Permissions.MasterClient.Delete;

    private readonly IMasterClientRepository _repository;

    public MasterClientAppService(IMasterClientRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<MasterClient>> CreateFilteredQueryAsync(MasterClientGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.SourceId != null, x => x.SourceId == input.SourceId)
            .WhereIf(input.SourceRefId != null, x => x.SourceRefId == input.SourceRefId)
            .WhereIf(!input.SourceRefGuid.IsNullOrWhiteSpace(), x => x.SourceRefGuid.Contains(input.SourceRefGuid))
            .WhereIf(!input.TCKN_VN.IsNullOrWhiteSpace(), x => x.TCKN_VN.Contains(input.TCKN_VN))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Title))
            .WhereIf(!input.Title2.IsNullOrWhiteSpace(), x => x.Title2.Contains(input.Title2))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.Surname.IsNullOrWhiteSpace(), x => x.Surname.Contains(input.Surname))
            .WhereIf(!input.TaxOffice.IsNullOrWhiteSpace(), x => x.TaxOffice.Contains(input.TaxOffice))
            .WhereIf(input.TaxOfficeId != null, x => x.TaxOfficeId == input.TaxOfficeId)
            .WhereIf(!input.Country.IsNullOrWhiteSpace(), x => x.Country.Contains(input.Country))
            .WhereIf(input.CountryId != null, x => x.CountryId == input.CountryId)
            .WhereIf(!input.City.IsNullOrWhiteSpace(), x => x.City.Contains(input.City))
            .WhereIf(input.CityId != null, x => x.CityId == input.CityId)
            .WhereIf(input.PriceListId != null, x => x.PriceListId == input.PriceListId)
            .WhereIf(input.CategoryId != null, x => x.CategoryId == input.CategoryId)
            .WhereIf(!input.Town.IsNullOrWhiteSpace(), x => x.Town.Contains(input.Town))
            .WhereIf(input.TownId != null, x => x.TownId == input.TownId)
            .WhereIf(input.ExchangeRateCalculation != null, x => x.ExchangeRateCalculation == input.ExchangeRateCalculation)
            .WhereIf(!input.BuildingName.IsNullOrWhiteSpace(), x => x.BuildingName.Contains(input.BuildingName))
            .WhereIf(!input.BuildingNumber.IsNullOrWhiteSpace(), x => x.BuildingNumber.Contains(input.BuildingNumber))
            .WhereIf(!input.DoorNumber.IsNullOrWhiteSpace(), x => x.DoorNumber.Contains(input.DoorNumber))
            .WhereIf(!input.PostCode.IsNullOrWhiteSpace(), x => x.PostCode.Contains(input.PostCode))
            .WhereIf(!input.StreetName.IsNullOrWhiteSpace(), x => x.StreetName.Contains(input.StreetName))
            .WhereIf(!input.Email.IsNullOrWhiteSpace(), x => x.Email.Contains(input.Email))
            .WhereIf(!input.Phone.IsNullOrWhiteSpace(), x => x.Phone.Contains(input.Phone))
            .WhereIf(!input.Fax.IsNullOrWhiteSpace(), x => x.Fax.Contains(input.Fax))
            .WhereIf(!input.WebAddress.IsNullOrWhiteSpace(), x => x.WebAddress.Contains(input.WebAddress))
            .WhereIf(!input.Address.IsNullOrWhiteSpace(), x => x.Address.Contains(input.Address))
            .WhereIf(!input.SourceCode.IsNullOrWhiteSpace(), x => x.SourceCode.Contains(input.SourceCode))
            .WhereIf(input.SourceLastUpdate != null, x => x.SourceLastUpdate == input.SourceLastUpdate)
            .WhereIf(input.TotalCredit != null, x => x.TotalCredit == input.TotalCredit)
            .WhereIf(input.TotalDebit != null, x => x.TotalDebit == input.TotalDebit)
            .WhereIf(input.TotalBalance != null, x => x.TotalBalance == input.TotalBalance)
            .WhereIf(input.TotalCreditLimit != null, x => x.TotalCreditLimit == input.TotalCreditLimit)
            .WhereIf(input.TotalDebitLimit != null, x => x.TotalDebitLimit == input.TotalDebitLimit)
            .WhereIf(input.TotalBalanceLimit != null, x => x.TotalBalanceLimit == input.TotalBalanceLimit)
            .WhereIf(input.TotalCreditLimitUsed != null, x => x.TotalCreditLimitUsed == input.TotalCreditLimitUsed)
            .WhereIf(input.TotalDebitLimitUsed != null, x => x.TotalDebitLimitUsed == input.TotalDebitLimitUsed)
            .WhereIf(input.TotalBalanceLimitUsed != null, x => x.TotalBalanceLimitUsed == input.TotalBalanceLimitUsed)
            .WhereIf(input.TotalCreditLimitLeft != null, x => x.TotalCreditLimitLeft == input.TotalCreditLimitLeft)
            .WhereIf(input.TotalDebitLimitLeft != null, x => x.TotalDebitLimitLeft == input.TotalDebitLimitLeft)
            .WhereIf(input.TotalBalanceLimitLeft != null, x => x.TotalBalanceLimitLeft == input.TotalBalanceLimitLeft)
            .WhereIf(input.TotalCreditLimitLeftPercent != null, x => x.TotalCreditLimitLeftPercent == input.TotalCreditLimitLeftPercent)
            .WhereIf(input.TotalDebitLimitLeftPercent != null, x => x.TotalDebitLimitLeftPercent == input.TotalDebitLimitLeftPercent)
            .WhereIf(input.TotalBalanceLimitLeftPercent != null, x => x.TotalBalanceLimitLeftPercent == input.TotalBalanceLimitLeftPercent)
            ;
    }
}
