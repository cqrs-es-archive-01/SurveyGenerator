using SurveyGenerator.Core.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SurveyGenerator.Core.Data
{
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity FindByKey(Guid id);
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}

