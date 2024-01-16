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
    [ApiExplorerSettings(GroupName = "Stimulation")]
    public class StimulationController : ControllerBase
    {
        private readonly IStimulationService stimulationService;
        private readonly IMapper mapper;

        public StimulationController(IStimulationService stimulationService, IMapper mapper)
        {
            this.stimulationService = stimulationService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить список бонусов
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StimulationResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await stimulationService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => mapper.Map<StimulationResponse>(x)));
        }

        /// <summary>
        /// Получить бонус по Id
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(StimulationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await stimulationService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<StimulationResponse>(item));
        }

        /// <summary>
        /// Добавить бонус
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(StimulationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromBody] CreateStimulationRequestModel model, CancellationToken cancellationToken)
        {
            var stimulationModel = mapper.Map<StimulationModel>(model);
            var result = await stimulationService.AddAsync(stimulationModel, cancellationToken);
            return Ok(mapper.Map<StimulationResponse>(result));
        }

        /// <summary>
        /// Изменить бонус
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(StimulationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(StimulationRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<StimulationModel>(request);
            var result = await stimulationService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<StimulationResponse>(result));
        }

        /// <summary>
        /// Удалить бонус по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> Delete([Required] Guid id, CancellationToken cancellationToken)
        {
            await stimulationService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
