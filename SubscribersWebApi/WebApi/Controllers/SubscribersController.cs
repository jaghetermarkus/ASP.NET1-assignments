using DataStore.Contexts;
using DataStore.Data;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController(DataContext context) : ControllerBase
{
    public readonly DataContext _context = context;

    // private List<SubscriberModel> _subscribers =
    // [
    //     new SubscriberModel { Id = 1, Name = "Pelle"},
    //     new SubscriberModel { Id = 2, Name = "Lasse"},
    //     new SubscriberModel { Id = 3, Name = "Bosse"},
    // ];

    [HttpPost]
    public async Task<IActionResult> Create(SubscriberFormModel model)
    {
        if (ModelState.IsValid)
        {
            if (!await _context.Subscribers.AnyAsync(x => x.Email == model.Email))
            {
                try
                {
                    _context.Subscribers.Add(SubscribeFactory.Create(model));
                    await _context.SaveChangesAsync();
                    return Created();
                }
                catch { }
                return Problem();
            }
            return Conflict();
        }

        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subscribers = await _context.Subscribers.ToListAsync();
        return Ok(subscribers);
    }


    [HttpGet("{email}")]
    public IActionResult GetOne(string email)
    {
        var subscriber = _context.Subscribers.FirstOrDefault(x => x.Email == email);
        if (subscriber != null)
        {
            return Ok(subscriber);
        }

        return NotFound();
    }


    [HttpPut]
    public async Task<IActionResult> UpdateOne(SubscriberFormModel model)
    {
        if (ModelState.IsValid)
        {
            var subscriber = _context.Subscribers.FirstOrDefault(x => x.Email == model.Email);
            if (subscriber != null)
            {
                subscriber.DailyNewsletter = model.DailyNewsletter;
                subscriber.AdvertisingUpdates = model.AdvertisingUpdates;
                subscriber.WeekinReview = model.WeekinReview;
                subscriber.EventUpdates = model.EventUpdates;
                subscriber.StartupsWeekly = model.StartupsWeekly;
                subscriber.Podcasts = model.Podcasts;

                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
        return BadRequest();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteOne(string email)
    {
        var subscriber = _context.Subscribers.FirstOrDefault(x => x.Email == email);
        if (subscriber != null)
        {
            _context.Subscribers.Remove(subscriber);
            return Ok();
        }
        return BadRequest();

    }


}
