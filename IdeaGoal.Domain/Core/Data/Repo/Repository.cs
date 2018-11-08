using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaGoal.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdeaGoal.Domain.Core.Data.Repo
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IEntity        
    {
        public IQueryable<TEntity> Table => _set.AsNoTracking();
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
            _db.Entry(entity).State = EntityState.Detached;
            return entity;
        }        

        public void UpdateRaw(string tableName, string statemant, Dictionary<string, object> values)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendLine($"UPDATE {tableName}");            
            string sets = string.Join(", ", values.Select(set =>
            {
                string strValue = set.Value.ToString();
                if (set.Value is string) strValue = $"'{strValue}'";
                return $"{set.Key} = {strValue}";
            }));
            queryBuilder.AppendLine($"SET {sets}");
            queryBuilder.AppendLine($"WHERE {statemant}");
            int updatedCount = _db.Database.ExecuteSqlCommand(queryBuilder.ToString());
            if (updatedCount == 0) throw new Exception("Update entity error.");
            _set.AsNoTracking();
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
            _db.SaveChanges();
        }
    }
}
