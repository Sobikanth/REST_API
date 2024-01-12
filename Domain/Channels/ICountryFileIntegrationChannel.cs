namespace Domain.Channels;

public interface ICountryFileIntegrationChannel
{
    IAsyncEnumerable<Stream> _ReadAllAsync(CancellationToken cancellationToken);
    Task<bool> _SubmitAsync(Stream twilioRouteProgrammerParameters, CancellationToken cancellationToken);
}