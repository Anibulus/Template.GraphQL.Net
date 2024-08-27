using Template.Core.Interfaces;
using Template.Infrastructure.Data;

namespace Template.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TemplateContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(TemplateContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _entities.SingleOrDefaultAsync(x=>x.Id == id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
        public async Task Delete(Guid id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}
