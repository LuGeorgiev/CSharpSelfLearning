namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Core;
    using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            var assembly = Assembly.GetCallingAssembly();
            var instrumentType = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (instrumentType == null)
            {
                throw new ArgumentException(string.Format(Constants.InstrumentNotFound, type));
            }
            if (!typeof(IInstrument).IsAssignableFrom(instrumentType))
            {
                throw new ArgumentException(string.Format(Constants.InstrumentIsNotInstrument, type));
            }

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType);
            return instrument;
        }
	}
}