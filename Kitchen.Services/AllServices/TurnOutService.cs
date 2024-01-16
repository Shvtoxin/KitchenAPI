using AutoMapper;
using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Contracts.ReadRepositoriesContracts;
using Kitchen.Repositories.Contracts.WriteRepositoriesContracts;
using Kitchen.Services.Anchors;
using Kitchen.Services.Contracts.Exceptions;
using Kitchen.Services.Contracts.Models;
using Kitchen.Services.Contracts.ModelsRequest;
using Kitchen.Services.Contracts.ServicesContracts;

namespace Kitchen.Services.AllServices
{
    public class TurnOutService : ITurnOutService, IServiceAnchor
    {
        private readonly ITurnOutReadRepository turnOutReadRepository;
        private readonly ITurnOutWriteRepository turnOutWriteRepository;
        private readonly IStaffReadRepository staffReadRepository;
        private readonly ICuisineReadRepository cuisineReadRepository;
        private readonly IStimulationReadRepository stimulationReadRepository;
        private readonly ITypeOfTurnoutReadRepository typeOfTurnoutReadRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TurnOutService(IStaffReadRepository staffReadRepository, ICuisineReadRepository cuisineReadRepository,
            IStimulationReadRepository stimulationReadRepository, ITypeOfTurnoutReadRepository typeOfTurnoutReadRepository,
            ITurnOutReadRepository turnOutReadRepository, ITurnOutWriteRepository turnOutWriteRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {            
            this.typeOfTurnoutReadRepository = typeOfTurnoutReadRepository;
            this.cuisineReadRepository = cuisineReadRepository;
            this.stimulationReadRepository = stimulationReadRepository;
            this.staffReadRepository = staffReadRepository;
            this.turnOutReadRepository = turnOutReadRepository;
            this.turnOutWriteRepository = turnOutWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<TurnOutModel> ITurnOutService.AddAsync(TurnOurRequestModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();

            var item = mapper.Map<TurnOut>(model);

            turnOutWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return await GetTurnOutModelOnMapping(item, cancellationToken);
        }

        async Task ITurnOutService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetTurnOut = await turnOutReadRepository.GetByIdAsync(id, cancellationToken);

            if (targetTurnOut == null)
            {
                throw new TimeTableEntityNotFoundException<TurnOut>(id);
            }

            turnOutWriteRepository.Delete(targetTurnOut);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<TurnOutModel> ITurnOutService.EditAsync(TurnOurRequestModel source, CancellationToken cancellationToken)
        {
            var targetTurnOut = await turnOutReadRepository.GetByIdAsync(source.Id, cancellationToken);

            if (targetTurnOut == null)
            {
                throw new TimeTableEntityNotFoundException<TurnOut>(source.Id);
            }

            targetTurnOut = mapper.Map<TurnOut>(source);

            turnOutWriteRepository.Update(targetTurnOut);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return await GetTurnOutModelOnMapping(targetTurnOut, cancellationToken);
        }

        async Task<IEnumerable<TurnOutModel>> ITurnOutService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await turnOutReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => mapper.Map<TurnOutModel>(x));
        }

        async Task<TurnOutModel?> ITurnOutService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await turnOutReadRepository.GetByIdAsync(id, cancellationToken);

            if (item == null)
            {
                throw new TimeTableEntityNotFoundException<TurnOut>(id);
            }

            return mapper.Map<TurnOutModel>(item);
        }

        async private Task<TurnOutModel> GetTurnOutModelOnMapping(TurnOut turnOut, CancellationToken cancellationToken)
        {
            var turnOutModel = mapper.Map<TurnOutModel>(turnOut);
            turnOutModel.Staff = mapper.Map<StaffModel>(await staffReadRepository.GetByIdAsync(turnOut.StaffId, cancellationToken));
            turnOutModel.Cuisine = mapper.Map<CuisineModel>(await cuisineReadRepository.GetByIdAsync(turnOut.CuisineId, cancellationToken));
            turnOutModel.Type = mapper.Map<TypeOfTurnoutModel>(await typeOfTurnoutReadRepository.GetByIdAsync(turnOut.TypeOfTurnoutId, cancellationToken));
            turnOutModel.Stimulation = turnOut.StimlationId.HasValue 
              ? mapper.Map<StimulationModel>(await stimulationReadRepository.GetByIdAsync(turnOut.StimlationId.Value, cancellationToken))
              : null;

            return turnOutModel;
        }
    }
}
