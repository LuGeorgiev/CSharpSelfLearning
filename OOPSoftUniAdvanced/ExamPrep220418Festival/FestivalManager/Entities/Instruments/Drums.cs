namespace FestivalManager.Entities.Instruments
{
	public class Drums : Instrument
	{
        private const int DrumRepairAmount = 20;

        protected override int RepairAmount => DrumRepairAmount;
    }
}
