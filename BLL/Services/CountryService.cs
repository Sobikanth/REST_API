using System.Reflection;
using Domain.DTOs;
using Domain.Services;
namespace BLL.Services;

public class CountryService : ICountryService
{
    private static List<CountryDto> _countries = new List<CountryDto>
    {
        new CountryDto
        {
            Id = 1,
            Name = "Canada",
            Description = "Maple Leaf country",
            FlagUri = "https://anthonygiretti.blob.core.windows.net/countryflags/ca.png"
        },
        new CountryDto
        {
            Id = 2,
            Name = "USA",
            Description = "Federal republic of 50 states",
            FlagUri = "https://anthonygiretti.blob.core.windows.net/countryflags/us.png"
        }
    };
    public int CreateOrUpdate(CountryDto country)
    {
        if (country?.Id is null)
            return 1000000000;

        var countryFound = _countries.FirstOrDefault(x => x.Id == country.Id);

        if (countryFound is null)
            return 1;

        return countryFound.Id;
    }

    public bool Delete(int id)
    {
        return true;
    }

    public List<CountryDto> GetAll()
    {
        return _countries;
    }

    public CountryDto GetCountryById(int id)
    {
        var country = _countries.FirstOrDefault(x => x.Id == id);
        if (country != null)
        {
            return country;
        }
        else
        {
            throw new Exception("Country not found.");
        }
    }

    public (byte[] fileContent, string mimeType, string fileName) GetFile()
    {
        string path = "/Users/m.sobikanth/Documents/Sobi/DotNet/ASP.NET/Dec_12_Learning_REST/BLL/countries.csv";
        return (File.ReadAllBytes(path), "text/csv", "countries.csv");
    }

    public bool UpdateDescription(int id, string description)
    {
        var country = _countries.FirstOrDefault(x => x.Id == id);
        if (country != null)
        {
            country.Description = description;
            return true;
        }
        return false;
    }
}