using P10_TirePressureMonitoringSystem;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;        

        bool _alarmOn = false;

        public void Check(ISensor sensor, IRandomPsi randPsi)
        {
            double psiPressureValue = sensor.PopNextPressurePsiValue(randPsi);

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
