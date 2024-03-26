using posting_service.Interfaces;

namespace posting_service.Business
{
	public class PostManager : IPostManager
	{
		private IPostData PostData;

		public PostManager(IPostData _PostData) { 
			PostData = _PostData;
		}

		public void CreatePost(string title, string desc, string date, string author)
		{
			PostData.CreatePost(title, desc, date, author);
		}

		public List<Models.PostModel> GetUserPosts(string author)
		{
			return PostData.GetUserPosts(author);
		}
	}
}
