namespace WeatherForecast.Core.Interfaces
{
    public interface ISerialization
    {
        T Deserialise<T>(string source);

        string Serialise<T>(T objectToSerialize);
    }
}