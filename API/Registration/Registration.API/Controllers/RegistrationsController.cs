using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration.API.Data;
using Registration.API.Models;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController : Controller
    {
        private readonly RegistrationDbContext _registrationDbContext;
        public RegistrationsController(RegistrationDbContext dbContext)
        {
            _registrationDbContext = dbContext;
        }

        //Get All Registration
        [HttpGet]
        public async Task<IActionResult> GetAllRegistrations()
        {
            var registrations = await _registrationDbContext.Registration.ToListAsync();

            return Ok(registrations);
        }

        //Get Single Registration
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetRegistration")]
        public async Task<IActionResult> GetRegistration([FromRoute] int id)
        {
            var registration = await _registrationDbContext.Registration.FirstOrDefaultAsync(x => x.Id == id);

            if (registration != null)
            {
                return Ok(registration);
            }
            return NotFound("Registration not found");
        }
        //Add Registration
        [HttpPost]
        //[Route("{NPINumber:int}")]
        public async Task<IActionResult> AddRegistrations([FromBody] Registrations registrations)
        {
            await _registrationDbContext.Registration.AddAsync(registrations);
            await _registrationDbContext.SaveChangesAsync();

            //return Ok(registrations);
            return CreatedAtAction(nameof(GetRegistration), new { Id = registrations.Id }, registrations);
        }

        //Update a Registration
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateRegistration([FromRoute] int id, [FromBody] Registrations registrations)
        {
            var existingRegistration = await _registrationDbContext.Registration.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegistration != null)
            {
                existingRegistration.NPINumber = registrations.NPINumber;
                existingRegistration.TelephoneNumber = registrations.TelephoneNumber;
                existingRegistration.Email = registrations.Email;
                existingRegistration.BusinessAddress = registrations.BusinessAddress;
                existingRegistration.FirstName = registrations.FirstName;
                existingRegistration.LastName = registrations.LastName;

                await _registrationDbContext.SaveChangesAsync();

                return Ok(existingRegistration);
            }

            return NotFound("Registration not found");
        }


        //Delete the Registration
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRegistration([FromRoute] int id)
        {
            var existingRegistration = await _registrationDbContext.Registration.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegistration != null)
            {
                _registrationDbContext.Remove(existingRegistration);
                await _registrationDbContext.SaveChangesAsync();

                return Ok(existingRegistration);
            }

            return NotFound("Registration not found");
        }
    }
}
