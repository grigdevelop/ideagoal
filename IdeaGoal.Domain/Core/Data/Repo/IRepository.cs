using System.Collections.Generic;
using System.Linq;
using IdeaGoal.Domain.Core.Entities;

namespace IdeaGoal.Domain.Core.Data.Repo
{
    public interface IRepository<TEntity> where TEntity: IEntity
    {
        IQueryable<TEntity> Table { get; }

        TEntity Insert(TEntity entity);

        void UpdateRaw(string tableName, string statemant, Dictionary<string, object> values);

        void Delete(TEntity entity);
    }
}
