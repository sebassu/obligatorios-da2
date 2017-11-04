using Domain;
using System.Data.Entity;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Persistence
{
    /* 
     * Since the methods in this class are executed only when the Entity Model changes, 
     * the methods in it are excluded from Code Coverage, as it was found these are not run
     * on a second test execution and therefore would be apparently (as result percentage 
     * would indicate) not covered by unit tests, when they actually are (see the 
     * "LocationRepositoryTests" class, for example).
     */
    internal class VTSystemDatabaseInitializer : DropCreateDatabaseIfModelChanges<VTSystemContext>
    {
        internal static readonly IReadOnlyCollection<Location> defaultSystemLocations =
            new List<Location> {
                Location.CreateNewLocation(LocationType.PORT, "Puerto de Montevideo"),
                Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este"),
                Location.CreateNewLocation(LocationType.PORT, "El puertito"),
                Location.CreateNewLocation(LocationType.PORT, "Pearl Harbor"),
                Location.CreateNewLocation(LocationType.PORT, "Puerto Ochenta Ochenta"),
                Location.CreateNewLocation(LocationType.YARD, "Patio para Inspecciones"),
                Location.CreateNewLocation(LocationType.YARD, "El patiecito"),
                Location.CreateNewLocation(LocationType.YARD, "Playa de estacionamiento"),
                Location.CreateNewLocation(LocationType.YARD, "Scotland Yard")
            }.AsReadOnly();

        internal static readonly User defaultAdministrator =
            User.CreateNewUser(UserRoles.ADMINISTRATOR, "The", "Administrator",
                "theAdministrator", "Victory", "099424242");

        internal static readonly Flow defaultFlow =
            Flow.FromSubzoneNames(new List<string>()
            { "Mecánica ligera", "Pintura", "Lavado" });

        [ExcludeFromCodeCoverage]
        protected override void Seed(VTSystemContext context)
        {
            context.Users.Add(defaultAdministrator);
            context.Flow.Add(defaultFlow);
            AddDefaultLocationsToDatabase(context);
            base.Seed(context);
        }

        [ExcludeFromCodeCoverage]
        private void AddDefaultLocationsToDatabase(VTSystemContext context)
        {
            context.Locations.AddRange(defaultSystemLocations);
        }
    }
}