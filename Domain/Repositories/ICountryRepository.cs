using Domain.DTOs;

namespace Domain.Repositories;

public interface ICountryRepository
{
    Task<CountryDto> _GetCountryByIdAsync(int id);
    Task<List<CountryDto>> _GetAllAsync(PagingDto pagingDto);
    Task<int> _CreateAsync(CountryDto countryDto);
    Task<int> _UpdateAsync(CountryDto countryDto);
    Task<int> _UpdateDescriptionAsync(int id, string description);
    Task<int> _DeleteAsync(int id);
    Task _LongRunningQueryAsync(CancellationToken cancellationToken);

}