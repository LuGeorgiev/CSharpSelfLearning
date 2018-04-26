
namespace Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelAvailable { get; }
        double FuelConsumption { get; }

        void AddFuel(double litters);
        void TravellDistance(double kilometers);
    }
}
