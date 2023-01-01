using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using SmartTeste.Application.EventSourcedNormalizers;
using SmartTeste.Application.Interfaces;
using SmartTeste.Application.ViewModels;

namespace SmartTeste.Services.Api.Controllers
{
    //[Authorize]
    public class PeopleController : ApiController
    { 
        private readonly IPeopleAppService _peopleAppService;

        public PeopleController(IPeopleAppService peopleAppService)
        {
            _peopleAppService = peopleAppService;
        }

        //[AllowAnonymous]
        [HttpGet("people-management")]
        public async Task<IEnumerable<PeopleViewModel>> Get()
        {
            return await _peopleAppService.GetAll();
        }

        //[AllowAnonymous]
        [HttpGet("people-management/{id:guid}")]
        public async Task<PeopleViewModel> Get(Guid id)
        {
            return await _peopleAppService.GetById(id);
        }

        //[CustomAuthorize("Peoples", "Write")]
        [HttpPost("people-management")]
        public async Task<IActionResult> Post([FromBody] PeopleViewModel peopleViewModel)
        {
            // if(peopleViewModel.Id == Guid.Empty) { peopleViewModel.Id = Guid.NewGuid(); }
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _peopleAppService.Register(peopleViewModel));
        }

        //[CustomAuthorize("Peoples", "Write")]
        [HttpPut("people-management")]
        public async Task<IActionResult> Put([FromBody] PeopleViewModel peopleViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _peopleAppService.Update(peopleViewModel));
        }

        //[CustomAuthorize("Peoples", "Remove")]
        [HttpDelete("people-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _peopleAppService.Remove(id));
        }

        //[AllowAnonymous]
        [HttpGet("people-management/history/{id:guid}")]
        public async Task<IList<PeopleHistoryData>> History(Guid id)
        {
            return await _peopleAppService.GetAllHistory(id);
        }
    }
}
