using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using posting_service.DatabaseCom;
using posting_service.Business;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace posting_service.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		// GET: api/<PostController>
		[HttpGet]
		public Models.PostModel Get()
		{
			Models.PostModel ExamplePost = new Models.PostModel
			{
				title = "Docker is a very spooky program",
				Author = "Coen",
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
				postdate = Convert.ToString(DateTime.Today),
			};
			return ExamplePost;
		}
		
		// GET api/<PostController>/5
		[HttpGet("{title}/{description}")]
		public Models.PostModel Get(string title, string description)
		{
			Models.PostModel ExamplePost = new Models.PostModel
			{
				title = title,
				Author = "Coen",
				Description = description,
				postdate = Convert.ToString(DateTime.Today),
			};
			return ExamplePost;
		}

		[HttpGet("{author}")]
		public List<Models.PostModel> GetUserPosts(string author) 
		{
			Connection con = new Connection("Host=firstcluster-14261.8nj.gcp-europe-west1.cockroachlabs.cloud;Port=26257;Database=postsdb;Password=pM6WlZHYezsnKfLKdW5-Cw;SSL Mode=VerifyFull;Username=coen");
			PostData PostData = new PostData(con);
			PostManager Manager = new PostManager(PostData);

			return Manager.GetUserPosts(author);
		}

		// POST api/<PostController>
		[HttpPost("/P/{title}/{author}/{description}")]	
		public void Post(string title, string description, string author)
		{
			string DateFormat = DateTime.Today.ToString("yyyy-MM-dd");
			Connection con = new Connection("Host=firstcluster-14261.8nj.gcp-europe-west1.cockroachlabs.cloud;Port=26257;Database=postsdb;Password=pM6WlZHYezsnKfLKdW5-Cw;SSL Mode=VerifyFull;Username=coen");

			PostData PostData = new PostData(con);
			PostManager Manager = new PostManager(PostData);

			Manager.CreatePost(title, description, DateFormat, author);
		}

		// PUT api/<PostController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{

		}

		// DELETE api/<PostController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{

		}
	}
}
