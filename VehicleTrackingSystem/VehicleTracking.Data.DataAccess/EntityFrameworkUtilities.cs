using System;
using System.Resources;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

[assembly: NeutralResourcesLanguage("es")]
namespace Persistence
{
    internal static class EntityFrameworkUtilities<TEntity> where TEntity : class
    {
        internal static void Add(VTSystemContext context, TEntity elementToAdd)
        {
            var elements = context.Set<TEntity>();
            elements.Add(elementToAdd);
            context.SaveChanges();
        }

        internal static void AttemptToRemove(TEntity elementToRemove,
            VTSystemContext context)
        {
            var elements = context.Set<TEntity>();
            elements.Remove(elementToRemove);
            context.SaveChanges();
        }

        public static void Update(TEntity entityToUpdate)
        {
            using (var context = new VTSystemContext())
            {
                try
                {
                    AttachIfIsValid(context, entityToUpdate);
                    context.Entry(entityToUpdate).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
                }
            }
        }

        internal static void AttachIfIsValid(VTSystemContext context, TEntity element)
        {
            var elements = context.Set<TEntity>();
            try
            {
                PerformAttachIfCorresponds(context, element, elements);
            }
            catch (SystemException exception)
            {
                throw new RepositoryException("Error en base de datos. Detalles: "
                    + exception.Message);
            }
        }

        private static void PerformAttachIfCorresponds(VTSystemContext context, TEntity element,
            DbSet<TEntity> elements)
        {
            if (context.Entry(element).State == EntityState.Detached)
            {
                elements.Attach(element);
            }
        }
    }
}