using System.Reflection;
using Domain.Services;

namespace BLL.Services;

public class CountryService_For_BackgroundService : ICountryService_For_BackgroundService
{
    public async Task<(byte[], string, string)> GetFileAsync()
    {
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"beach.png");
        return (await File.ReadAllBytesAsync(path), "image/png", "beach.png");
    }

    public Task<bool> IngestFileAsync(Stream countryFileContent)
    {
        throw new NotImplementedException();
    }
}