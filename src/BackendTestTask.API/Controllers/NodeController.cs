using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BackendTestTask.BusinessLogic.Services;
using BackendTestTask.API.Contracts.Requests;
using BackendTestTask.API.Contracts.Responses.Nodes;

namespace BackendTestTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NodeController : ControllerBase
{
    private readonly INodeService _nodeService;
    private readonly IMapper _mapper;

    public NodeController(INodeService nodeService, IMapper mapper)
    {
        _nodeService = nodeService;
        _mapper = mapper;
    }

    [HttpPost("create", Name = nameof(CreateNode))]
    public async Task<IResult> CreateNode([FromBody] CreateNodeRequest request, CancellationToken cancellationToken)
    {
        var newId = await _nodeService.Add(request.TreeId, request.Name, request.ParentNodeId, cancellationToken);

        return TypedResults.Created("CreateNode", newId);
    }

    [HttpGet("{id:guid}", Name = nameof(GetNodeById))]
    public async Task<IResult> GetNodeById(Guid id, CancellationToken cancellationToken)
    {
        var node = await _nodeService.GetById(id, cancellationToken);

        return TypedResults.Ok(node);
    }

    [HttpGet("tree/{treeId:guid}", Name = nameof(GetNodesByTreeId))]
    public async Task<IResult> GetNodesByTreeId(Guid treeId, CancellationToken cancellationToken)
    {
        var nodes = await _nodeService.GetRangeByTreeId(treeId, cancellationToken);

        return TypedResults.Ok(nodes);
    }

    [HttpDelete("{id:guid}", Name = nameof(RemoveNode))]
    public async Task<IResult> RemoveNode(Guid id, CancellationToken cancellationToken)
    {
        await _nodeService.Remove(id, cancellationToken);

        var response = new RemoveNodeResponse
        {
            Success = true,
            Message = "Node removed successfully"
        };

        return TypedResults.Ok(response);
    }
}
