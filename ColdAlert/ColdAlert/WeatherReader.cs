namespace ColdAlert
{
    public class WeatherReader
    {
        private readonly WeatherSource _weatherSource;

        public WeatherReader(WeatherSource weatherSource)
        {
            _weatherSource = weatherSource;
        }

        public string GetTemp(string period)
        {
            
            var weather = _weatherSource.GetWeatherData(period);

            return weather.ToString();
        }
    }
}
