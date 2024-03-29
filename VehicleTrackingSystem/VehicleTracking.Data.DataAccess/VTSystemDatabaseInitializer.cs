﻿using System.Data.Entity;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    internal class VTSystemDatabaseInitializer : DropCreateDatabaseIfModelChanges<VTSystemContext>
    {
        internal static readonly IReadOnlyCollection<Location> defaultSystemPorts =
            new List<Location> {
                Location.CreateNewLocation(LocationType.PORT, "Puerto de Montevideo"),
                Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este"),
                Location.CreateNewLocation(LocationType.PORT, "El puertito"),
                Location.CreateNewLocation(LocationType.PORT, "Pearl Harbor"),
                Location.CreateNewLocation(LocationType.PORT, "Puerto Ochenta Ochenta"),
            }.AsReadOnly();

        internal static readonly IReadOnlyCollection<Location> defaultSystemYards =
            new List<Location> {
                Location.CreateNewLocation(LocationType.YARD, "Patio para Inspecciones"),
                Location.CreateNewLocation(LocationType.YARD, "El patiecito"),
                Location.CreateNewLocation(LocationType.YARD, "Playa de estacionamiento"),
                Location.CreateNewLocation(LocationType.YARD, "Scotland Yard")
            }.AsReadOnly();

        internal static readonly User defaultAdministrator =
            User.CreateNewUser(UserRoles.ADMINISTRATOR, "The", "Administrator",
                "theAdministrator", "Victory", "099424242");

        internal static readonly Flow defaultFlow = Flow.FromSubzoneNames(
            new List<string>() { "Mecánica ligera", "Pintura", "Lavado" });

        protected override void Seed(VTSystemContext context)
        {
            context.Users.Add(defaultAdministrator);
            context.Flow.Add(defaultFlow);
            AddDefaultLocationsToDatabase(context);
            base.Seed(context);
        }

        private void AddDefaultLocationsToDatabase(VTSystemContext context)
        {
            context.Locations.AddRange(defaultSystemPorts);
            context.Locations.AddRange(defaultSystemYards);
        }
    }
}