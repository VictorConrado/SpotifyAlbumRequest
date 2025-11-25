using Refit;

public interface IAlbumSpotifyClient
{
    [Get("/v1/browse/new-releases")]
    Task<AlbumResponse> GetReleases([Header("Authorization")] string token);
}
