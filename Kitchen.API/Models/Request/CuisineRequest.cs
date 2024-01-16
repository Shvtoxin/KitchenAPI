using Kitchen.API.Models.CreateRequest;

namespace Kitchen.API.Models.Request
{
    /// <summary>
    /// Модель добавления кухни
    /// </summary>
    public class CuisineRequest : CreateCuisineRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
