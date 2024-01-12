using Refit;
namespace Domain.Repositories;

public interface IMediaRepository
{
    [Get("/countryflags/{countryShortName}.png")]
    Task<(byte[] Content, string MimeType)> GetCountryFlagContent(string countryShortName, CancellationToken cancellationToken);
}