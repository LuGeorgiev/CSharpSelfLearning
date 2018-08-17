namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : ConcertSet
	{
		public Medium(string name)
			: base(name)
		{
			this.Name=name;
			this.MaxDuration=new TimeSpan(0, 0b101001, 0);
		}
	}
}