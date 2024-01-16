namespace Kitchen.Context.Contracts.Models
{
    /// <summary>
    /// Сущность сотрудника 
    /// </summary>
    public class Staff : BaseAuditEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор должности
        /// </summary>
        public Guid PostId { get; set; }
        public Post Post { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string? Telephone { get; set; }

        /// <summary>
        /// Дата начала работы
        /// </summary>
        public DateTimeOffset DateOfHiring { get; set; }

        public ICollection<TurnOut> TurnOuts { get; set; }
    }
}
