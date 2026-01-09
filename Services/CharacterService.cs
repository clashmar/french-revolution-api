using french_revolution_api.Data;
using french_revolution_api.Models;
using Microsoft.EntityFrameworkCore;

namespace french_revolution_api.Services;

public interface ICharacterService
{
    Task<List<CharacterResponse>> GetAllCharactersAsync();
    Task<CharacterResponse?> GetCharacterByIdAsync(int id);
    Task<CharacterResponse?> AddCharacterAsync(CharacterRequest request);
    Task<CharacterResponse?> UpdateCharacterAsync(int id, CharacterRequest request);
    Task<bool> DeleteCharacterAsync(int id);
}

public class CharacterService(AppDbContext context) : ICharacterService
{
    public async Task<List<CharacterResponse>> GetAllCharactersAsync()
    {
        try
        {
            return await context.Characters
                .Select(c => c.ToCharacterResponse())
                .ToListAsync();
        }
        catch (Exception e)
        {
            return [];
        }
    }
 
    public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
    {
        try
        {
            var character = await context.Characters.FindAsync(id);
            return character?.ToCharacterResponse();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<CharacterResponse?> AddCharacterAsync(CharacterRequest request)
    {
        try
        {
            var result = await context.Characters
                .AddAsync(request.ToCharacter()); 
         
            await context.SaveChangesAsync(); 
            return result.Entity.ToCharacterResponse();
        }
        catch (Exception e)
        {
            return null;
        }
    }
 
    public async Task<CharacterResponse?> UpdateCharacterAsync(int id, CharacterRequest request)
    {
        try
        {
            var character = await context.Characters.FindAsync(id);
        
            if (character is null)
            {
                return null;
            }
        
            character.ApplyUpdate(request);
            await context.SaveChangesAsync();
            return character.ToCharacterResponse();;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> DeleteCharacterAsync(int id)
    {
        try
        {
            var character = await context.Characters.FindAsync(id);
            
            if (character is null)
            {
                return false;
            }
            
            context.Characters.Remove(character);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}