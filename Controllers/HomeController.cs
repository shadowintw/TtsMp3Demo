using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TtsMp3Demo.Models;

namespace TtsMp3Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TtsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(TtsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Referrer = new Uri("https://ttsmp3.com/");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");

            var form = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("msg", model.Msg),
                new KeyValuePair<string,string>("lang", model.Lang)
            });

            var resp = await client.PostAsync("https://ttsmp3.com/makemp3_new.php", form);
            if (!resp.IsSuccessStatusCode)
            {
                model.Error = $"呼叫失敗：{resp.StatusCode}";
                return View(model);
            }

            using var doc = await JsonDocument.ParseAsync(await resp.Content.ReadAsStreamAsync());
            if (doc.RootElement.TryGetProperty("URL", out var urlProp))
                model.Mp3Url = urlProp.GetString();
            else
                model.Error = "回傳 JSON 沒有 URL 欄位";

            return View(model);
        }
    }
}
