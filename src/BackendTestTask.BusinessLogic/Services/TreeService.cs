using AutoMapper;
using BackendTestTask.BusinessLogic.DTOs;
using BackendTestTask.DataAccess.Builders;
using BackendTestTask.DataAccess.Data;
using BackendTestTask.DataAccess.Providers;
using BackendTestTask.DataAccess.Respositories;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.BusinessLogic.Services;

public class TreeService : ITreeService
{
    private readonly ITreeProvider _treeProvider;
    private readonly ITreeRepository _treeRepository;
    private readonly IDataContext _dataContext;
    private readonly IMapper _mapper;

    public TreeService(ITreeProvider treeProvider,
        ITreeRepository treeRepository,
        IDataContext dataContext,
        IMapper mapper)
    {
        _treeProvider = treeProvider;
        _treeRepository = treeRepository;
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<Guid> Add(string name, CancellationToken cancellationToken)
    {
        var node = TreeBuilder.Build(name);

        await _treeRepository.Add(node, cancellationToken);

        await _dataContext.CommitChangesAsync(cancellationToken);

        return node.Id;
    }

    public async Task<TreeDto?> Get(Guid treeId, CancellationToken cancellationToken)
    {
        var treeQuery = _treeProvider.Get(treeId);

        var tree = await treeQuery.FirstOrDefaultAsync(cancellationToken);

        var dto = _mapper.Map<TreeDto>(tree);

        return dto;
    }

    public async Task<List<TreeDto>> GetRange(CancellationToken cancellationToken)
    {
        var trees = await _treeProvider.GetRange()
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<TreeDto>>(trees);

        return dtos;
    }
}
