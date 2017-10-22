using Domain;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace API.Services
{
    public class VehicleDTO
    {
        [Required]
        public VehicleType Type { get; set; }

        [Required]
        public string VIN { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public short Year { get; set; }

        public string CurrentStage { get; set; }

        public VehicleDTO() { }

        internal static VehicleDTO FromVehicle(Vehicle someVehicle)
        {
            return new VehicleDTO(someVehicle);
        }

        private VehicleDTO(Vehicle someVehicle) : this(someVehicle.Type, someVehicle.Brand,
            someVehicle.Model, someVehicle.Year, someVehicle.Color, someVehicle.VIN)
        {
            CurrentStage = someVehicle.CurrentStage.ToString();
        }

        public static VehicleDTO FromData(VehicleType type, string brand, string model,
           short year, string color, string VIN)
        {
            return new VehicleDTO(type, brand, model, year, color, VIN);
        }

        private VehicleDTO(VehicleType typeToSet, string brandToSet, string modelToSet,
            short yearToSet, string colorToSet, string VINToSet)
        {
            Type = typeToSet;
            Brand = brandToSet;
            Model = modelToSet;
            Year = yearToSet;
            Color = colorToSet;
            VIN = VINToSet;
        }

        internal Vehicle ToVehicle()
        {
            return Vehicle.CreateNewVehicle(Type, Brand,
                Model, Year, Color, VIN);
        }

        internal void SetDataToVehicle(Vehicle vehicleToModify)
        {
            vehicleToModify.Type = Type;
            vehicleToModify.Brand = Brand;
            vehicleToModify.Model = Model;
            vehicleToModify.Year = Year;
            vehicleToModify.Color = Color;
            vehicleToModify.VIN = VIN;
        }

        public override bool Equals(object obj)
        {
            VehicleDTO dtoToCompareAgainst = obj as VehicleDTO;
            if (Utilities.IsNotNull(dtoToCompareAgainst))
            {
                return VIN.Equals(dtoToCompareAgainst.VIN);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}