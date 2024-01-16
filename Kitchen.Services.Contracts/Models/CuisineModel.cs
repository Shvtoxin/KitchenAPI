using Kitchen.Services.Contracts.Enums;

namespace Kitchen.Services.Contracts.Models
{
    /// <summary>
    /// Модель кухни
    /// </summary>
    public class CuisineModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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
        public TypeOfKitchenModel Type { get; set; }

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
