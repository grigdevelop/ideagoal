using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IdeaGoal.Domain.Core.Data.Repo
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        public IQueryable<TEntity> Table => _set;
        private readonly DbContext _db;
        private readonly DbSet<TEntity> _set;

        public Repository(IdeaGoalDbContext db)
        {
            _db = db;
            _set = db.Set<TEntity>();
        }

        public TEntity Insert(TEntity entity)
        {
            _set.Add(entity);
            _db.SaveChanges();
            return entity;
        }
    }
}
