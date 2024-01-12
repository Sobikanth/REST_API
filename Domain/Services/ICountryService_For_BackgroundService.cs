using Domain.DTOs;

namespace Domain.Services;

public interface ICountryService_For_BackgroundService
{
    // Task<List<CountryDto>> GetAllAsync(PagingDto paging);
    // Task LongRunningQueryAsync(CancellationToken cancellationToken);
    Task<bool> IngestFileAsync(Stream countryFileContent);
    Task<(byte[], string, string)> GetFileAsync();
}