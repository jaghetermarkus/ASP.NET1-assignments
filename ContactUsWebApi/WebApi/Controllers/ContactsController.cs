using DataStore.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Create(ContactFormModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var contactEntity = await _context.Contacts.FirstOrDefaultAsync(x => x.Email == model.Email);

                if (contactEntity != null)
                {
                    _context.Messages.Add(MessageFactory.Create(contactEntity, model.Message, model.ServiceId));
                    await _context.SaveChangesAsync();
                    return Created();
                }
                else
                {
                    _context.Contacts.Add(ContactFactory.Create(model));
                    await _context.SaveChangesAsync();
                    return Created();
                }
            }
        }
        catch (DbUpdateException ex)
        {
            // Logga undantaget eller skriv ut det i konsolen
            Console.WriteLine($"DbUpdateException: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Logga undantaget eller skriv ut det i konsolen
            Console.WriteLine($"Exception: {ex.Message}");
        }

        return BadRequest();
    }
}
