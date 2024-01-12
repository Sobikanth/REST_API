using Domain.Repositories;

namespace Infrastructure.Http.Repositories;

public class MediaRepository : IMediaRepository
{
    private readonly IHttpClientFactory _httpClientFactory;
    public MediaRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<(byte[] Content, string MimeType)> GetCountryFlagContent(string countryShortName, CancellationToken cancellationToken)
    {
        byte[] fileBytes;
        using HttpClient client = _httpClientFactory.CreateClient();
        fileBytes = await client.GetByteArrayAsync($"https://anthonygiretti.blob.core.windows.net/countryflags/{countryShortName}.png", cancellationToken);

        var result = await Task.Run(() => "Hello There!");

        return (fileBytes, "image/png");
    }
}