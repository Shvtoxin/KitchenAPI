﻿using AutoMapper;
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
    /// <inheritdoc cref="IStaffService"/>
    public class StaffService : IStaffService, IServiceAnchor
    {
        private readonly IStaffWriteRepository staffWriteRepository;
        private readonly IStaffReadRepository staffReadRepository;
        private readonly IPostReadRepository postReadRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StaffService(IStaffWriteRepository staffWriteRepository, IStaffReadRepository staffReadRepository, 
            IUnitOfWork unitOfWork, IMapper mapper, IPostReadRepository postReadRepository)
        {
            this.staffWriteRepository = staffWriteRepository;
            this.staffReadRepository = staffReadRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.postReadRepository = postReadRepository;
        }

        async Task<StaffModel> IStaffService.AddAsync(StaffRequestModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();

            var item = mapper.Map<Staff>(model);


            staffWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return await GetStaffModelOnMapping(item, cancellationToken);
        }

        async Task IStaffService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetStaff = await staffReadRepository.GetByIdAsync(id, cancellationToken);

            if (targetStaff == null)
            {
                throw new TimeTableEntityNotFoundException<Staff>(id);
            }

            staffWriteRepository.Delete(targetStaff);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<StaffModel> IStaffService.EditAsync(StaffRequestModel source, CancellationToken cancellationToken)
        {
            var targetStaff = await staffReadRepository.GetByIdAsync(source.Id, cancellationToken);

            if (targetStaff == null)
            {
                throw new TimeTableEntityNotFoundException<Staff>(source.Id);
            }

            targetStaff = mapper.Map<Staff>(source);

            staffWriteRepository.Update(targetStaff);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return await GetStaffModelOnMapping(targetStaff, cancellationToken);
        }

        async Task<IEnumerable<StaffModel>> IStaffService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await staffReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => mapper.Map<StaffModel>(x));
        }

        async Task<StaffModel?> IStaffService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await staffReadRepository.GetByIdAsync(id, cancellationToken);

            if (item == null)
            {
                throw new TimeTableEntityNotFoundException<Staff>(id);
            }

            return mapper.Map<StaffModel>(item);
        }

        async private Task<StaffModel> GetStaffModelOnMapping(Staff staff, CancellationToken cancellationToken)
        {
            var staffModel = mapper.Map<StaffModel>(staff);
            staffModel.Post = mapper.Map<PostModel>(await postReadRepository.GetByIdAsync(staff.PostId, cancellationToken));
            return staffModel;
        }
    }
}
