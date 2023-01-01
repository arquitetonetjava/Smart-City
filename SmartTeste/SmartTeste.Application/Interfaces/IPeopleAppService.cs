using SmartTeste.Application.EventSourcedNormalizers;
using SmartTeste.Application.ViewModels;
using FluentValidation.Results;

namespace SmartTeste.Application.Interfaces
{
    public interface IPeopleAppService : IDisposable
    {
        Task<IEnumerable<PeopleViewModel>> GetAll();
        Task<PeopleViewModel> GetById(Guid id);

        Task<ValidationResult> Register(PeopleViewModel peopleViewModel);
        Task<ValidationResult> Update(PeopleViewModel peopleViewModel);
        Task<ValidationResult> Remove(Guid id);

        Task<IList<PeopleHistoryData>> GetAllHistory(Guid id);
    }
}
