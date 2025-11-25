using Refit;

public interface IGoogleClient
{
    [Get("/")]
    Task<string> HelloWorld();
}
