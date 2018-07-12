namespace Forum.App.Menus
{
	using System.Collections.Generic;

	using Models;
	using Contracts;

	public class AddReplyMenu : Menu, ITextAreaMenu, IIdHoldingMenu
    {
		private const int authorOffset = 8;
		private const int leftOffset = 18;
		private const int topOffset = 7;
		private const int buttonOffset = 14;

		private ILabelFactory labelFactory;
		private ITextAreaFactory textAreaFactory;
		private IForumReader reader;

		private bool error;
		private IPostViewModel post;

		//TODO: Inject Dependencies

		public ITextInputArea TextArea { get; private set; }

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			Position errorPosition = 
				new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 12);
			Position titlePosition =
				new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 10);
			Position authorPosition =
				new Position(consoleCenter.Left - this.post.Author.Length, consoleCenter.Top - 9);

			var labels = new List<ILabel>()
			{
				this.labelFactory.CreateLabel("Cannot add an empty reply!", errorPosition, !error),
				this.labelFactory.CreateLabel(this.post.Title, titlePosition),
				this.labelFactory.CreateLabel($"Author: {this.post.Author}", authorPosition),
			};

			int leftPosition = consoleCenter.Left - leftOffset;

			int lineCount = this.post.Content.Length;

			// Add post contents
			for (int i = 0; i < lineCount; i++)
			{
				Position position = new Position(leftPosition, consoleCenter.Top - (topOffset - i));
				ILabel label = this.labelFactory.CreateLabel(this.post.Content[i], position);
				labels.Add(label);
			}

			this.Labels = labels.ToArray();
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			int left = consoleCenter.Left + buttonOffset;
			int top = consoleCenter.Top - (topOffset - this.post.Content.Length);

			this.Buttons = new IButton[3];

			this.Buttons[0] = this.labelFactory.CreateButton("Write", new Position(left, top + 1));
			this.Buttons[1] = this.labelFactory.CreateButton("Submit", new Position(left - 1, top + 11));
			this.Buttons[2] = this.labelFactory.CreateButton("Back", new Position(left + 1, top + 12));
		}

		private void InitializeTextArea()
		{
			Position consoleCenter = Position.ConsoleCenter();

			int top = consoleCenter.Top - (topOffset + this.post.Content.Length) + 5;

			this.TextArea = this.textAreaFactory.CreateTextArea(this.reader, consoleCenter.Left - 18, top, false);
		}

		public void SetId(int id)
		{
			throw new System.NotImplementedException();
		}

		public override IMenu ExecuteCommand()
		{
			throw new System.NotImplementedException();
		}
	}
}
