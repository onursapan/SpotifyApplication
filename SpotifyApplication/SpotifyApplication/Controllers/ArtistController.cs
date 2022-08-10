using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyApplication.Common;
using SpotifyApplication.Dtos.Requests;
using SpotifyApplication.Dtos.Responses;
using SpotifyApplication.Services.Artists.Interfaces;

namespace SpotifyApplication.Controllers;

public class ArtistController : BaseController
{
    private IArtistService _artistService;

    public ArtistController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [Route("artists")]
    [HttpGet]
    public JsonResult GetArtistList(string spotifyId)
    {
        var response = _artistService.GetArtistList(spotifyId);
        return new JsonResult(new OperationResult<List<ArtistResponse>>(response));
    }
    
    [Route("get-artistbyid")]
    [HttpGet]
    public async Task<JsonResult> GetArtistById(int artistId)
    {
        var response = await _artistService.GetArtistById(artistId);
        return new JsonResult(new OperationResult<ArtistResponse?>(response));
    }
    
    
    [Route("create-artist")]
    [HttpPost]
    public async Task<JsonResult> CreateArtist(CreateArtistRequest request)
    {
        var response = await _artistService.CreateArtist(request);
        return new JsonResult(new OperationResult<bool>(response));
    }
}


