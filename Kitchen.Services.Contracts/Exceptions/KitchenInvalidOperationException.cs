namespace Kitchen.Services.Contracts.Exceptions
{
    public class KitchenInvalidOperationException : KitchenException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="KitchenInvalidOperationException"/>
        /// с указанием сообщения об ошибке
        /// </summary>
        public KitchenInvalidOperationException(string message)
            : base(message)
        {

        }
    }
}
