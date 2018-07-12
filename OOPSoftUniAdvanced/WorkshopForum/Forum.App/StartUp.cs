namespace Forum.App
{
	using System;

	using Microsoft.Extensions.DependencyInjection;

	using Contracts;
	using Factories;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			IMainController menu = new MenuController(new LabelFactory(), new ForumViewEngine());

			Engine engine = new Engine(menu);
			engine.Run();
		}

		private static IServiceProvider ConfigureServices()
		{
			throw new System.NotImplementedException();
		}
	}
}
