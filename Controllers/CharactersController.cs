using french_revolution_api.Models;
using french_revolution_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace french_revolution_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController(ICharacterService characterService) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetCharacters()
    {
        var characters = await characterService.GetAllCharactersAsync();
        return Ok(characters);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Character>> GetCharacterById(int id)
    {
        var character = await characterService.GetCharacterByIdAsync(id);
        return character is null ? 
            NotFound("Could not find character.") : 
            Ok(character);
    }
}  