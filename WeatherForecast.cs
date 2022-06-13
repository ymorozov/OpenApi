namespace OpenApiPoc
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public IDictionary<string, string> Annotations { get; set; }

        public IList<BaseField> Fields { get; set; } 
    }
}
