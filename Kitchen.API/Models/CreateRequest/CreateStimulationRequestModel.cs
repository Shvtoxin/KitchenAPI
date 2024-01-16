namespace Kitchen.API.Models.CreateRequest
{
    /// <summary>
    /// Модель добавления стимуляции для сотрудников
    /// </summary>
    public class CreateStimulationRequestModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание бонуса
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
