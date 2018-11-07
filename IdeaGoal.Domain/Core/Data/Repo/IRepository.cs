using System.Linq;

namespace IdeaGoal.Domain.Core.Data.Repo
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> Table { get; }

        TEntity Insert(TEntity entity);
    }
}
