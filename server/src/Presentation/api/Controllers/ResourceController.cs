using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Resources.DTOs;
using Application.Resources.Services;
using Domain.Zombie.Resources.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ResourceController : BaseController
    {
        private readonly IResourceAppService _resourceAppService;
        private readonly IResourceReadOnlyRepository _resourceReadOnlyRepository;
        public ResourceController(IResourceAppService resourceAppService,
        IResourceReadOnlyRepository resourceReadOnlyRepository)
        {
            _resourceAppService = resourceAppService;
            _resourceReadOnlyRepository = resourceReadOnlyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var queries = await _resourceAppService.GetAllAsync();

            return ApiResponse(queries);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddResourceDTO resource)
        {
            var result = await _resourceAppService.AddResourceAsync(resource);

            return ApiResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateResourceDTO resource)
        {
            var result = await _resourceAppService.UpdateResourceAsync(resource);

            return ApiResponse(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id)
        {
            var result = await _resourceAppService.DeleteResourceAsync(id);

            return ApiResponse(result);
        }
    }
}