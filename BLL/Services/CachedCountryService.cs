using System.Net.Http.Headers;
using Domain.DTOs;
using Domain.Services;
using Microsoft.Extensions.Caching.Memory;

namespace BLL.Services;

public class CachedCountryService : ICountryDbService
{
    private readonly ICountryDbService _countryDbService;
    private readonly IMemoryCache _memoryCache;
    public CachedCountryService(ICountryDbService countryDbService, IMemoryCache memoryCache)
    {
        _countryDbService = countryDbService;
        _memoryCache = memoryCache;
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
        var cachedValue = await _memoryCache.GetOrCreateAsync($"countries-{paging.PageIndex}-{paging.PageSize}", async cacheEntry =>
        {
            cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
            return await _countryDbService.GetAllAsync(paging);
        });
        return cachedValue;
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