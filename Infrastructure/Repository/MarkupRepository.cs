using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class MarkupRepository : IMarkupRepository
    {
        public Task<int> Count(Markup item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Markup> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Markup>> Get(Markup item, int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Insert(Markup item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Markup item)
        {
            throw new NotImplementedException();
        }
    }
}
