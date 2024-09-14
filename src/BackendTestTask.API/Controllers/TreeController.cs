using AutoMapper;
using BackendTestTask.API.Contracts.Requests.Trees;
using BackendTestTask.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendTestTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreeController : Controller
{
    private readonly IMapper _mapper;
    private readonly ITreeService _treeService;

    public TreeController(IMapper mapper,
        ITreeService treeService)
    {
        _mapper = mapper;
        _treeService = treeService;
    }

    [HttpPost("create", Name = nameof(CreateTree))]
    public async Task<IResult> CreateTree([FromBody] CreateTreeRequest request, CancellationToken cancellationToken)
    {
        var newId = await _treeService.Add(request.Name, cancellationToken);

        return TypedResults.Created(nameof(CreateTree), newId);
    }

    [HttpGet("range", Name = nameof(GetRangeTrees))]
    public async Task<IResult> GetRangeTrees(CancellationToken cancellationToken)
    {
        var trees = await _treeService.GetRange(cancellationToken);

        return TypedResults.Ok(trees);
    }

    [HttpGet("{treeId:guid}/{depth:int}", Name = nameof(GetTree))]
    public async Task<IResult> GetTree(Guid treeId, int depth, CancellationToken cancellationToken)
    {
        var trees = await _treeService.GetRange(cancellationToken);

        return TypedResults.Ok(trees);
    }
}
