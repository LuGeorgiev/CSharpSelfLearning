namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage
	{
		// да си вкарват през полетата бе
		public readonly List<ISet> Sets;
		public readonly List<ISong> Songs;
		public readonly List<IPerformer> Performers;
	}
}
