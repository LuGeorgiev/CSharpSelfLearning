using P10_TirePressureMonitoringSystem;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public interface IAlarm
    {
        bool AlarmOn { get; }

        void Check(ISensor _sensor, IRandomPsi _randPsi);
    }
}