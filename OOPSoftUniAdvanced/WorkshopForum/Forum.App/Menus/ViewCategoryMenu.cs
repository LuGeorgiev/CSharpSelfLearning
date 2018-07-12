namespace Forum.App.Menus
{
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	using Models;

	public class ViewCategoryMenu : Menu, IIdHoldingMenu, IPaginatedMenu
	{
		private const int pageSize = 10;
		private const int categoryNameLength = 36;

		private ILabelFactory labelFactory;
		private IPostService postService;

		private int categoryId;
		private int currentPage;
		private IPostInfoViewModel[] posts;

		//TODO: Inject Dependencies

		private int LastPage => throw new System.NotImplementedException();

		private bool IsFirstPage => throw new System.NotImplementedException();

		private bool IsLastPage => throw new System.NotImplementedException();

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			string categoryName = this.postService.GetCategoryName(this.categoryId);

			string[] labelContent = new string[] { categoryName, "Name", "Replies" };
			Position[] labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // Category name
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left + 12, consoleCenter.Top - 10), // Replies
            };

			this.Labels = new ILabel[labelContent.Length];

			for (int i = 0; i < this.Labels.Length; i++)
			{
				this.Labels[i] = this.labelFactory.CreateLabel(labelContent[i], labelPositions[i]);
			}
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			string[] defaultButtonContent = new string[] { "Back", "Previous Page", "Next Page" };
			Position[] defaultButtonPositions = new Position[]
			{
				new Position(consoleCenter.Left + 15, consoleCenter.Top - 12), // Back   
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 12), // Previous Page
                new Position(consoleCenter.Left + 10, consoleCenter.Top + 12), // Next Page
            };

			Position[] categoryButtonPositions = new Position[pageSize];

			for (int i = 0; i < pageSize; i++)
			{
				categoryButtonPositions[i] = new Position(consoleCenter.Left - 18, consoleCenter.Top - 8 + i * 2);
			}

			IList<IButton> buttons = new List<IButton>();
			buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[0], defaultButtonPositions[0]));

			for (int i = 0; i < categoryButtonPositions.Length; i++)
			{
				IPostInfoViewModel post = null;

				int categoryIndex = i + this.currentPage * pageSize;

				if (categoryIndex < this.posts.Length)
				{
					post = this.posts[categoryIndex];
				}

				string postsCount = post?.ReplyCount.ToString();
				string buffer = new string(' ', categoryNameLength - post?.Title.Length ?? 0 - postsCount?.Length ?? 0);
				string buttonText = post?.Title + buffer + postsCount;

				IButton button = this.labelFactory.CreateButton(buttonText, categoryButtonPositions[i], post == null);

				buttons.Add(button);
			}

			buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[1], defaultButtonPositions[1], this.IsFirstPage));
			buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[2], defaultButtonPositions[2], this.IsLastPage));

			this.Buttons = buttons.ToArray();
		}

		public override IMenu ExecuteCommand()
		{
			throw new System.NotImplementedException();
		}

		public void ChangePage(bool forward = true)
		{
			throw new System.NotImplementedException();
		}

		public void SetId(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
