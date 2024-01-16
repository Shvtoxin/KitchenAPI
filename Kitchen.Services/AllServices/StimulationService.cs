using AutoMapper;
using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Contracts.ReadRepositoriesContracts;
using Kitchen.Repositories.Contracts.WriteRepositoriesContracts;
using Kitchen.Services.Anchors;
using Kitchen.Services.Contracts.Exceptions;
using Kitchen.Services.Contracts.Models;
using Kitchen.Services.Contracts.ServicesContracts;

namespace Kitchen.Services.AllServices
{
    public class StimulationService : IStimulationService, IServiceAnchor
    {
        private readonly IStimulationReadRepository stimulationReadRepositiry;
        private readonly IStimulationWriteRepository stimulationWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StimulationService(IStimulationReadRepository stimulationReadRepositiry, IMapper mapper,
            IStimulationWriteRepository stimulationWriteRepository, IUnitOfWork unitOfWork)
        {
            this.stimulationReadRepositiry = stimulationReadRepositiry;
            this.mapper = mapper;
            this.stimulationWriteRepository = stimulationWriteRepository;
            this.unitOfWork = unitOfWork;
        }

        async Task<StimulationModel> IStimulationService.AddAsync(StimulationModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();

            var item = mapper.Map<Stimulation>(model);
            stimulationWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<StimulationModel>(item);
        }

        async Task IStimulationService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetStimulation = await stimulationReadRepositiry.GetByIdAsync(id, cancellationToken);

            if (targetStimulation == null)
            {
                throw new KitchenEntityNotFoundException<Stimulation>(id);
            }

            stimulationWriteRepository.Delete(targetStimulation);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<StimulationModel> IStimulationService.EditAsync(StimulationModel source, CancellationToken cancellationToken)
        {
            var targetStimulation = await stimulationReadRepositiry.GetByIdAsync(source.Id, cancellationToken);

            if (targetStimulation == null)
            {
                throw new KitchenEntityNotFoundException<Stimulation>(source.Id);
            }

            targetStimulation = mapper.Map<Stimulation>(source);
            stimulationWriteRepository.Update(targetStimulation);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<StimulationModel>(targetStimulation);
        }

        async Task<IEnumerable<StimulationModel>> IStimulationService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await stimulationReadRepositiry.GetAllAsync(cancellationToken);
            return result.Select(x => mapper.Map<StimulationModel>(x));
        }

        async Task<StimulationModel?> IStimulationService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await stimulationReadRepositiry.GetByIdAsync(id, cancellationToken);

            if (item == null)
            {
                throw new KitchenEntityNotFoundException<Stimulation>(id);
            }

            return mapper.Map<StimulationModel>(item);
        }
    }
}
