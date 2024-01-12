using Domain.Repositories;
using Domain.DTOs;
using Infrastructure.SQL.Database;
using Infrastructure.SQL.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastructure.SQL.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly DemoContext _demoContext;
    public CountryRepository(DemoContext demoContext)
    {
        _demoContext = demoContext;
    }

    public async Task _LongRunningQueryAsync(CancellationToken cancellationToken)
    {
        await _demoContext.Database.ExecuteSqlRawAsync("WAITFOR DELAY '00:00:10'", cancellationToken: cancellationToken);
    }
    public async Task<int> _CreateAsync(CountryDto countryDto)
    {
        var CountryEntity = new CountryEntity
        {
            Name = countryDto.Name,
            Description = countryDto.Description,
            FlagUri = countryDto.FlagUri
        };
        await _demoContext.Countries.AddAsync(CountryEntity);
        await _demoContext.SaveChangesAsync();
        return CountryEntity.Id;
    }

    public async Task<int> _DeleteAsync(int id)
    {
        return await _demoContext.Countries.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<List<CountryDto>> _GetAllAsync()
    {
        return await _demoContext.Countries.AsNoTracking().Select(x => new CountryDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            FlagUri = x.FlagUri
        }).ToListAsync();
    }

    public async Task<CountryDto> _GetCountryByIdAsync(int id)
    {
        return await _demoContext.Countries.Where(x => x.Id == id).Select(x => new CountryDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            FlagUri = x.FlagUri
        }).FirstOrDefaultAsync();
    }

    public async Task<int> _UpdateAsync(CountryDto countryDto)
    {
        var countryEntity = new CountryDto
        {
            Id = countryDto.Id,
            Name = countryDto.Name,
            Description = countryDto.Description,
            FlagUri = countryDto.FlagUri
        };
        return await _demoContext.Countries.Where(x => x.Id == countryEntity.Id).ExecuteUpdateAsync(s =>
        s.SetProperty(p => p.Description, countryEntity.Description).SetProperty(p => p.FlagUri, countryEntity.FlagUri).SetProperty(p => p.Name, countryEntity.Name));
    }

    public async Task<int> _UpdateDescriptionAsync(int id, string description)
    {
        return await _demoContext.Countries.Where(x => x.Id == id).ExecuteUpdateAsync(s => s.SetProperty(p => p.Description, description));
    }
}