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
    public class PersonController : ControllerBase
    {
        private IRepository<Person, int> _personRepo;
        private IRepository<PersonInterest, int> _persInter;
        private IRepository<Interest, int> _interestRepo;
        private IRepository<InterestLink, int> _interestLinkRepo;
        private IRepository<Link, int> _linkRepo;
        public PersonController(IRepository<Person, int> IRepo, IRepository<PersonInterest, int> IPersonInterest, IRepository<Interest, int> IInterest, IRepository<InterestLink, int> IInterestLink, IRepository<Link, int> ILink)
        {
            _personRepo = IRepo;
            _persInter = IPersonInterest;
            _interestRepo = IInterest;
            _interestLinkRepo = IInterestLink;
            _linkRepo = ILink;
        }

        //Gets all people in PersonDB
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            try
            {
                return Ok(await _personRepo.GetAllData());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database..");
            }
        }

        //Gets persons interests by person ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSinglePerson(int id)
        {
            try
            {
                var person = await _personRepo.GetById(id);

                if (person != null)
                {
                    var query = (from pi in await _persInter.GetAllData()

                                 join p in await _personRepo.GetAllData()
                                 on pi.PersonId equals p.PersonId

                                 join i in await _interestRepo.GetAllData()
                                 on pi.InterestId equals i.InterestId

                                 join il in await _interestLinkRepo.GetAllData()
                                 on i.InterestId equals il.InterestId


                                 where (pi.PersonId == id)
                                 select new
                                 {
                                     Title = i.InterestTitle,
                                     Description = i.InterestDescription
                                 }).Distinct();
                    return Ok(query);
                }
                return NotFound($"Could not find anyone at id: {id}");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database..");
            }
        }

        //Gets all links associated with person on 'id'
        [HttpGet("link/{id}")]
        public async Task<IActionResult> GetPersonLinks(int id)
        {
            try
            {
                var personInDb = await _personRepo.GetById(id);

                if (personInDb != null)
                {
                    var query = (from person in await _personRepo.GetAllData()

                                 join personInterest in await _persInter.GetAllData()
                                 on person.PersonId equals personInterest.PersonId

                                 join interest in await _interestRepo.GetAllData()
                                 on personInterest.InterestId equals interest.InterestId

                                 join interestLink in await _interestLinkRepo.GetAllData()
                                 on interest.InterestId equals interestLink.InterestId

                                 join link in await _linkRepo.GetAllData()
                                 on interestLink.LinkId equals link.LinkId

                                 where (person.PersonId == id)
                                 select new
                                 {
                                     AssociatedInterest = interest.InterestTitle,
                                     LinkURL = link.LinkUrl
                                 }).Distinct();

                    return Ok(query);
                }

                return NotFound($"Could not find anyone at id: {id}");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database..");
            }
        }

        //Adds a new interest by taking id from person and then the correct interest by id
        [HttpPost("{personId}/{interestId}")]
        public async Task<IActionResult> AddNewInterest(int personId, int interestId)
        {
            try
            {
                var newInterest = new PersonInterest { PersonId = personId, InterestId = interestId };
                await _persInter.AddNew(newInterest);
                var addedInterest = await _interestRepo.GetById(interestId);
                var person = await _personRepo.GetById(personId);
                return Ok($"{addedInterest.InterestTitle} was added to {person.PersonName}");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database..");
            }
        }

        //Adds a new link, by taking the correct interestId then adding the link as a string
        [HttpPost("newlink/{interestId}/{newLinkToAdd}")]
        public async Task<IActionResult> AddNewLinks(int interestId, string newLinkToAdd)
        {
            try
            {
                var link = await _linkRepo.AddNew(new Link { LinkUrl = newLinkToAdd });
                var newInterestLink = new InterestLink { InterestId = interestId, LinkId = link.LinkId };
                await _interestLinkRepo.AddNew(newInterestLink);
                return Ok("Added the new link");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database..");
            }
        }

        //To delete a person
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var personToDelete = await _personRepo.GetById(id);
            if (personToDelete != null)
            {
                await _personRepo.Delete(personToDelete.PersonId);
                return Ok();
            }
            return NotFound($"Person with ID: {id} was not found to delete!");
        }

        //To update a person
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPerson(int id, Person p)
        {
            var personToChange = await _personRepo.GetById(id);

            if(personToChange != null)
            {
                p.PersonId = personToChange.PersonId;
                await _personRepo.Update(p);
                return Ok();
            }
            return NotFound($"Person with ID: {id} was not found to edit!");
        }
    }
}
