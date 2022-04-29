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
    public class LinkController : ControllerBase
    {
        private IRepository<Link, int> _linkRepo;

        public LinkController(IRepository<Link, int> linkRepo)
        {
            _linkRepo = linkRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetLinks()
        {
            return Ok(await _linkRepo.GetAllData());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLinkById(int id)
        {
            var link = await _linkRepo.GetById(id);
            if (link != null)
            {
                return Ok(link);
            }
            return NotFound($"Link with ID: {id} was not found!");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewLink(Link newLink)
        {
            await _linkRepo.AddNew(newLink);

            return Created(HttpContext.Request.Scheme + "://"
                + HttpContext.Request.Host 
                + HttpContext.Request.Path
                + "/" + newLink.LinkId, newLink);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            var linkToDelete = await _linkRepo.GetById(id);
            if (linkToDelete != null)
            {
                await _linkRepo.Delete(linkToDelete.LinkId);
                return Ok();
            }
            return NotFound($"Link with ID: {id} was not found to delete!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditLink(int id, Link linkToUpdate)
        {
            var currentLink = await _linkRepo.GetById(id);

            if (currentLink != null)
            {
                linkToUpdate.LinkId = currentLink.LinkId;
                await _linkRepo.Update(linkToUpdate);
                return Ok();
            }
            return NotFound($"Link with ID: {id} was not found to change!");
        }
    }
}
