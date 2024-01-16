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
    public class CuisineService : ICuisineService, IServiceAnchor
    {
        private readonly ICuisineReadRepository cuisineReadRepositiry;
        private readonly ICuisineWriteRepository cuisineWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CuisineService(ICuisineReadRepository cuisineReadRepositiry, IMapper mapper,
            ICuisineWriteRepository cuisineWriteRepository, IUnitOfWork unitOfWork)
        {
            this.cuisineReadRepositiry = cuisineReadRepositiry;
            this.mapper = mapper;
            this.cuisineWriteRepository = cuisineWriteRepository;
            this.unitOfWork = unitOfWork;
        }

        async Task<CuisineModel> ICuisineService.AddAsync(CuisineModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();

            var item = mapper.Map<Cuisine>(model);
            cuisineWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<CuisineModel>(item);
        }

        async Task ICuisineService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetCuisine = await cuisineReadRepositiry.GetByIdAsync(id, cancellationToken);

            if (targetCuisine == null)
            {
                throw new TimeTableEntityNotFoundException<Cuisine>(id);
            }

            cuisineWriteRepository.Delete(targetCuisine);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<CuisineModel> ICuisineService.EditAsync(CuisineModel source, CancellationToken cancellationToken)
        {
            var targetCuisine = await cuisineReadRepositiry.GetByIdAsync(source.Id, cancellationToken);

            if (targetCuisine == null)
            {
                throw new TimeTableEntityNotFoundException<Cuisine>(source.Id);
            }

            targetCuisine = mapper.Map<Cuisine>(source);
            cuisineWriteRepository.Update(targetCuisine);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<CuisineModel>(targetCuisine);
        }

        async Task<IEnumerable<CuisineModel>> ICuisineService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await cuisineReadRepositiry.GetAllAsync(cancellationToken);
            return result.Select(x => mapper.Map<CuisineModel>(x));
        }

        async Task<CuisineModel?> ICuisineService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await cuisineReadRepositiry.GetByIdAsync(id, cancellationToken);

            if (item == null)
            {
                throw new TimeTableEntityNotFoundException<Cuisine>(id);
            }

            return mapper.Map<CuisineModel>(item);
        }
    }
}
