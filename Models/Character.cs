using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace french_revolution_api.Models;

public class Character
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Profession { get; set; } = string.Empty;
}

public record CharacterResponse(int Id, string Name, string Profession);

public record CharacterRequest(string Name, string Profession);

public static class CharacterMappings 
{
    public static CharacterResponse ToCharacterResponse(this Character c)
    {
        return new CharacterResponse(c.Id, c.Name, c.Profession);
    }

    public static Character ToCharacter(this CharacterRequest c)
    {
        return new Character()
        {
            Name = c.Name,
            Profession = c.Profession,
        };
    }
    
    public static void ApplyUpdate(this Character c, CharacterRequest r)
    {
        c.Name = r.Name;
        c.Profession = r.Profession;
    }
}