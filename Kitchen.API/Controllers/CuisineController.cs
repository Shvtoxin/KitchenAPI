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
    [ApiExplorerSettings(GroupName = "Cuisine")]
    public class CuisineController : ControllerBase
    {
        private readonly ICuisineService cuisineService;
        private readonly IMapper mapper;

        public CuisineController(ICuisineService cuisineService, IMapper mapper)
        {
            this.cuisineService = cuisineService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить список кухонь
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CuisineResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await cuisineService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => mapper.Map<CuisineResponse>(x)));
        }

        /// <summary>
        /// Получить кухню по Id
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CuisineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await cuisineService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<CuisineResponse>(item));
        }

        /// <summary>
        /// Добавить кухню
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(CuisineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromBody] CreateCuisineRequestModel model, CancellationToken cancellationToken)
        {
            var cuisineModel = mapper.Map<CuisineModel>(model);
            var result = await cuisineService.AddAsync(cuisineModel, cancellationToken);
            return Ok(mapper.Map<CuisineResponse>(result));
        }

        /// <summary>
        /// Изменить кухню
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(CuisineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(CuisineRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<CuisineModel>(request);
            var result = await cuisineService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<CuisineResponse>(result));
        }

        /// <summary>
        /// Удалить кухню по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> Delete([Required] Guid id, CancellationToken cancellationToken)
        {
            await cuisineService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
