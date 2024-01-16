using Kitchen.API.Models.CreateRequest;

namespace Kitchen.API.Models.Request
{
    /// <summary>
    /// Модель добавления сотрудника 
    /// </summary>
    public class StaffRequest : CreateStaffRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
