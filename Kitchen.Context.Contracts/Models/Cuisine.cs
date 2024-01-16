using Kitchen.Context.Contracts.Enums;

namespace Kitchen.Context.Contracts.Models
{
    /// <summary>
    /// Сущность кухни
    /// </summary>
    public class Cuisine : BaseAuditEntity
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
        public TypeOfKitchen Type { get; set; }

        /// <summary>
        /// Время открытия
        /// </summary>
        public string OpeningTime { get; set; } = string.Empty;
        
        /// <summary>
        /// Время закрытия
        /// </summary>
        public string ClosingTime { get; set; } = string.Empty;

        public ICollection<TurnOut> TurnOuts { get; set;}
    }
}
