using Labb3_WebAPI.Models;
using Labb3_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IRepository<Interest, int> _interestRepo;

        public InterestController(IRepository<Interest, int> repo)
        {
            _interestRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            return Ok(await _interestRepo.GetAllData());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleInterest(int id)
        {
            var interest = await _interestRepo.GetById(id);

            if (interest != null)
            {
                return Ok(interest);
            }
            return NotFound($"Interest was not found with ID: {id}");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewInterest(Interest newInterest) 
        {
            await _interestRepo.Update(newInterest);

            return Created(HttpContext.Request.Scheme + "://" 
                + HttpContext.Request.Host 
                + HttpContext.Request.Path 
                + "/" + newInterest.InterestId, newInterest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            var interestToDelete = await _interestRepo.GetById(id);
            if (interestToDelete != null)
            {
                await _interestRepo.Delete(interestToDelete.InterestId);
                return Ok();
            }

            return NotFound($"The Interest With ID {id} was not found to delete.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterest(int id, Interest interestToUpdate)
        {
            var currentInterest = await _interestRepo.GetById(id);

            if (currentInterest != null)
            {
                interestToUpdate.InterestId = currentInterest.InterestId;
                await _interestRepo.Update(interestToUpdate);
                return Ok();
            }
            return NotFound($"The Interest With ID {id} was not found to edit");
        }
    }
}
