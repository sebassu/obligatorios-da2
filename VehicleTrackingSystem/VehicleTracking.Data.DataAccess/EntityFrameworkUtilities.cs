using Domain;
using System;
using System.Data;
using System.Resources;
using System.Data.Entity;


[assembly: NeutralResourcesLanguage("es")]
namespace Persistence
{
    internal static class EntityFrameworkUtilities<T> where T : class
    {
        internal static void Add(VTSystemContext context, T elementToAdd)
        {
            var elements = context.Set<T>();
            try
            {
                elements.Add(elementToAdd);
                context.SaveChanges();
            }
            catch (DataException exception)
            {
                throw new RepositoryException("Error en base de datos. Detalles: "
                    + exception.ToString());
            }
        }

        internal static void Remove(T elementToRemove)
        {
            using (var context = new VTSystemContext())
            {
                try
                {
                    var elements = context.Set<T>();
                    AttachIfIsValid(context, elementToRemove);
                    elements.Remove(elementToRemove);
                    context.SaveChanges();
                }
                catch (DataException exception)
                {
                    throw new RepositoryException("Error en base de datos. Detalles: "
                        + exception.Message);
                }
            }
        }

        internal static void AttachIfIsValid(VTSystemContext context, T element)
        {
            var elements = context.Set<T>();
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

        private static void PerformAttachIfCorresponds(VTSystemContext context, T element,
            DbSet<T> elements)
        {
            if (context.Entry(element).State == EntityState.Detached)
            {
                elements.Attach(element);
            }
        }
    }
}