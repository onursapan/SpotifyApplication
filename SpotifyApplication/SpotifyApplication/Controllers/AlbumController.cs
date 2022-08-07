using Microsoft.AspNetCore.Mvc;
using SpotifyApplication.Common;
using SpotifyApplication.Domain.Albums;
using SpotifyApplication.Dtos.Requests;
using SpotifyApplication.Dtos.Responses;
using SpotifyApplication.Services.Albums.Interfaces;

namespace SpotifyApplication.Controllers;

public class AlbumController : BaseController
{
    #region Field(s)
    private IAlbumService _albumService;
    #endregion

    #region Ctor(s)
    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }
    #endregion

    #region Method(s)
    [Route("get-albums")]
    [HttpGet]
    public async Task<JsonResult> GetAlbumList()
    {
        var response = await _albumService.GetAlbumList();
        return new JsonResult(new OperationResult<List<AlbumResponse>?>(response));
    }
    
    [Route("get-albumbyid")]
    [HttpGet]
    public async Task<JsonResult> GetAlbumById(int albumId)
    {
        var response = await _albumService.GetAlbumById(albumId);
        return new JsonResult(new OperationResult<AlbumResponse?>(response));
    }
    
    [Route("create-album")]
    [HttpPost]
     public async Task<JsonResult> CreateAlbum(CreateAlbumRequest request)
    {
        var response = await _albumService.CreateAlbum(request);
        return new JsonResult(new OperationResult<bool>(response));
    }
    #endregion

}