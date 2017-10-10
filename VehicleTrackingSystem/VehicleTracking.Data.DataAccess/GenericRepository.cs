using System;
using System.Resources;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain;

[assembly: NeutralResourcesLanguage("es")]
namespace Persistence
{
    internal abstract class GenericRepository<TEntity> where TEntity : class
    {
        protected VTSystemContext context;
        protected DbSet<TEntity> elements;

        public GenericRepository(VTSystemContext someContext)
        {
            context = someContext;
            elements = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetElementsWith(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = elements;
            AddWhereStatement(filter, ref query);
            AddIncludeProperties(includeProperties, ref query);
            return query.ToList();
        }

        private static void AddWhereStatement(Expression<Func<TEntity, bool>> filter,
            ref IQueryable<TEntity> query)
        {
            if (Utilities.IsNotNull(filter))
            {
                query = query.Where(filter);
            }
        }

        private static void AddIncludeProperties(string includeProperties,
            ref IQueryable<TEntity> query)
        {
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        protected virtual TEntity GetById(object id)
        {
            return elements.Find(id);
        }

        protected void Add(TEntity elementToAdd)
        {
            ValidateParameterIsNotNull(elementToAdd);
            elements.Add(elementToAdd);
        }

        private void ValidateParameterIsNotNull(TEntity elementToAdd)
        {
            if (Utilities.IsNull(elementToAdd))
            {
                throw new RepositoryException(ErrorMessages.NullObjectRecieved);
            }
        }

        protected void AttemptToRemove(TEntity entityToRemove)
        {
            PerformActionIfElementExistsInCollection(entityToRemove,
                delegate
                {
                    AttachIfIsValid(entityToRemove);
                    elements.Remove(entityToRemove);
                });
        }

        protected void Update(TEntity entityToUpdate)
        {
            PerformActionIfElementExistsInCollection(entityToUpdate,
                delegate
                {
                    AttachIfIsValid(entityToUpdate);
                    context.Entry(entityToUpdate).State = EntityState.Modified;
                });
        }

        private void PerformActionIfElementExistsInCollection(TEntity element,
            Action actionToPerform)
        {
            if (ElementExistsInCollection(element))
            {
                actionToPerform.Invoke();
            }
            else
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        protected abstract bool ElementExistsInCollection(TEntity entityToUpdate);

        protected void AttachIfIsValid(TEntity element)
        {
            try
            {
                PerformAttachIfCorresponds(element);
            }
            catch (SystemException exception)
            {
                throw new RepositoryException("Error en base de datos. Detalles: "
                    + exception.Message);
            }
        }

        private void PerformAttachIfCorresponds(TEntity element)
        {
            if (context.Entry(element).State == EntityState.Detached)
            {
                elements.Attach(element);
            }
        }
    }
}