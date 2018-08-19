namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private static readonly TimeSpan MaxDuration = new TimeSpan(0,40,0);
		public Medium(string name)
			: base(name, MaxDuration)
		{
			
		}
	}
}