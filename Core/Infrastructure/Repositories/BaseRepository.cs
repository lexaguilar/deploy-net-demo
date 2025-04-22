using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Core.Domain.Interfaces;
using TaskManagerAPI.Core.Infrastructure.Data;

namespace TaskManagerAPI.Core.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}