using Domain.DTOs;
using Domain.Repositories;
using Domain.Services;

namespace BLL.Services;

public class CountryDbService : ICountryDbService
{
    private readonly ICountryRepository _countryRepository;
    public CountryDbService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    public async Task<int> CreateOrUpdateAsync(CountryDto country)
    {
        if (country?.Id is null)
        {
            return await _countryRepository._CreateAsync(country);
        }
        if (await _countryRepository._CreateAsync(country) > 0)
        {
            return country.Id;
        }
        return 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _countryRepository._DeleteAsync(id) > 0;
    }

    public async Task<List<CountryDto>> GetAllAsync()
    {
        return await _countryRepository._GetAllAsync();
    }

    public async Task<CountryDto> GetCountryByIdAsync(int id)
    {
        return await _countryRepository._GetCountryByIdAsync(id);
    }

    public Task LongRunningQueryAsync(CancellationToken cancellationToken)
    {
        return _countryRepository._LongRunningQueryAsync(cancellationToken);
    }

    public async Task<bool> UpdateDescriptionAsync(int id, string description)
    {
        return await _countryRepository._UpdateDescriptionAsync(id, description) > 0;
    }
}