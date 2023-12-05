using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;
        public WalksController( IMapper mapper,IWalkRepository walkRepository)
        {
            this.walkRepository=walkRepository;
            this.mapper= mapper;
        }
        //Create Walk
        //POST:/api/walks
        [HttpPost]
        [ValidateModelAttribute]
        public async Task<IActionResult>Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            
                //Map DTO to Domain Model
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

                await walkRepository.CreateAsync(walkDomainModel);

                //Map Domain Model to DTO
                return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
        //GET Walk
        //GET:/api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery]string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize=1000)
        {
            var walkDomainModel=await walkRepository.GetAllAsync(filterOn,filterQuery,sortBy,
                isAscending??true,pageNumber,pageSize);

            //Create an exception
            //throw new Exception("This is a new exception");

            //Map Domain Model to DTO
            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
        }
        //GET Walk By Id
        //GET:/api/Walks/{Id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkdomainModel=await walkRepository.GetByIdAsync(id);

            if (walkdomainModel==null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(walkdomainModel));
        }

        //Update Walk By Id
        //PUT:/api/Walks/{Id}
        [Route("{id:Guid}")]
        [HttpPut]
        [ValidateModelAttribute]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
           
                //Map DTO to Domain Model
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

                walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

                if (walkDomainModel == null)
                {
                    return NotFound();
                }

                //Map Domain Model to DTO
                return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //Delete a Walk By Id
        //Delete:/api/Walks/{Id}
        [Route("{id:Guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var deletedwalkDomainModel=await walkRepository.DeleteAsync(id);

            if (deletedwalkDomainModel==null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(deletedwalkDomainModel));
        }
    }
}
