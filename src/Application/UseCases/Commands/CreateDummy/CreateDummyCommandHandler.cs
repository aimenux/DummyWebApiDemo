using Application.Abstractions;
using Domain.Models.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.CreateDummy;

public class CreateDummyCommandHandler : IRequestHandler<CreateDummyCommand, CreateDummyCommandResponse>
{
    private readonly IDummyRepository _dummyRepository;

    public CreateDummyCommandHandler(IDummyRepository dummyRepository)
    {
        _dummyRepository = dummyRepository;
    }

    public async Task<CreateDummyCommandResponse> Handle(CreateDummyCommand request, CancellationToken cancellationToken)
    {
        var dummyName = new DummyName(request.Name);
        var dummy = await _dummyRepository.AddDummyAsync(dummyName, cancellationToken);
        var commandResponse = new CreateDummyCommandResponse(dummy);
        return commandResponse;
    }
}