using System.Text.Json;
using Domain.DTOs;
using Domain.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace BLL.Services;

public class DistributedCachedCountryService : ICountryDbService
{
    private readonly ICountryDbService _countryDbService;
    private readonly IDistributedCache _distributedCache;
    public DistributedCachedCountryService(ICountryDbService countryDbService, IDistributedCache distributedCache)
    {
        _countryDbService = countryDbService;
        _distributedCache = distributedCache;
    }
    public Task<int> CreateOrUpdateAsync(CountryDto country)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CountryDto>> GetAllAsync(PagingDto paging)
    {
        var key = $"countries-{paging.PageIndex}-{paging.PageSize}";

        var cachedValue = await _distributedCache.GetStringAsync(key);
        if (cachedValue == null)
        {
            var data = await _countryDbService.GetAllAsync(paging);
            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(data), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
            });
            return data;
        }
        return JsonSerializer.Deserialize<List<CountryDto>>(cachedValue);
    }

    public Task<CountryDto> GetCountryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task LongRunningQueryAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateDescriptionAsync(int id, string description)
    {
        throw new NotImplementedException();
    }
}