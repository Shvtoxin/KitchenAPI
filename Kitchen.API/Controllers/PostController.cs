using AutoMapper;
using Kitchen.API.Extensions;
using Kitchen.API.Models.CreateRequest;
using Kitchen.API.Models.Reqsponse;
using Kitchen.API.Models.Request;
using Kitchen.Services.Contracts.Models;
using Kitchen.Services.Contracts.ServicesContracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с кинотеатрами
    /// </summary>
    [ApiController]
    [Route("[Controller]")]
    [ApiExplorerSettings(GroupName = "Post")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            this.postService = postService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить список должностей
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await postService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => mapper.Map<PostResponse>(x)));
        }

        /// <summary>
        /// Получить должность по Id
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PostResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await postService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<PostResponse>(item));
        }

        /// <summary>
        /// Добавить должность
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(PostResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromBody] CreatePostRequestModel model, CancellationToken cancellationToken)
        {
            var postModel = mapper.Map<PostModel>(model);
            var result = await postService.AddAsync(postModel, cancellationToken);
            return Ok(mapper.Map<PostResponse>(result));
        }

        /// <summary>
        /// Изменить должность
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(PostResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(PostRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<PostModel>(request);
            var result = await postService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<PostResponse>(result));
        }

        /// <summary>
        /// Удалить должность по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> Delete([Required] Guid id, CancellationToken cancellationToken)
        {
            await postService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
