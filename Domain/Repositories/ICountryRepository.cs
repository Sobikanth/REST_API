using Domain.DTOs;

namespace Domain.Repositories;

public interface ICountryRepository
{
    Task<CountryDto> GetCountryByIdAsync(int id);
    Task<List<CountryDto>> GetAllAsync();
    Task<int> CreateAsync(CountryDto countryDto);
    Task<int> UpdateAsync(CountryDto countryDto);
    Task<int> UpdateDescriptionAsync(int id, string description);
    Task<int> DeleteAsync(int id);
}