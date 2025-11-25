using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpotifyAlbumRequestBackEnd.Models;


[ApiController]
[Route("spotify/api")]
public class AlbumController : ControllerBase
{
    private readonly IAuthSpotifyClient _authSpotifyClient;
    private readonly IAlbumSpotifyClient _albumSpotifyClient;

    public AlbumController(
        IAuthSpotifyClient authSpotifyClient,
        IAlbumSpotifyClient albumSpotifyClient)
    {
        _authSpotifyClient = authSpotifyClient;
        _albumSpotifyClient = albumSpotifyClient;
    }

    [HttpGet("albums")]
    public async Task<IActionResult> GetAlbums([FromServices] IOptions<SpotifySettings> spotifyOptions)
    {
        var settings = spotifyOptions.Value;

        var request = new LoginRequest
        {
            GrantType = "client_credentials",
            ClientId = settings.ClientId,
            ClientSecret = settings.ClientSecret
        };

        var login = await _authSpotifyClient.Login(request);
        var token = login.AccessToken;

        var response = await _albumSpotifyClient.GetReleases($"Bearer {token}");

        return Ok(response.Albums.Items);
    }
}
