using AutoMapper;
using BackendTestTask.BusinessLogic.DTOs;
using BackendTestTask.BusinessLogic.Models;
using BackendTestTask.DataAccess.Builders;
using BackendTestTask.DataAccess.Data;
using BackendTestTask.DataAccess.Entities;
using BackendTestTask.DataAccess.Providers;
using BackendTestTask.DataAccess.Respositories;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.BusinessLogic.Services;
public class SecurityExceptionLogService : ISecurityExceptionLogService
{
    private readonly IDataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly ISecurityExceptionLogRepository _repository;
    private readonly ISecurityExceptionLogProvider _provider;

    public SecurityExceptionLogService(IDataContext dataContext,
        IMapper mapper,
        ISecurityExceptionLogRepository repository,
        ISecurityExceptionLogProvider provider)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _repository = repository;
        _provider = provider;
    }

    public async Task<Guid> Add(SecurityExceptionLogCreateModel createModel, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<SecurityExceptionLog>(createModel);
        entity.Data = SecurityExceptionLogDataBuilder.Build(createModel.ExeptionMessage);

        await _repository.Add(entity, cancellationToken);
        await _dataContext.CommitChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<List<SecurityExceptionLogDto>> GetRange(CancellationToken cancellationToken = default)
    {
        var query = _provider.Get()
            .OrderByDescending(log => log.CreatedAtUtc);

        var dtos = await query
            .Select(log => _mapper.Map<SecurityExceptionLogDto>(log))
            .ToListAsync(cancellationToken);

        return dtos;
    }
}
