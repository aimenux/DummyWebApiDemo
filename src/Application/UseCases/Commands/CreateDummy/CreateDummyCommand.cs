using MediatR;

namespace Application.UseCases.Commands.CreateDummy;

public record CreateDummyCommand(string Name) : IRequest<CreateDummyCommandResponse>;