namespace Kitchen.Context.Contracts.Models
{
    /// <summary>
    /// Сущность явки
    /// </summary>
    public class TurnOut : BaseAuditEntity
    {
        /// <summary>
        /// Идентификатор кухни
        /// </summary>
        public Guid CuisineId { get; set; }
        public Cuisine Cuisine { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public Guid StaffId { get; set; }
        public Staff Staff { get; set;}

        /// <summary>
        /// Идентификатор стимуляции
        /// </summary>
        public Guid? StimlationId { get; set; }
        public Stimulation? Stimulation { get; set; }

        /// <summary>
        /// Идентификатор типа явки
        /// </summary>
        public Guid TypeOfTurnoutId { get; set; }
        public TypeOfTurnout Type { get; set; }

        /// <summary>
        /// Дата и время открытия явки
        /// </summary>
        public DateTimeOffset OpeningTime { get; set; }

        /// <summary>
        /// Дата и время закрытия явки
        /// </summary>
        public DateTimeOffset? CloseTime { get; set; }
    }
}
