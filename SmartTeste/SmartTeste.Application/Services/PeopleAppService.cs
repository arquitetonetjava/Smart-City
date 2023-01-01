using AutoMapper;
using FluentValidation.Results;
using NetDevPack.Mediator;
using SmartTeste.Application.EventSourcedNormalizers;
using SmartTeste.Application.Interfaces;
using SmartTeste.Application.ViewModels;
using SmartTeste.Domain.Commands;
using SmartTeste.Domain.Interfaces;
using SmartTeste.Infra.Data.Repository.EventSourcing;

namespace SmartTeste.Application.Services
{
    public class PeopleAppService : IPeopleAppService
    {
        private readonly IMapper _mapper;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public PeopleAppService(IMapper mapper,
                                  IPeopleRepository peopleRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _peopleRepository = peopleRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<PeopleViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<PeopleViewModel>>(await _peopleRepository.GetAll());
        }

        public async Task<PeopleViewModel> GetById(Guid id)
        {
            return _mapper.Map<PeopleViewModel>(await _peopleRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(PeopleViewModel peopleViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPeopleCommand>(peopleViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(PeopleViewModel peopleViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePeopleCommand>(peopleViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemovePeopleCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<IList<PeopleHistoryData>> GetAllHistory(Guid id)
        {
            return PeopleHistory.ToJavaScriptPeopleHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
