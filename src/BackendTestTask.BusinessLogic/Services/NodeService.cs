using AutoMapper;
using BackendTestTask.BusinessLogic.DTOs;
using BackendTestTask.BusinessLogic.Exceptions;
using BackendTestTask.BusinessLogic.Resources;
using BackendTestTask.BusinessLogic.Services;
using BackendTestTask.DataAccess.Builders;
using BackendTestTask.DataAccess.Data;
using BackendTestTask.DataAccess.Providers;
using BackendTestTask.DataAccess.Respositories;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.Application.Services;

public class NodeService : INodeService
{
    private readonly INodeProvider _nodeProvider;
    private readonly ITreeProvider _treeProvider;
    private readonly INodeRepository _nodeRepository;
    private readonly IDataContext _dataContext;
    private readonly IMapper _mapper;

    public NodeService(
        INodeProvider nodeProvider,
        ITreeProvider treeProvider,
        INodeRepository nodeRepository,
        IDataContext dataContext,
        IMapper mapper)
    {
        _nodeProvider = nodeProvider;
        _treeProvider = treeProvider;
        _nodeRepository = nodeRepository;
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<Guid> Add(Guid treeId, string name, Guid? parentNodeId, CancellationToken cancellationToken)
    {
        var treeExists = await _treeProvider.Get(treeId).AnyAsync(cancellationToken);

        SecureException.ThrowIfTrue(!treeExists, BusinessLogicExeptionNames.TreeNotFound);

        if (parentNodeId.HasValue)
        {
            var parentNodeExists = await _nodeProvider
                .Get(parentNodeId.Value)
                .AnyAsync(n => n.TreeId == treeId, cancellationToken);

            SecureException.ThrowIfTrue(!parentNodeExists, BusinessLogicExeptionNames.ParentNodeNotFound);
        }
        else
        {
            var isTreeHasNode = await _nodeProvider
                .GetRange()
                .Where(node => node.TreeId == treeId)
                .AnyAsync(cancellationToken);

            SecureException.ThrowIfTrue(isTreeHasNode, BusinessLogicExeptionNames.TreeAlreadyHasHeadNode);
        }

        var node = NodeBuilder.Build(treeId, name, parentNodeId);

        await _nodeRepository.Add(node, cancellationToken);

        await _dataContext.CommitChangesAsync(cancellationToken);

        return node.Id;
    }

    public async Task Remove(Guid nodeId, CancellationToken cancellationToken)
    {
        var node = await _nodeProvider.Get(nodeId).FirstOrDefaultAsync(cancellationToken);

        SecureException.ThrowIfNull(node, BusinessLogicExeptionNames.NodeNotFound);
        // Optionally, you might want to check for child nodes before deletion
        // and enforce rules such as requiring deletion of children first

        await _nodeRepository.Remove(node, cancellationToken);

        await _dataContext.CommitChangesAsync(cancellationToken);
    }

    public async Task<NodeDto?> GetById(Guid nodeId, CancellationToken cancellationToken)
    {
        var node = await _nodeProvider.Get(nodeId).FirstOrDefaultAsync(cancellationToken);

        return _mapper.Map<NodeDto?>(node);
    }

    public async Task<List<NodeDto>> GetRangeByTreeId(Guid treeId, CancellationToken cancellationToken)
    {
        var nodes = await _nodeProvider
            .GetRange()
            .Where(node => node.TreeId == treeId)
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<NodeDto>>(nodes);

        return dtos;
    }
}
