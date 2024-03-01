using Api.Constants;
using Api.Presentation.Controllers.Dummies.V2.GetDummies;
using Application.UseCases.Queries.GetDummies;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Presentation.Controllers.Dummies.V2;

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

    [HttpGet]
    [SwaggerOperation(nameof(GetDummies))]
    public async Task<IActionResult> GetDummies(CancellationToken cancellationToken)
    {
        var request = new GetDummiesRequest();
        var query = _mapper.Map<GetDummiesQuery>(request);
        var queryResponse = await _sender.Send(query, cancellationToken);
        var apiResponse = _mapper.Map<GetDummiesResponse>(queryResponse);
        return Ok(apiResponse);
    }
}