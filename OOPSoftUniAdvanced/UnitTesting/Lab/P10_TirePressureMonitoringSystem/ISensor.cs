using P10_TirePressureMonitoringSystem;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public interface ISensor
    {
        double PopNextPressurePsiValue(IRandomPsi psi);

        //IRandomPsi Random_Psi { get; }
    }
}