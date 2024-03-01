using Application.Abstractions;
using Domain.Models.Entities;
using Domain.Models.ValueObjects;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class DummyRepository : IDummyRepository
{
    private readonly DummyDbContext _context;

    public DummyRepository(DummyDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Dummy>> GetDummiesAsync(CancellationToken cancellationToken)
    {
        var dummies = await _context.Set<Dummy>().ToListAsync(cancellationToken);
        return dummies;
    }

    public async Task<ICollection<Dummy>> SearchDummiesAsync(string keyword, CancellationToken cancellationToken)
    {
        var dummies = await _context.Set<Dummy>().ToListAsync(cancellationToken);
        var foundDummies = dummies
            .Where(x => x.Name.Value.Contains(keyword))
            .ToList();
        return foundDummies;
    }

    public async Task<Dummy?> GetDummyByIdAsync(DummyId id, CancellationToken cancellationToken)
    {
        var dummy = await _context.Set<Dummy>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return dummy;
    }

    public async Task<Dummy> AddDummyAsync(DummyName name, CancellationToken cancellationToken)
    {
        var id = new DummyId(Guid.NewGuid());
        var dummy = Dummy.CreateDummy(id, name);
        await _context.Set<Dummy>().AddAsync(dummy, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return dummy;
    }
}