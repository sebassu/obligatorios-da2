using Domain;
using System.Data;
using System.Resources;

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
    }
}