
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
	public class Engine : IEngine
	{
        //was public
	    private  IReader reader;
	    private  IWriter writer;
         
		private  IFestivalController festivalCоntroller;
		private  ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntrolle, ISetController setCоntrolle)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntrolle;
            this.setCоntroller = setCоntrolle;
        }

		
		public void Run()
		{
			while (true) 
			{
				var input = reader.ReadLine();

                if (input == "END")
                {
                    Environment.Exit(0);
					//break;
                }

				try
				{
					
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) 
				{
					this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
				}
			}
			
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split(' ').ToArray();

			var command = tokens.First();
			var arguments = tokens.Skip(1).ToArray();
            string result = null;

			if (command == "LetsRock")
			{
                result = this.setCоntroller.PerformSets();
				return result;
			}

			var commandInfo = this.festivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == command);

            result = (string)commandInfo.Invoke(this.festivalCоntroller, new object[] { arguments });		

			return result;
		}
	}
}