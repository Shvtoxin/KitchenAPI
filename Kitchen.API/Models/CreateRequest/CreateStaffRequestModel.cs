﻿namespace Kitchen.API.Models.CreateRequest
{
    /// <summary>
    /// Модель добавления сотрудника 
    /// </summary>
    public class CreateStaffRequestModel
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
        /// Идентификатор поста
        /// </summary>
        public Guid PostId { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Дата начала работы
        /// </summary>
        public DateTimeOffset DateOfHiring { get; set; }
    }
}
