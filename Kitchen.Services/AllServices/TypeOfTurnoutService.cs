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
    public class TypeOfTurnoutService : ITypeOfTurnoutService, IServiceAnchor
    {
        private readonly ITypeOfTurnoutReadRepository typeOfTurnoutReadRepositiry;
        private readonly ITypeOfTurnoutWriteRepository typeOfTurnoutWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TypeOfTurnoutService(ITypeOfTurnoutReadRepository typeOfTurnoutReadRepositiry, IMapper mapper,
            ITypeOfTurnoutWriteRepository typeOfTurnoutWriteRepository, IUnitOfWork unitOfWork)
        {
            this.typeOfTurnoutReadRepositiry = typeOfTurnoutReadRepositiry;
            this.mapper = mapper;
            this.typeOfTurnoutWriteRepository = typeOfTurnoutWriteRepository;
            this.unitOfWork = unitOfWork;
        }

        async Task<TypeOfTurnoutModel> ITypeOfTurnoutService.AddAsync(TypeOfTurnoutModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();

            var item = mapper.Map<TypeOfTurnout>(model);
            typeOfTurnoutWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<TypeOfTurnoutModel>(item);
        }

        async Task ITypeOfTurnoutService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetTypeOfTurnout = await typeOfTurnoutReadRepositiry.GetByIdAsync(id, cancellationToken);

            if (targetTypeOfTurnout == null)
            {
                throw new KitchenEntityNotFoundException<TypeOfTurnout>(id);
            }

            typeOfTurnoutWriteRepository.Delete(targetTypeOfTurnout);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<TypeOfTurnoutModel> ITypeOfTurnoutService.EditAsync(TypeOfTurnoutModel source, CancellationToken cancellationToken)
        {
            var targetTypeOfTurnout = await typeOfTurnoutReadRepositiry.GetByIdAsync(source.Id, cancellationToken);

            if (targetTypeOfTurnout == null)
            {
                throw new KitchenEntityNotFoundException<TypeOfTurnout>(source.Id);
            }

            targetTypeOfTurnout = mapper.Map<TypeOfTurnout>(source);
            typeOfTurnoutWriteRepository.Update(targetTypeOfTurnout);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<TypeOfTurnoutModel>(targetTypeOfTurnout);
        }

        async Task<IEnumerable<TypeOfTurnoutModel>> ITypeOfTurnoutService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await typeOfTurnoutReadRepositiry.GetAllAsync(cancellationToken);
            return result.Select(x => mapper.Map<TypeOfTurnoutModel>(x));
        }

        async Task<TypeOfTurnoutModel?> ITypeOfTurnoutService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await typeOfTurnoutReadRepositiry.GetByIdAsync(id, cancellationToken);

            if (item == null)
            {
                throw new KitchenEntityNotFoundException<TypeOfTurnout>(id);
            }

            return mapper.Map<TypeOfTurnoutModel>(item);
        }
    }
}
