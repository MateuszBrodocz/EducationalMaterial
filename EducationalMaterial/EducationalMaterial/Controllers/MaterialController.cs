using AutoMapper;
using EducationalMaterialData.Dtos.MaterialDtos;
using EducationalMaterialData.Models;
using EducationalMaterialData.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalMaterial.Controllers
{
    [Route("api/material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        
        private readonly ILogger<AuthorController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaterialController(ILogger<AuthorController> logger, IUnitOfWork context, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = context;
            _mapper = mapper;
        }

        /// <summary>
        /// GET api/material
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMaterial([FromQuery] string filter, [FromQuery] string sort)
        {
            var material = await _unitOfWork.Material.GetAll();
            if (material != null)
            {
                _logger.LogInformation("GET api/material => OK");
            }
            else
            {
                _logger.LogInformation("GET api/material => NOT OK");
                return NotFound();
            }

            var result = _mapper.Map<IEnumerable<MaterialReadDto>>(material);

            return Ok(result);

        }

        /// <summary>
        /// GET api/material/{MaterialId}
        /// </summary>
        /// <param name="directorId"></param>
        /// <returns></returns>
        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetMaterialById(int MaterialId)
        {
            var material = await _unitOfWork.Material.GetById(MaterialId);
            if (material != null)
            {
                _logger.LogInformation("GET api/material => OK");
            }
            else
            {
                _logger.LogInformation("GET api/material => NOT OK");
                return NotFound();
            }
            var result = _mapper.Map<MaterialReadDto>(material);
            return Ok(result);
        }



        /// <summary>
        /// POST api/material
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMaterial(MaterialCreateDto materialCreateDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("POST api/material => OK");
                var material= _mapper.Map<Material>(materialCreateDto);
                await _unitOfWork.Material.Create(material);
                await _unitOfWork.Save();
                return Ok();
            }
            else
            {
                _logger.LogInformation("POST api/material => NOT OK");
                return NotFound();
            }
        }

        /// <summary>
        /// POST api/material/{MaterialId}
        /// </summary>
        /// <returns></returns>
        [HttpPut("{materialId}")]
        public async Task<IActionResult> UpdateMaterial(int materialId, MaterialUpdateDto materialUpdateDto)
        {
            var material = await _unitOfWork.Material.GetById(materialId);
            if (material != null)
            {
                var result = _mapper.Map(materialUpdateDto, material);
                await _unitOfWork.Material.Update(material);
                await _unitOfWork.Save();
                _logger.LogInformation("PUT api/material/{MaterialId} => OK", materialId);
                return Ok();
            }
            else
            {
                _logger.LogInformation("PUT api/material/{MaterialId} => NOT OK", materialId);
                return NoContent();
            }
        }

        /// <summary>
        /// DELETE api/material/{MaterialId}
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{materialId}")]
        public async Task<IActionResult> DeleteMaterial(int materialId)
        {
            var material = await _unitOfWork.Material.GetById(materialId);
            if (material == null)
            {
                _logger.LogInformation("DELETE api/material/{MaterialId} => NOT OK", materialId);
                return NotFound();
            }
            await _unitOfWork.Material.Delete(material);
            await _unitOfWork.Save();

            _logger.LogInformation("DELETE api/material/{MaterialId} => OK", materialId);
            return NoContent();
        }
    }
}

