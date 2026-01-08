using french_revolution_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace french_revolution_api.Services;

public interface ICharacterService
{
    Task<List<Character>> GetAllCharactersAsync();
    Task<Character?> GetCharacterByIdAsync(int id);
    Task<Character> AddCharacterAsync(Character character);
    Task<bool> UpdateCharacterAsync(Character character);
    Task<bool> DeleteCharacterAsync(int id);
}

public class CharacterService : ICharacterService
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
    
    public async Task<List<Character>> GetAllCharactersAsync()
    {
        return await Task.FromResult(Characters);
    }

    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return await Task.FromResult(Characters.FirstOrDefault(x => x.Id == id));
    }

    public async Task<Character> AddCharacterAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateCharacterAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCharacterAsync(int id)
    {
        throw new NotImplementedException();
    }
}