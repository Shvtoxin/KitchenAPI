﻿namespace Kitchen.Services.Contracts.Exceptions
{
    public class TimeTableNotFoundException : TimeTableException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TimeTableNotFoundException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        public TimeTableNotFoundException(string message)
            : base(message)
        { }
    }
}
