using Domain;
using System.Data.Entity;

namespace Persistence
{
    internal class VTSystemDatabaseInitializer
        : DropCreateDatabaseIfModelChanges<VTSystemContext>
    {
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
            RegisterNewLocationToDatabase(context, LocationType.PORT, "Puerto de Montevideo");
            RegisterNewLocationToDatabase(context, LocationType.PORT, "Puerto de Punta del Este");
            RegisterNewLocationToDatabase(context, LocationType.PORT, "El puertito");
            RegisterNewLocationToDatabase(context, LocationType.PORT, "Pearl Harbor");
            RegisterNewLocationToDatabase(context, LocationType.PORT, "Puerto Ochenta Ochenta");
            RegisterNewLocationToDatabase(context, LocationType.YARD, "Patio para Inspecciones");
            RegisterNewLocationToDatabase(context, LocationType.YARD, "El patiecito");
            RegisterNewLocationToDatabase(context, LocationType.YARD, "Playa de estacionamiento");
            RegisterNewLocationToDatabase(context, LocationType.YARD, "Scotland Yard");
        }

        private static void RegisterNewLocationToDatabase(VTSystemContext context,
            LocationType someLocationType, string name)
        {
            Location locationToAdd = Location.CreateNewLocation(someLocationType, name);
            context.Locations.Add(locationToAdd);
        }
    }
}