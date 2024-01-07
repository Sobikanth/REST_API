using Domain.DTOs;

namespace Domain.Services;

public interface ICountryService
{
    CountryDto GetCountryById(int id);
    List<CountryDto> GetAll(); //with a List<T> you can add and remove items, while with an IEnumerable<T> you can only iterate over the items
    int CreateOrUpdate(CountryDto country);
    bool UpdateDescription(int id, string description);
    bool Delete(int id);
    (
        byte[] fileContent,
        string mimeType,
        string fileName
        ) GetFile();
}