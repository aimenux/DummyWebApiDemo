using Api.Constants;
using Api.Presentation.Controllers.Dummies.V1.CreateDummy;
using Api.Presentation.Controllers.Dummies.V1.GetDummy;
using Application.UseCases.Commands.CreateDummy;
using Application.UseCases.Queries.GetDummy;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Presentation.Controllers.Dummies.V1;

[ApiVersion(ApiConstants.Versions.V1)]
[ApiVersion(ApiConstants.Versions.V2)]
public class DummiesController : BaseController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    private readonly ILogger<DummiesController> _logger;

    public DummiesController(ISender sender, IMapper mapper, ILogger<DummiesController> logger)
    {
        _sender = sender;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet("{dummyId}")]
    [SwaggerOperation(nameof(GetDummy))]
    public async Task<IActionResult> GetDummy(string dummyId, CancellationToken cancellationToken)
    {
        var request = new GetDummyRequest(dummyId);
        var query = _mapper.Map<GetDummyQuery>(request);
        var queryResponse = await _sender.Send(query, cancellationToken);
        var apiResponse = _mapper.Map<GetDummyResponse>(queryResponse);
        return Ok(apiResponse);
    }
    
    [HttpPost]
    [SwaggerOperation(nameof(CreateDummy))]
    public async Task<IActionResult> CreateDummy([FromBody] CreateDummyRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateDummyCommand>(request);
        var commandResponse = await _sender.Send(command, cancellationToken);
        var apiResponse = _mapper.Map<CreateDummyResponse>(commandResponse);
        return Created($"/v{ApiVersion}/dummies/{apiResponse.Id}", apiResponse);
    }
}