using Domain;
using System.Data.Entity;
using System.Collections.Generic;

namespace Persistence
{
    internal class VTSystemDatabaseInitializer
        : DropCreateDatabaseIfModelChanges<VTSystemContext>
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

        protected override void Seed(VTSystemContext context)
        {
            User defaultAdministrator = User.CreateNewUser(UserRoles.ADMINISTRATOR, "The",
                "Administrator", "theAdministrator", "Victory", "099424242");
            context.Users.Add(defaultAdministrator);
            AddDefaultLocationsToDatabase(context);
            base.Seed(context);
        }

        private void AddDefaultLocationsToDatabase(VTSystemContext context)
        {
            context.Locations.AddRange(defaultSystemLocations);
        }
    }
}