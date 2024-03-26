namespace posting_service.Interfaces
{
	public interface IPostManager
	{
		public void CreatePost(string title, string desc, string date, string author);
	}
}
