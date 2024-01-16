namespace Kitchen.API.Models.Reqsponse
{
    /// <summary>
    /// Модель ответа явки
    /// </summary>
    public class TurnOutResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Модель кухни
        /// </summary>
        public CuisineResponse Cuisine { get; set; }

        /// <summary>
        /// Модель сотрудника
        /// </summary>
        public StaffResponse Staff { get; set;}

        /// <summary>
        /// Модель стимуляции
        /// </summary>
        public StimulationResponse? Stimulation { get; set; }

        /// <summary>
        /// Модель типа явки
        /// </summary>
        public TypeOfTurnoutResponse TypeOfTurnout { get; set; }

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
