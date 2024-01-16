using Kitchen.API.Enums;
using Kitchen.Services.Contracts.Enums;

namespace Kitchen.API.Models.CreateRequest
{
    /// <summary>
    /// Модель добавления кухни
    /// </summary>
    public class CreateCuisineRequestModel
    {
        /// <summary>
        /// Название кухни
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Тип кухни
        /// </summary>
        public TypeOfKitchenRequest Type { get; set; }

        /// <summary>
        /// Время открытия
        /// </summary>
        public string OpeningTime { get; set; } = string.Empty;
        
        /// <summary>
        /// Время закрытия
        /// </summary>
        public string ClosingTime { get; set; } = string.Empty;
    }
}
