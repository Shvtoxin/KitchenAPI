using AutoMapper;
using Kitchen.API.Extensions;
using Kitchen.API.Models.CreateRequest;
using Kitchen.API.Models.Reqsponse;
using Kitchen.API.Models.Request;
using Kitchen.Services.Contracts.Models;
using Kitchen.Services.Contracts.ModelsRequest;
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
    [ApiExplorerSettings(GroupName = "Staff")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService staffService;
        private readonly IMapper mapper;

        public StaffController(IStaffService staffService, IMapper mapper)
        {
            this.staffService = staffService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить список сотрудников
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<StaffResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await staffService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => mapper.Map<StaffResponse>(x)));
        }

        /// <summary>
        /// Получить сотрудника по Id
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(StaffResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await staffService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<StaffResponse>(item));
        }

        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(StaffResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(CreateStaffRequestModel model, CancellationToken cancellationToken)
        {
            var staffModel = mapper.Map<StaffRequestModel>(model);
            var result = await staffService.AddAsync(staffModel, cancellationToken);
            return Ok(mapper.Map<StaffResponse>(result));
        }

        /// <summary>
        /// Изменить cотрудника по Id
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(StaffResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(StaffRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<StaffRequestModel>(request);
            var result = await staffService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<StaffResponse>(result));
        }

        /// <summary>
        /// Удалить сотрудника по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionDetail), StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> Delete([Required] Guid id, CancellationToken cancellationToken)
        {
            await staffService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
