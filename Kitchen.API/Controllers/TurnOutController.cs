using AutoMapper;
using Kitchen.API.Extensions;
using Kitchen.API.Models.CreateRequest;
using Kitchen.API.Models.Reqsponse;
using Kitchen.API.Models.Request;
using Kitchen.Services.Contracts.ModelsRequest;
using Kitchen.Services.Contracts.ServicesContracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Kitchen.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с кинотеатрами
    /// </summary>
    [ApiController]
    [Route("[Controller]")]
    [ApiExplorerSettings(GroupName = "TurnOut")]
    public class TurnOutController : ControllerBase
    {
        private readonly ITurnOutService turnOutService;
        private readonly IMapper mapper;

        public TurnOutController(ITurnOutService turnOutService, IMapper mapper)
        {
            this.turnOutService = turnOutService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить список заявок
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<TurnOutResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await turnOutService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => mapper.Map<TurnOutResponse>(x)));
        }

        /// <summary>
        /// Получить заявку по Id
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TurnOutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await turnOutService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<TurnOutResponse>(item));
        }

        /// <summary>
        /// Добавить заявку
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(TurnOutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(CreateTurnOutRequestModel model, CancellationToken cancellationToken)
        {
            var turnOutModel = mapper.Map<TurnOurRequestModel>(model);
            var result = await turnOutService.AddAsync(turnOutModel, cancellationToken);
            return Ok(mapper.Map<TurnOutResponse>(result));
        }

        /// <summary>
        /// Изменить заявку по Id
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(TurnOutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(TurnOutRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<TurnOurRequestModel>(request);
            var result = await turnOutService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<TurnOutResponse>(result));
        }

        /// <summary>
        /// Удалить заявку по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> Delete([Required] Guid id, CancellationToken cancellationToken)
        {
            await turnOutService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
