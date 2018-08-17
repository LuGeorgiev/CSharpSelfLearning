namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
			if (type == "Drums")
			{
				return new Drums();
			}
			else if (type == "Guitar")
			{
				return new Guitar();
			}
			else
			{
				return new Microphone();
			}
		}
	}
}