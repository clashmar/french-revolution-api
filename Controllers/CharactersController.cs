using french_revolution_api.Models;
using french_revolution_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace french_revolution_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController(ICharacterService characterService) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
    {
        var result = await characterService.GetAllCharactersAsync();
        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CharacterResponse>> GetCharacterById(int id)
    {
        var result = await characterService.GetCharacterByIdAsync(id);
        return result is null ? 
            NotFound("Unable to find character.") : 
            Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CharacterResponse>> CreateCharacterAsync(CharacterRequest character)
    {
        var result = await characterService.AddCharacterAsync(character);
        return result is null 
            ? BadRequest("Unable to create character.")
            : CreatedAtAction(
                nameof(GetCharacterById), 
                new { id = result.Id },
                result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CharacterResponse>> UpdateCharacterAsync(int id, CharacterRequest character)
    {
        var result = await characterService.UpdateCharacterAsync(id, character);
        return result is null
            ? NotFound("Unable to update character.")
            : Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteCharacterAsync(int id)
    {
        var deleted = await characterService.DeleteCharacterAsync(id);
        return deleted
            ? NoContent()
            : NotFound("Unable to delete character.");
    }
}  