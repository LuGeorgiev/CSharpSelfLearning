namespace FestivalManager.Entities.Instruments
{
    public class Bass : Instrument
    {
	    public int RepairAmountConst = 80;
	    public override int RepairAmount => RepairAmountConst;
    }
}
