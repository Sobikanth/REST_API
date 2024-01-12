using Domain.DTOs;

namespace Domain.Services;

public interface ICountryDbService
{
    Task<CountryDto> GetCountryByIdAsync(int id);
    Task<List<CountryDto>> GetAllAsync();
    Task<int> CreateOrUpdateAsync(CountryDto country);
    Task<bool> UpdateDescriptionAsync(int id, string description);
    Task<bool> DeleteAsync(int id);
    Task LongRunningQueryAsync(CancellationToken cancellationToken);
}