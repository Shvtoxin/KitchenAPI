using Kitchen.API.Models.CreateRequest;

namespace Kitchen.API.Models.Request
{
    /// <summary>
    /// Модель добавления должности работника
    /// </summary>
    public class PostRequest : CreatePostRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
