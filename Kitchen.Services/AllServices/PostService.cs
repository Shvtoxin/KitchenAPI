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
    public class PostService : IPostService, IServiceAnchor
    {
        private readonly IPostReadRepository postReadRepositiry;
        private readonly IPostWriteRepository postWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PostService(IPostReadRepository postReadRepositiry, IMapper mapper,
            IPostWriteRepository postWriteRepository, IUnitOfWork unitOfWork)
        {
            this.postReadRepositiry = postReadRepositiry;
            this.mapper = mapper;
            this.postWriteRepository = postWriteRepository;
            this.unitOfWork = unitOfWork;
        }

        async Task<PostModel> IPostService.AddAsync(PostModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();

            var item = mapper.Map<Post>(model);
            postWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<PostModel>(item);
        }

        async Task IPostService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetPost = await postReadRepositiry.GetByIdAsync(id, cancellationToken);

            if (targetPost == null)
            {
                throw new KitchenEntityNotFoundException<Post>(id);
            }

            postWriteRepository.Delete(targetPost);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<PostModel> IPostService.EditAsync(PostModel source, CancellationToken cancellationToken)
        {
            var targetPost = await postReadRepositiry.GetByIdAsync(source.Id, cancellationToken);

            if (targetPost == null)
            {
                throw new KitchenEntityNotFoundException<Post>(source.Id);
            }

            targetPost = mapper.Map<Post>(source);
            postWriteRepository.Update(targetPost);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<PostModel>(targetPost);
        }

        async Task<IEnumerable<PostModel>> IPostService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await postReadRepositiry.GetAllAsync(cancellationToken);
            return result.Select(x => mapper.Map<PostModel>(x));
        }

        async Task<PostModel?> IPostService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await postReadRepositiry.GetByIdAsync(id, cancellationToken);

            if (item == null)
            {
                throw new KitchenEntityNotFoundException<Post>(id);
            }

            return mapper.Map<PostModel>(item);
        }
    }
}
