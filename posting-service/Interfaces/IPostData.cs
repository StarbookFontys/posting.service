namespace posting_service.Interfaces
{
	public interface IPostData
	{
		public void CreatePost(string title, string desc, string date, string author);

		public List<Models.PostModel> GetUserPosts(string author); 
	}
}
