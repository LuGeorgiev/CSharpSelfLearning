namespace Forum.App.Models
{
	using Contracts;
	using DataModels;

	public class Session : ISession
	{
		public string Username => throw new System.NotImplementedException();

		public int UserId => throw new System.NotImplementedException();

		public bool IsLoggedIn => throw new System.NotImplementedException();

		public IMenu CurrentMenu => throw new System.NotImplementedException();

		public IMenu Back()
		{
			throw new System.NotImplementedException();
		}

		public void LogIn(User user)
		{
			throw new System.NotImplementedException();
		}

		public void LogOut()
		{
			throw new System.NotImplementedException();
		}

		public bool PushView(IMenu view)
		{
			throw new System.NotImplementedException();
		}

		public void Reset()
		{
			throw new System.NotImplementedException();
		}
	}
}
