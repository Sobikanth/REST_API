using Domain.Services;

namespace BLL.Services;

public class StreamingService : IStreamingService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public StreamingService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<(Stream stream, string mimetype)> GetFileStream()
    {
        var client = _httpClientFactory.CreateClient();
        var stream = await client.GetStreamAsync("https://anthonygiretti.blob.core.windows.net/videos/earth.mp4");
        return (stream, "video/mp4");
    }
}