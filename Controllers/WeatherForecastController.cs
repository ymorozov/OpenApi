using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OpenApiPoc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Annotations = new Dictionary<string, string>
                {
                    { "Key1", "Value1" },
                    { "Key2", "Value2" }
                },
                Fields = new List<BaseField> { GetField(), GetField(), GetField() }
            })
            .ToArray();
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public string Post([FromBody]PostResource resource)
        {
            return JsonConvert.SerializeObject(resource);
        }


        private BaseField GetField()
        {
            switch (Random.Shared.Next(0, 4))
            {
                case 0:
                    return new StringField { Value = "stringValue" };
                case 1:
                    return new IntegerField { Value = Random.Shared.Next(0, 200) };
                case 2:
                    return new DecimalField { Value = Random.Shared.Next(0, 200) };
                default:
                    return new LocationField { Location = new Point { X = Random.Shared.Next(0, 200), Y = Random.Shared.Next(0, 200) } };
            }
        }
    }
}
