using AutoMapper;
using EducationalMaterialData.Dtos.MaterialTypeDtos;
using EducationalMaterialData.Models;
using EducationalMaterialData.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalMaterial.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    [Route("api/materialType")]
    [ApiController]
    public class MaterialTypeController : ControllerBase
    {
        private readonly ILogger<MaterialTypeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaterialTypeController(ILogger<MaterialTypeController> logger, IUnitOfWork context, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = context;
            _mapper = mapper;
        }

        /// <summary>
        /// GET api/materialType
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMaterialType()
        {
            var materialType = await _unitOfWork.MaterialType.GetAll();
            if (materialType != null)
            {
                _logger.LogInformation("GET api/materialType => OK");
            }
            else
            {
                _logger.LogInformation("GET api/materialType => NOT OK");
                return NotFound();
            }

            var result = _mapper.Map<IEnumerable<MaterialTypeReadDto>>(materialType);

            return Ok(result);

        }

        /// <summary>
        /// GET api/materialType/{MaterialTypeId}
        /// </summary>
        /// <param name="materialTypeId"></param>
        /// <returns></returns>
        [HttpGet("{materialTypeId}")]
        public async Task<IActionResult> GetMaterialTypeById(int materialTypeId)
        {
            var materialType = await _unitOfWork.MaterialType.GetById(materialTypeId);
            if (materialType != null)
            {
                _logger.LogInformation("GET api/materialType => OK");
            }
            else
            {
                _logger.LogInformation("GET api/materialType => NOT OK");
                return NotFound();
            }
            var result = _mapper.Map<MaterialTypeReadDto>(materialType);
            return Ok(result);
        }



        /// <summary>
        /// Create api/materialType
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMaterialType(MaterialTypeCreateDto materialTypeCreateDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("POST api/materialType => OK");
                var materialType = _mapper.Map<MaterialType>(materialTypeCreateDto);
                await _unitOfWork.MaterialType.Create(materialType);
                await _unitOfWork.Save();
                return Ok();
            }
            else
            {
                _logger.LogInformation("POST api/materialType => NOT OK");
                return NotFound();
            }
        }

        /// <summary>
        /// PUT api/materialType/{materialTypeId}
        /// </summary>
        /// <returns></returns>
        [HttpPut("{materialTypeId}")]
        public async Task<IActionResult> UpdateMaterialType(int materialTypeId, MaterialTypeCreateDto authorUpdateDto)
        {
            var materialType = await _unitOfWork.Author.GetById(materialTypeId);
            if (materialType != null)
            {
                var result = _mapper.Map(authorUpdateDto, materialType);
                await _unitOfWork.Author.Update(materialType);
                await _unitOfWork.Save();
                _logger.LogInformation("PUT api/materialType/{materialTypeId} => OK", materialTypeId);
                return Ok();
            }
            else
            {
                _logger.LogInformation("PUT api/materialType/{materialTypeId} => NOT OK", materialTypeId);
                return NoContent();
            }
        }

        /// <summary>
        /// DELETE api/materialType/{MaterialTypeId}
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteMaterialType(int materialTypeId)
        {
            var materialType = await _unitOfWork.MaterialType.GetById(materialTypeId);
            if (materialType == null)
            {
                _logger.LogInformation("DELETE api/materialType/{MaterialTypeId} => NOT OK", materialTypeId);
                return NotFound();
            }
            await _unitOfWork.MaterialType.Delete(materialType);
            await _unitOfWork.Save();

            _logger.LogInformation("DELETE api/materialType/{MaterialTypeId} => OK", materialTypeId);
            return NoContent();
        }
    }
}
