using Kitchen.Services.Contracts.Models;
using Kitchen.Services.Contracts.ModelsRequest;

namespace Kitchen.Services.Contracts.ServicesContracts
{
    /// <summary>
    /// Сервис <see cref="StaffModel"/>
    /// </summary>
    public interface IStaffService
    {
        /// <summary>
        /// Получить список всех <see cref="StaffModel"/>
        /// </summary>
        Task<IEnumerable<StaffModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="StaffModel"/> по идентификатору
        /// </summary>
        Task<StaffModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового работника
        /// </summary>
        Task<StaffModel> AddAsync(StaffRequestModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующего работника
        /// </summary>
        Task<StaffModel> EditAsync(StaffRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего работника
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
