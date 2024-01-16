namespace Kitchen.Services.Contracts.ModelsRequest
{
    public class TurnOurRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор кухни
        /// </summary>
        public Guid CuisineId { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public Guid StaffId { get; set; }

        /// <summary>
        /// Идентификатор стимуляции
        /// </summary>
        public Guid? StimulationId { get; set; }

        /// <summary>
        /// Идентификатор типа явки
        /// </summary>
        public Guid TypeId { get; set; }

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
