using Microsoft.AspNetCore.Mvc;
using NZWalks.WEB.Models;
using NZWalks.WEB.Models.DTO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace NZWalks.WEB.Controllers
{
	public class RegionsController1 : Controller
	{
		private readonly IHttpClientFactory httpClientFactory;

		public RegionsController1(IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			List<RegionsDto> response = new List<RegionsDto>();
			try
			{
				// Get All Regions from Web API
				var client = httpClientFactory.CreateClient();

				var httpResponseMessage = await client.GetAsync("https://localhost:7250/api/regions");

				httpResponseMessage.EnsureSuccessStatusCode();

				response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionsDto>>());

			}
			catch (Exception ex)
			{

			}

			return View(response);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddRegionViewModel model)
		{
			var client = httpClientFactory.CreateClient();

			var httpRequestMessage = new HttpRequestMessage()
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri("https://localhost:7250/api/regions"),
				Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
			};

			var httpResponseMessage = await client.SendAsync(httpRequestMessage);

			httpResponseMessage.EnsureSuccessStatusCode();

			var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionsDto>();

			if (response is not null)
			{
				return RedirectToAction("Index", "RegionsController1");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var client = httpClientFactory.CreateClient();

			var response = await client.GetFromJsonAsync<RegionsDto>($"https://localhost:7250/api/regions/{id.ToString()}");

			if (response is not null)
			{
				return View(response);
			}
			
			return View(null);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(RegionsDto request)
		{
			var client = httpClientFactory.CreateClient();

			var httpRequestMessage = new HttpRequestMessage()
			{
				Method = HttpMethod.Put,
				RequestUri = new Uri($"https://localhost:7250/api/regions/{request.Id}"),
				Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
			};

			var httpResponseMessage = await client.SendAsync(httpRequestMessage);
			httpResponseMessage.EnsureSuccessStatusCode();

			var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionsDto>();

			if (response is not null)
			{
				return RedirectToAction("Edit", "RegionsController1");
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Delete(RegionsDto request)
		{
			try
			{
				var client = httpClientFactory.CreateClient();
				var httpResponseMessage = await client.DeleteAsync($"https://localhost:7250/api/regions/{request.Id}");
				httpResponseMessage?.EnsureSuccessStatusCode();

				return RedirectToAction("Index", "RegionsController1");
			}
			catch (Exception ex)
			{

			}
			return View();
		}
	}
}
