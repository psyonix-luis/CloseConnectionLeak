using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CloseConnectionLeak.Controllers
{
	[Route("api/[controller]")]
	public class CloseController : Controller
	{
		HttpSender HttpSender;

		public CloseController(HttpSender httpSender) : base()
		{
			HttpSender = httpSender;
		}

		// GET api/close
		[HttpGet]
		public async Task<string> GetAsync()
		{
			var url = "test_post_url";
			var responseBody = await HttpSender.HttpPostAsync(url, "Body");
			return responseBody;
		}
	}
}
