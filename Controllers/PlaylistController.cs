using System;
using Microsoft.AspNetCore.Mvc;
using Restful_APi.Models;
using Restful_APi.Services;

namespace Restful_APi.Controllers;
[Controller]
[Route("api/[controller]")]
public class PlaylistController : Controller
{
    private readonly MongoDBService _mongoDBService;
    public PlaylistController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }
    [HttpGet]
    public async Task<List<Playlist>> Get()
    {
        return await _mongoDBService.GetAsync();
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Playlist playlist)
    {
        await _mongoDBService.CreateAsync(playlist);
        return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string MovieId)
    {
        await _mongoDBService.AddToPlaylistAsync(id, MovieId);

        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return Ok();
    }
}