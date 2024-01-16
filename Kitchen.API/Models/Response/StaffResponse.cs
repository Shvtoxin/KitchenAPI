namespace Kitchen.API.Models.Reqsponse
{
    /// <summary>
    /// Модель ответа сотрудника 
    /// </summary>
    public class StaffResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Сущность поста
        /// </summary>
        public PostResponse Post { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Дата начала работы
        /// </summary>
        public DateTimeOffset DateOfHiring { get; set; }
    }
}
