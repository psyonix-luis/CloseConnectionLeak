using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CloseConnectionLeak
{
    public class HttpSender
    {
		public HttpClient Client;

		public HttpSender()
		{
			Client = new HttpClient();
			Client.DefaultRequestHeaders.ConnectionClose = true;
		}

		public async Task<String> HttpPostAsync(string url, string body)
		{
			HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url) ;
			using (var resp = await Client.SendAsync(requestMessage))
			{
				if (resp.IsSuccessStatusCode)
				{
					var val = await resp.Content.ReadAsStringAsync();
					return val;
				}
			}
			return "error";
		}
	}
}
