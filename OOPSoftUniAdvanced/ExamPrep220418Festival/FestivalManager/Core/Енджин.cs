
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;

	/// <summary>
	/// by g0shk0
	/// </summary>
	class Енджин : IEngine
	{
	    public IReader chetаch;
	    public IWriter pisаch;

		public IFestivalController festivalCоntroller = new FestivalController();
		public ISetController setCоntroller = new SetController();

		// дайгаз
		public void Запали()
		{
			while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) // for job security
			{
				var input = chetach.ReadLine();

				if (input == "END")
					break;

				try
				{
					string.Intern(input);

					var result = this.DoCommand(input);
					this.pisach.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.pisach.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalController.Report();

			this.pisach.WriteLine("Results:");
			this.pisach.WriteLine(end);
		}

		public string DoCommand(string input)
		{
			var chasti = input.Split(" ".ToCharArray().First());

			var purvoto = chasti.First();
			var parametri = chasti.Skip(1).ToArray();

			if (purvoto == "LetsRock")
			{
				var setovete = this.setController.PerformSets();
				return setovete;
			}

			var festivalcontrolfunction = this.festivalController.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == purvoto);

			string a;

			try
			{
				a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parametri });
			}
			catch (TargetInvocationException up)
			{
				throw up; // ha ha
			}

			return a;
		}
	}
}