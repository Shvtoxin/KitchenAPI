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
    [ApiExplorerSettings(GroupName = "TypeOfTurnout")]
    public class TypeOfTurnoutController : ControllerBase
    {
        private readonly ITypeOfTurnoutService typeOfTurnoutService;
        private readonly IMapper mapper;

        public TypeOfTurnoutController(ITypeOfTurnoutService typeOfTurnoutService, IMapper mapper)
        {
            this.typeOfTurnoutService = typeOfTurnoutService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить список типов явок
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TypeOfTurnoutResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await typeOfTurnoutService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => mapper.Map<TypeOfTurnoutResponse>(x)));
        }

        /// <summary>
        /// Получить тип явки по Id
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TypeOfTurnoutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await typeOfTurnoutService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<TypeOfTurnoutResponse>(item));
        }

        /// <summary>
        /// Добавить тип явки
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(TypeOfTurnoutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromBody] CreateTypeOfTurnoutRequestModel model, CancellationToken cancellationToken)
        {
            var cinemaModel = mapper.Map<TypeOfTurnoutModel>(model);
            var result = await typeOfTurnoutService.AddAsync(cinemaModel, cancellationToken);
            return Ok(mapper.Map<TypeOfTurnoutResponse>(result));
        }

        /// <summary>
        /// Изменить тип явки
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(TypeOfTurnoutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(TypeOfTurnoutRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<TypeOfTurnoutModel>(request);
            var result = await typeOfTurnoutService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<TypeOfTurnoutResponse>(result));
        }

        /// <summary>
        /// Удалить тип явки по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> Delete([Required] Guid id, CancellationToken cancellationToken)
        {
            await typeOfTurnoutService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
