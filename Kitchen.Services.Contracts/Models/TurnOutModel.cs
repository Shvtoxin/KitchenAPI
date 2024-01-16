namespace Kitchen.Services.Contracts.Models
{
    /// <summary>
    /// Сущность явки
    /// </summary>
    public class TurnOutModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Модель кухни
        /// </summary>
        public CuisineModel Cuisine { get; set; }

        /// <summary>
        /// Модель сотрудника
        /// </summary>
        public StaffModel Staff { get; set;}

        /// <summary>
        /// Модель стимуляции
        /// </summary>
        public StimulationModel? Stimulation { get; set; }

        /// <summary>
        /// Модель типа явки
        /// </summary>
        public TypeOfTurnoutModel TypeOfTurnout { get; set; }

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
