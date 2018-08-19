namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
        private static readonly TimeSpan MaxDuration = new TimeSpan(0, 15, 0);

		public Short(string name) 
			: base(name, MaxDuration)
		{
		}
	}
}