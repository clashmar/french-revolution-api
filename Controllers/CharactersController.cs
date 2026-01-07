using french_revolution_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace french_revolution_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : Controller
{
    private static readonly List<Character> Characters = 
    [
        new()
        {
            Id = 1,
            Name = "Georges Danton",
            Profession = "Lawyer"
        },
        new()
        {
            Id = 2,
            Name = "Camille Desmoulins",
            Profession = "Journalist"
        },
        new()
        {
            Id = 3,
            Name = "Maximilien Robespierre",
            Profession = "Lawyer"
        }
    ];
    
    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetCharacters()
    {
        return await Task.FromResult(Ok(Characters));
    }
}