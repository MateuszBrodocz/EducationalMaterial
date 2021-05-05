using AutoMapper;
using EducationalMaterialData.Dtos.AuthorDtos;
using EducationalMaterialData.Models;
using EducationalMaterialData.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalMaterial.Controllers
{

    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorController(ILogger<AuthorController> logger, IUnitOfWork context, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = context;
            _mapper = mapper;
        }

        /// <summary>
        /// GET api/author
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAuthor([FromQuery] QueryPaginationParameters queryPaginationParameters, [FromQuery] string filter, [FromQuery] string sort)
        {
            var author = await _unitOfWork.Author.GetAll(queryPaginationParameters, filter, sort);
            if (author != null)
            {
                _logger.LogInformation("GET api/author => OK");
            }
            else
            {
                _logger.LogInformation("GET api/author => NOT OK");
                return NotFound();
            }

            var result = _mapper.Map<IEnumerable<AuthorReadDto>>(author);

            return Ok(result);
        }

        /// <summary>
        /// GET api/author/{AuthorId}
        /// </summary>
        /// <param name="directorId"></param>
        /// <returns></returns>
        [HttpGet("{authorId}")]
        
        public async Task<IActionResult> GetAuthorById(int authorId)
        {
            var items = await _unitOfWork.Author.GetById(authorId);
            if (items != null)
            {
                _logger.LogInformation("GET api/author/{authorId} => Ok", authorId);
                return Ok(_mapper.Map<AuthorReadDto>(items));
            }
            _logger.LogInformation("GET api/author/{AuthorId} => NotFound", authorId);
            return NotFound();
        }



        /// <summary>
        /// POST api/author
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorCreateDto AuthorCreateDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("POST api/author => OK");
                var author = _mapper.Map<Author>(AuthorCreateDto);
                await _unitOfWork.Author.Create(author);
                await _unitOfWork.Save();
                return Ok();
            }
            else
            {
                _logger.LogInformation("POST api/author => NOT OK");
                return NotFound();
            }
        }

        /// <summary>
        /// POST api/author/{AuthorId}
        /// </summary>
        /// <returns></returns>
        [HttpPut("{authorId}")]
        public async Task<IActionResult> UpdateAuthor(int authorId, AuthorUpdateDto authorUpdateDto)
        {
            var author = await _unitOfWork.Author.GetById(authorId);
            if (author != null)
            {
                var result = _mapper.Map(authorUpdateDto, author);
                await _unitOfWork.Author.Update(author);
                await _unitOfWork.Save();
                _logger.LogInformation("PUT api/author/{authorId} => OK", authorId);
                return Ok();
            }
            else
            {
                _logger.LogInformation("PUT api/author/{authorId} => NOT OK", authorId);
                return NoContent();
            }
        }

        /// <summary>
        /// DELETE api/author/{authorId}
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteActor(int authorId)
        {
            var author = await _unitOfWork.Author.GetById(authorId);
            if (author == null)
            {
                _logger.LogInformation("DELETE api/actors/{actorsId} => NOT OK", authorId);
                return NotFound();
            }
            await _unitOfWork.Author.Delete(author);
            await _unitOfWork.Save();

            _logger.LogInformation("DELETE api/actors/{actorsID} => OK", authorId);
            return NoContent();
        }

        /// <summary>
        /// DELETE api/author/{authorId}
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{authorId}")]
        public async Task<IActionResult> Patch(int authorId, [FromBody] JsonPatchDocument<Author> patchEntity)
        {
            var author = await _unitOfWork.Author.GetById(authorId);
            if (author == null)
            {
                return NotFound();
            }

            patchEntity.ApplyTo(author, ModelState);
            await _unitOfWork.Save();

            return Ok(author);
        }

    }
}
