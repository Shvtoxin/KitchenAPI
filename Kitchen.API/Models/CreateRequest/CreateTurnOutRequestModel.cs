namespace Kitchen.API.Models.CreateRequest
{
    /// <summary>
    /// Сущность добавления явки
    /// </summary>
    public class CreateTurnOutRequestModel
    {
        /// <summary>
        /// Идентификатор кухни
        /// </summary>
        public Guid CuisineId { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public Guid StaffId { get; set;}

        /// <summary>
        /// Идентификатор стимуляции
        /// </summary>
        public Guid? StimulationId { get; set; }

        /// <summary>
        /// Идентификатор типа явки
        /// </summary>
        public Guid TypeOfTurnoutId { get; set; }

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
